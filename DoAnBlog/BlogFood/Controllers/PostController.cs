using BlogFoodApi.Service;
using BlogFoodApi.ViewModel;
using DataAccess;
using DataAccess.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlogFoodApi.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        public readonly UserManager<ManageUser> manageUser;
        private readonly IPostService _postService;
        private readonly ManageAppDbContext  manageAppDbContext;
        public PostController(ManageAppDbContext manageAppDbContext, IPostService postService, UserManager<ManageUser> manageUser)
        {
            _postService = postService;
            this.manageUser = manageUser;
            this.manageAppDbContext = manageAppDbContext;
        }

        // GET: api/<PostController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TitleViewModel>>> Get()
        {
          

            var Post = _postService.titleViewModels();

            if (Post == null)
                return BadRequest("khong có bài viết hoặc lỗi khi lấy bài viết");

            return Ok(Post);
        }

        [HttpGet("PostUser")]
        public async Task<ActionResult<IEnumerable<ProfileViewModel>>> GetPostUser(string UserId) // lấy tát cả những bài viết của mình
        {
            var profile = new ProfileViewModel();
            var user = await manageUser.FindByIdAsync(UserId);
            var role = await manageUser.IsInRoleAsync(user, "User");
            
            var UserViewmodel = new changeRole { displayName = user.DisplayName, email = user.Email, phoneNumber = user.PhoneNumber, Role = role== true ? 1 : 0 };
            profile.changeRole = UserViewmodel;
           
            var Post = _postService.GetPostUser(UserId);
            if (Post == null)
                return BadRequest("khong có bài viết hoặc lỗi khi lấy bài viết");

            profile.TitleViewModel = Post;

            return Ok(profile);
        }




        [HttpGet("PostTrue")]
        public async Task<ActionResult<IEnumerable<TitleViewModel>>> GetIsTrue() 
        {


            var Post = _postService.PostTrue();

            if (Post == null)
                return BadRequest("khong có bài viết hoặc lỗi khi lấy bài viết");

            return Ok(Post);
        }
        [HttpGet("CoutLike")]
        public async Task<ActionResult> GetCoutLike(string PostID)
        {


            var postContent = _postService.GetContent(PostID);

            if (postContent == null)
                return BadRequest("khong có bài viết hoặc lỗi khi lấy bài viết");

            return Ok(postContent.Title.Like);
        }

        // GET api/<PostController>/5
        [HttpGet("{PostID}")]
        public async Task<ActionResult<IEnumerable<TitleViewModel>>> Get(string PostID)
        {
           


            var postContent = _postService.GetContent(PostID);
            if (postContent == null)
                return NotFound();


            return Ok(postContent);
        }



        // POST api/<PostController>
        [HttpPost]
        public async Task<ActionResult> Post(string UserID,[FromBody] RequestPostViewModel requestPostViewModel)
        {
          await  _postService.CreatePost(requestPostViewModel, UserID);


            return Ok();
        }

        // PUT api/<PostController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put([FromBody] RequestPostViewModel requestPostViewModel)
        {
            await _postService.UpdatePost( requestPostViewModel);

            return Ok();

        }


        [HttpPut]
        public async Task<ActionResult> PutChage( string PostID)
        {
            var Post = await manageAppDbContext.Posts.FirstOrDefaultAsync(p => p.PostId == PostID);

            Post.IsPosted = true;

            await manageAppDbContext.SaveChangesAsync();

            return Ok();

        }



        // DELETE api/<PostController>/5
        [HttpDelete]
        public async Task<ActionResult> Delete(string PostID)
        {
            await _postService.DeletePost(PostID);

            return Ok();

        }
    }
}
