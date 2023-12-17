using Data.Data.Entities;

namespace BlogFoodApi.Repositories
{
    public interface IPostContentRepository
    {
        Task CreatePostContent(PostContent postContent);

        Task CreateFood(FoodIngredient foodIngredient);

        Task  CreateIngredient(Ingredients ingredients);

        Task UpdatePostContent(string postContent ,string ID);


        void DeletePostContent(PostContent postContent);

        PostContent GetContent(string PostID);
    }
}
