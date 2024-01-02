

namespace API.Repository
{
    public interface ILikePostDbRepository
    {
        void CreatePostLike(string UserLike, string PostID);

        void DeletePostLike(string UserLike, string PostID);

        bool IsLike(string UserLike, string PostID);

    }
}
