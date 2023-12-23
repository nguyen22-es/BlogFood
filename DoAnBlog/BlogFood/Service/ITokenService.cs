using BlogFoodApi.ViewModel;
using DataAccess.Data.Entities;

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace BlogFoodApi.Service
{
    public interface ITokenService
    {
        string GenerateRefreshToken();

        Task<RefreshModel> GenerateJwt(ManageUser user, ICollection<string> Role);


        Task<ApiResponse> CheckTokenAsync(RefreshModel refreshModel);

        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);


    }
}
