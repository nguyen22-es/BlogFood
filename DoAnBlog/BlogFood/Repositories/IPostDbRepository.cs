

using Data.Data.Entities;
using DataAccess.Data.Entities;

namespace API.Repository
{
    public interface IPostDbRepository
    {
        List<Post> GetPostUser(string UserId);
        List<RatingPost> getRating(string PostID);
        FoodIngredient GetFood(string post);
        Post GetTitle(string PostID);
       Task CreatePosts(Post posts);
        List<Post> GetAllTitle();
        List<Post> GetPostTrueTitle();
        Task DeletePosts(string id);
        Task UpdatePosts(Post  posts); // sửa post

    }
}
