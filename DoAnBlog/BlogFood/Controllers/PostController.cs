using BlogFoodApi.Service;
using BlogFoodApi.ViewModel;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlogFoodApi.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;
        public PostController(IPostService postService)
        {
            _postService = postService;
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
            _postService.CreatePost(requestPostViewModel);


            return Ok();
        }

        // PUT api/<PostController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PostController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
