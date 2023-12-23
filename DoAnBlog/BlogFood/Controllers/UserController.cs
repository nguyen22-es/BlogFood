using BlogFood.Controllers;
using BlogFoodApi.Service;
using BlogFoodApi.ViewModel;
using DataAccess.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogFoodApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly UserManager<ManageUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly ILogger<UserController> _logger;
        private readonly ITokenService _tokenService;
        private readonly RoleManager<IdentityRole> roleManager;
      

        public UserController(RoleManager<IdentityRole> roleManager, UserManager<ManageUser> userManager, IConfiguration configuration, ILogger<UserController> logger, ITokenService tokenService)
        {
            _userManager = userManager;
            _configuration = configuration;
            _logger = logger;
            _tokenService = tokenService;
            this.roleManager = roleManager;
        }
        [HttpGet]
        public async Task<ActionResult> Get() 
        {
            var usersInRole = await _userManager.Users.ToListAsync();

      

            return Ok(usersInRole);
        }

        // GET api/<CommentController>/5
       /* [HttpGet("{Depth}")]
        public async Task<ActionResult<IEnumerable<CommentViewModel>>> Get(int Depth, string CommentParentsID) // lấy những comment con sau đấy
        {
            var CommentDepth = commentService.GetCommentDepth(Depth, CommentParentsID);

            return Ok(CommentDepth);
        }


        // PUT api/<CommentController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CommentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }*/
    }
}
