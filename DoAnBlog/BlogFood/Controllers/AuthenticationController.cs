using BlogFoodApi.Service;
using BlogFoodApi.ViewModel;
using DataAccess.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;


namespace BlogFood.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly UserManager<ManageUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly ILogger<AuthenticationController> _logger;
        private readonly ITokenService _tokenService;
        private readonly RoleManager<IdentityRole> roleManager;

        public AuthenticationController(RoleManager<IdentityRole> roleManager,UserManager<ManageUser> userManager, IConfiguration configuration, ILogger<AuthenticationController> logger, ITokenService tokenService)
        {
            _userManager = userManager;
            _configuration = configuration;
            _logger = logger;
            _tokenService = tokenService;
            this.roleManager = roleManager;
        }

        [HttpPost("Register")]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Register([FromBody] RegistrationModel model)
        {
            _logger.LogInformation("Register called");

            var existingUser = await _userManager.FindByNameAsync(model.UserName);

            if (existingUser != null)
                return Conflict("User already exists.");

            var newUser = new ManageUser
            {
                UserName = model.UserName,
                DisplayName = model.UserName,  
                Email = model.Email,
                PhoneNumber = model.PhoneNumber

            };

            var result = await _userManager.CreateAsync(newUser, model.Password);

            if (result.Succeeded)
            {
                var roleExist = await roleManager.RoleExistsAsync("User");
                if (!roleExist)
                {
                    await roleManager.CreateAsync(new IdentityRole("User"));
                }
                await _userManager.AddToRoleAsync(newUser, "User");
                _logger.LogInformation("Register succeeded");

                return Ok("User successfully created");
            }
            else
                return StatusCode(StatusCodes.Status500InternalServerError,
                       $"Failed to create user: {string.Join(" ", result.Errors.Select(e => e.Description))}");
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            _logger.LogInformation("Login called");

            var user = await _userManager.FindByNameAsync(model.Username);
            var userRoles = await _userManager.GetRolesAsync(user);

            if (user == null || !await _userManager.CheckPasswordAsync(user, model.Password))
                return Unauthorized();

            var Token = _tokenService.GenerateJwt(user, userRoles);
            var refreshModel = new RefreshModel();

            refreshModel.RefreshToken = Token.Result.RefreshToken;
            refreshModel.AccessToken = Token.Result.AccessToken;



            _logger.LogInformation("Login succeeded");

            return Ok(refreshModel);
           
        }

        [HttpPost("Refresh")]
        public async Task<IActionResult> Refresh([FromBody] RefreshModel model)
        {
            _logger.LogInformation("Refresh called");

            var user = await _tokenService.CheckTokenAsync(model);

            _logger.LogInformation("Refresh succeeded");

            return Ok(user);
        }

        [Authorize]
        [HttpDelete("Revoke")]

        public async Task<IActionResult> Revoke()
        {
            _logger.LogInformation("Revoke called");

            var username = HttpContext.User.Identity?.Name;

            if (username is null)
                return Unauthorized();

            var user = await _userManager.FindByNameAsync(username);

            if (user is null)
                return Unauthorized();

            await _userManager.UpdateAsync(user);

            _logger.LogInformation("Revoke succeeded");

            return Ok();
        }

        
    }
}
