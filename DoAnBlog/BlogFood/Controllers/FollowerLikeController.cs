using BlogFoodApi.Service;
using DataAccess.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlogFoodApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FollowerLikeController : ControllerBase
    {
        public readonly ILikeService likeService;
        public readonly IFollowService followService;
        public readonly UserManager< ManageUser> manageUser;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public FollowerLikeController(IHttpContextAccessor httpContextAccessor,ILikeService likeService, IFollowService followService, UserManager<ManageUser> manageUser) 
        {
            this.likeService = likeService;
            this.followService = followService;
            this.manageUser = manageUser;
            _httpContextAccessor = httpContextAccessor;
        }
        // GET: api/<FollowerLikeController>
    
        [HttpDelete("unlike")]
        public async Task<ActionResult> DeleteLike(string UserLike, string PostID)
        {
            likeService.Unlike(UserLike, PostID);

            return Ok();
        }

        // POST api/<FollowerLikeController>
        [HttpGet("like")]
        public async Task<ActionResult> GetLike( string UserLike,string PostID)
        {

            likeService.Like(UserLike, PostID);

            return Ok();
        }

        [HttpDelete("unfollow")]
        public async Task<ActionResult> DeleteFl(string Follower, string Followin)
        {
            followService.UnFollow(Follower, Followin);

            return Ok();
        }

        // POST api/<FollowerLikeController>
        [HttpGet("follow")]
        public async Task<ActionResult> GetFl(string Follower, string Followin)
        {

            followService.Follow(Follower, Followin);

            return Ok();
        }



    }
}
