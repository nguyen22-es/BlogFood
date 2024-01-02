using API.Repository;

namespace BlogFoodApi.Service
{
    public class LikeService : ILikeService
    {
        private readonly ILikePostDbRepository  likePostDbRepository;

        public LikeService(ILikePostDbRepository likePostDbRepository)
        {
            this.likePostDbRepository = likePostDbRepository;
        }

        public bool IsLike(string userLike, string PostID)
        {
            var Islike = likePostDbRepository.IsLike( userLike,  PostID);
            return Islike;
        }

        public void Like(string userLike, string PostID)
        {
            likePostDbRepository.CreatePostLike(userLike, PostID);
        }

        public void Unlike(string userLike, string PostID)
        {


            likePostDbRepository.DeletePostLike(userLike, PostID);
        }
    }
}
