using BlogFood.Controllers;
using BlogFoodApi.Service;
using BlogFoodApi.ViewModel;
using DataAccess;
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
        private readonly ManageAppDbContext  _manageAppDbContext;
        private readonly ILogger<UserController> _logger;
        private readonly ITokenService _tokenService;
        private readonly RoleManager<IdentityRole> roleManager;
      

        public UserController(RoleManager<IdentityRole> roleManager, UserManager<ManageUser> userManager, ManageAppDbContext manageAppDbContext, ILogger<UserController> logger, ITokenService tokenService)
        {
            _userManager = userManager;
            _manageAppDbContext = manageAppDbContext;
            _logger = logger;
            _tokenService = tokenService;
            this.roleManager = roleManager;
        }
        [HttpGet]
        public async Task<ActionResult> Get() 
        {
            var list = new List<changeRole>();

            var usersInRole = await _userManager.GetUsersInRoleAsync("User");
            foreach (var item in usersInRole)
            {
                var l = new changeRole { displayName = item.DisplayName,email = item.Email,phoneNumber = item.PhoneNumber,Role = 1 };

                list.Add(l);
            }
            var banInRole = await _userManager.GetUsersInRoleAsync("BanUser");
            foreach (var item in banInRole)
            {
                var l = new changeRole { displayName = item.DisplayName, email = item.Email, phoneNumber = item.PhoneNumber, Role = 0 };

                list.Add(l);
            }

            return Ok(list);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutAsync(string id,  int value)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
            {
                // Xử lý người dùng không tồn tại
                return NotFound();
            }

            var userRoles = await _userManager.GetRolesAsync(user);

            // Xóa người dùng khỏi tất cả các vai trò hiện tại
            var removeRolesResult = await _userManager.RemoveFromRolesAsync(user, userRoles);

            if (!removeRolesResult.Succeeded)
            {
                // Xử lý khi có lỗi xảy ra khi xóa vai trò
                return NotFound("Error");
            }

            // Thêm người dùng vào vai trò mới
           

            if (value == 0)
            {
              
                await _userManager.AddToRoleAsync(user, "User");
                return Ok();
            }
            else
            {
                
              await _userManager.AddToRoleAsync(user, "BanUser");
                return Ok();
            }



           
        }
       
        // GET api/<CommentController>/5
        /* [HttpGet("{Depth}")]
         public async Task<ActionResult<IEnumerable<CommentViewModel>>> Get(int Depth, string CommentParentsID) // lấy những comment con sau đấy
         {
             var CommentDepth = commentService.GetCommentDepth(Depth, CommentParentsID);

             return Ok(CommentDepth);
         }



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
