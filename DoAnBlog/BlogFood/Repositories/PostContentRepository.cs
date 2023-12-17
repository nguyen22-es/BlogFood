using Data.Data.Entities;
using DataAccess;
using Microsoft.EntityFrameworkCore;

namespace BlogFoodApi.Repositories
{
    public class PostContentRepository : IPostContentRepository
    {
        private readonly ManageAppDbContext _manageAppDbContext;
        public PostContentRepository(ManageAppDbContext manageAppDbContext)
        {
            _manageAppDbContext = manageAppDbContext;
        }

        public async Task CreateFood(FoodIngredient foodIngredient)
        {
            _manageAppDbContext.foodIngredients.Add(foodIngredient);
          await _manageAppDbContext.SaveChangesAsync();
        }

        public async Task CreateIngredient(Ingredients ingredients)
        {
            _manageAppDbContext.Ingredients.Add(ingredients);
          await  _manageAppDbContext.SaveChangesAsync();
        }

        public async Task  CreatePostContent(PostContent postContent)
        {
            _manageAppDbContext.postContents.Add(postContent);
          await  _manageAppDbContext.SaveChangesAsync();


        }



        public void DeletePostContent(PostContent postContent)
        {
            var postContents = _manageAppDbContext.postContents.FirstOrDefault(i => i.ContentPostID == postContent.ContentPostID);

            _manageAppDbContext.postContents.Remove(postContents);
        }

        public PostContent GetContent(string PostID)
        {
            var postContents = _manageAppDbContext.postContents.FirstOrDefault(i => i.PostId == PostID);

            return postContents;
        }

        public async Task UpdatePostContent(string postContent, string ID)
        {
            var postContents = await _manageAppDbContext.postContents.FirstOrDefaultAsync(i => i.ContentPostID == ID);

            postContents.Content = postContent;

            _manageAppDbContext.postContents.Update(postContents);
          await _manageAppDbContext.SaveChangesAsync();



        }
    }
}
