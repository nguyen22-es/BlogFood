namespace BlogFoodApi.Service
{
    public interface ILikeService
    {
        void Like(string userLike, string PostID);
        void Unlike(string userLike, string PostID);
    }
}
