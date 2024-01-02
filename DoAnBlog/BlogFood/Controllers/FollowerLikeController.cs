using API.SignalrHub;
using BlogFoodApi.Service;
using DataAccess.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

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
        private readonly IHubContext<ChatHub>  _hubContext;
        public FollowerLikeController(IHubContext<ChatHub> hubContex, ILikeService likeService, IFollowService followService, UserManager<ManageUser> manageUser) 
        {
            this.likeService = likeService;
            this.followService = followService;
            this.manageUser = manageUser;
            _hubContext = hubContex;
        }
        // GET: api/<FollowerLikeController>
    
        [HttpDelete("unlike")]
        public async Task<ActionResult> DeleteLike(string UserLike, string PostID) // unlike
        {
            likeService.Unlike(UserLike, PostID);

            return Ok();
        }

        // POST api/<FollowerLikeController>
        [HttpPost("like")]
        public async Task<ActionResult> Like( string UserLike,string PostID) // like post
        {

            likeService.Like(UserLike, PostID);

            return Ok();
        }
        [HttpGet]
        public async Task<ActionResult<bool>> GetLike(string UserLike, string PostID) // like ? true : false
        {

          var isLike =   likeService.IsLike(UserLike, PostID);

            return Ok(isLike);
        }





        [HttpDelete("unfollow")]
        public async Task<ActionResult> DeleteFl(string Follower, string Followin)
        {
            followService.UnFollow(Follower, Followin);

            return Ok();
        }

        // POST api/<FollowerLikeController>
        [HttpPost("follow")]
        public async Task<ActionResult> Follow(string Follower, string Followin)
        {

            followService.Follow(Follower, Followin);

            return Ok();
        }
        [HttpGet("follow")]
        public async Task<ActionResult<bool>> GetFollow(string UserLike, string PostID) // like ? true : false
        {

            var isLike = followService.IsFollow(UserLike, PostID);

            return Ok(isLike);
        }


    }
}
