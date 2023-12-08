
using DataAccess;
using DataAccess.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Repository
{
    public class LikePostRepository:ILikePostDbRepository
    {
        private readonly ManageAppDbContext _manageAppDbContext;
        public LikePostRepository(ManageAppDbContext manageAppDbContext)
        {

            _manageAppDbContext = manageAppDbContext;
        }

        public void CreatePostLike(string UserLike, string PostID)
        {
            var postLike = new LikePost
            {
                PostId = PostID,
                UserId  = UserLike
            };

           _manageAppDbContext.likePosts.Add(postLike);
            _manageAppDbContext.SaveChanges();

        }

        public void DeletePostLike(string UserLike, string PostID)
        {
           var LikePost = _manageAppDbContext.likePosts.FirstOrDefault(c => c.PostId == PostID && c.UserId == UserLike);

            _manageAppDbContext.likePosts.Remove(LikePost);
        }
    }
}
