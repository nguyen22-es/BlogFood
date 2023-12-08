using BlogFoodApi.ViewModel;
using DataAccess;
using DataAccess.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace BlogFoodApi.Service
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;
        private readonly ManageAppDbContext manageAppDbContext;
        private readonly UserManager<ManageUser> _manageUser;
   
        public TokenService(IConfiguration configuration, ManageAppDbContext manageAppDbContext, UserManager<ManageUser> manageUser)
        {

            _configuration = configuration;
            this.manageAppDbContext = manageAppDbContext;
            _manageUser = manageUser;
        }

   

        public async Task<ApiResponse> CheckTokenAsync(RefreshModel refreshModel)
        {
            var secret = _configuration["JWT:Secret"] ?? throw new InvalidOperationException("Secret not configured");
            // check accesstoken có hợp lệ hay không
            var validation = new TokenValidationParameters
            {
                ValidIssuer = _configuration["JWT:ValidIssuer"],
                ValidAudience = _configuration["JWT:ValidAudience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret)),
                ValidateLifetime = false
            };
            try
            {
                var tokenInVerification = new JwtSecurityTokenHandler().ValidateToken(refreshModel.AccessToken, validation, out var validatedToken);
                var ID = tokenInVerification.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;

                // check phần header trong jwt xem thuật toán có đúng không
                if (validatedToken is JwtSecurityToken jwtSecurityToken)
                {
                    var result = jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase);
                    if (!result)//false
                    {
                        return new ApiResponse
                        {
                            Success = false,
                            Message = "Invalid token"
                        };
                    }
                }
                // check refreshtoken xem có trong csdl không          
                var storedToken = await manageAppDbContext.UserTokens.FirstOrDefaultAsync(u => u.UserId == ID);
                if (storedToken == null)
                {
                    return new ApiResponse
                    {
                        Success = false,
                        Message = "Refresh token does not exist"
                    };
                }
                if (storedToken.ExpiredAt < DateTime.Now)
                {
                    return new ApiResponse
                    {
                        Success = false,
                        Message = "Unauthorized"
                    };
                }
                // kiểm tra xem refeshToken đã bị thu hồi hay sử dụng chưa
                if (storedToken.IsUsed)
                  {
                      return new ApiResponse
                      {
                          Success = false,
                          Message = "Refresh token has been used"
                      };
                  }
                  if (storedToken.IsRevoked)
                  {
                      return new ApiResponse
                      {
                          Success = false,
                          Message = "Refresh token has been revoked"
                      };
                  }

                // check jwtid của accessToken  với  jwtid của refresh token
                var jti = tokenInVerification.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Jti).Value;
                if (storedToken.IDaccessTokenJwt != jti)
                {
                    return new ApiResponse
                    {
                        Success = false,
                        Message = "Token doesn't match"
                    };
                }


                //create new token

                storedToken.IsRevoked = true;
                storedToken.IsUsed = true;
                manageAppDbContext.Update(storedToken);
                await manageAppDbContext.SaveChangesAsync();

                //create new token
                var user = await _manageUser.FindByIdAsync(ID);
               
                Task<RefreshModel> token = GenerateJwt(user);


                RefreshModel resultToken = token.Result;
                return new ApiResponse
                {
                    Success = true,
                    Message = "Renew token success",
                    Data = resultToken
                };


            }
            catch (Exception ex)
            {
                return new ApiResponse
                {
                    Success = false,
                    Message = "Something went wrong"
                };
            }




        }


        public async Task<RefreshModel> GenerateJwt(ManageUser userName)
        {
         
            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, userName.DisplayName),
                new Claim(ClaimTypes.NameIdentifier, userName.Id),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
              //  new Claim(JwtRegisteredClaimNames.Email, userName.Email),
                new Claim(JwtRegisteredClaimNames.Sub, userName.UserName),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                _configuration["JWT:Secret"] ?? throw new InvalidOperationException("Secret not configured")));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.UtcNow.AddSeconds(30),
                claims: authClaims,
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
                );

            var JwtToken = new JwtSecurityTokenHandler().WriteToken(token);
            var refreshToken = GenerateRefreshToken();


            
            var refreshTokenSame = await manageAppDbContext.UserTokens.FirstOrDefaultAsync(t => t.UserId == userName.Id);
            if (refreshTokenSame == null)
            {
                var refreshTokenEntity = new IdentityUserToken
                {
                    Name = userName.UserName,
                    LoginProvider = "myToken",
                    IDaccessTokenJwt = token.Id,
                    UserId = userName.Id,
                    Value = refreshToken,
                    IsUsed = false,
                    IsRevoked = false,
                    IssuedAt = DateTime.Now,
                    ExpiredAt = DateTime.Now.AddHours(1)
                };

                await manageAppDbContext.AddAsync(refreshTokenEntity);
                await manageAppDbContext.SaveChangesAsync();

            }

            refreshTokenSame.Value = refreshToken;
            refreshTokenSame.IssuedAt = DateTime.Now;
            refreshTokenSame.ExpiredAt = DateTime.Now.AddHours(1);
            refreshTokenSame.IDaccessTokenJwt = token.Id;
             manageAppDbContext.Update(refreshTokenSame);
            await manageAppDbContext.SaveChangesAsync();


            return new RefreshModel
            {
                AccessToken = JwtToken,               
                RefreshToken = refreshToken
            };

        }

        public string GenerateRefreshToken()
        {
            var randomNumber = new byte[64];

            using var generator = RandomNumberGenerator.Create();

            generator.GetBytes(randomNumber);

            return Convert.ToBase64String(randomNumber);
        }

        public ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {
            var secret = _configuration["JWT:Secret"] ?? throw new InvalidOperationException("Secret not configured");

            var validation = new TokenValidationParameters
            {
                ValidIssuer = _configuration["JWT:ValidIssuer"],
                ValidAudience = _configuration["JWT:ValidAudience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret)),
                ValidateLifetime = false
            };

            return new JwtSecurityTokenHandler().ValidateToken(token, validation, out _);
        }
    }
}
