using BlogFoodApi.Service;
using BlogFoodApi.ViewModel;
using DataAccess.Data.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlogFoodApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        public readonly ICommentService commentService;
        public CommentController(ICommentService commentService)
        {
            this.commentService = commentService;
        }

        // GET: api/<CommentController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CommentViewModel>>> Get(string PostID) // lấy commnet khi nhấn vào hiển thị comment trong bài viết
        {
            var CommentParents = commentService.GetCommentParents(PostID);

            return Ok(CommentParents);
        }

        // GET api/<CommentController>/5
        [HttpGet("{Depth}")]
        public async Task<ActionResult<IEnumerable<CommentViewModel>>> Get(int Depth, string CommentParentsID) // lấy những comment con sau đấy
        {
            var CommentDepth = commentService.GetCommentDepth(Depth, CommentParentsID);

            return Ok(CommentDepth);
        }

        // POST api/<CommentController>
        /* [HttpPost]
         public void Post()
         {
             commentService.cr

         }*/

        // PUT api/<CommentController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CommentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
