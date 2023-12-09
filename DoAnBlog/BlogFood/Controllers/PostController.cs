using BlogFoodApi.Service;
using BlogFoodApi.ViewModel;
using DataAccess.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlogFoodApi.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        public readonly UserManager<ManageUser> manageUser;
        private readonly IPostService _postService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public PostController(IHttpContextAccessor httpContextAccessor,IPostService postService, UserManager<ManageUser> manageUser)
        {
            _postService = postService;
            this.manageUser = manageUser;
            _httpContextAccessor = httpContextAccessor;
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
        public async Task<ActionResult> Post([FromBody] RequestPostViewModel requestPostViewModel)
        {
          await  _postService.CreatePost(requestPostViewModel);


            return Ok();
        }

        // PUT api/<PostController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put([FromBody] RequestPostViewModel requestPostViewModel)
        {
            await _postService.UpdatePost( requestPostViewModel);

            return Ok();

        }

        // DELETE api/<PostController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string PostID)
        {
            await _postService.DeletePost(PostID);

            return Ok();

        }
    }
}
