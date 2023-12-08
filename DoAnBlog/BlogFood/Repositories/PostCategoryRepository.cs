using Data.Data.Entities;
using DataAccess;

namespace BlogFoodApi.Repositories
{
    public class PostCategoryRepository : IPostCategoryRepository
    {
        private readonly ManageAppDbContext _manageAppDbContext;
        public PostCategoryRepository(ManageAppDbContext manageAppDbContex)
        {
            _manageAppDbContext = manageAppDbContex;
        }

        public void CreateCategory(PostContent postContent)
        {
            throw new NotImplementedException();
        }


    }
}
