using Data.Data.Entities;
using DataAccess;
using DataAccess.Data.Entities;

namespace BlogFoodApi.Repositories
{
    public class PostCategoryRepository : IPostCategoryRepository
    {
        private readonly ManageAppDbContext _manageAppDbContext;
        public PostCategoryRepository(ManageAppDbContext manageAppDbContex)
        {
            _manageAppDbContext = manageAppDbContex;
        }

        public async Task  CreateCategory(PostCategory postContent)
        {
            _manageAppDbContext.postCategories.Add(postContent);
           await _manageAppDbContext.SaveChangesAsync();

         
        }
    }
}
