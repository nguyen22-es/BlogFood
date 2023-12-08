
using BlogFoodApi.Repositories;
using DataAccess;
using DataAccess.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Repository
{
    public class CategoryRepository:ICategoryDbRepository
    {
        private readonly ManageAppDbContext _manageAppDbContext;
        public CategoryRepository(ManageAppDbContext manageAppDbContext)
        {

            this._manageAppDbContext = manageAppDbContext;
        }

        public void CreateFriend(Category category)
        {
           _manageAppDbContext.categories.Add(category);
        }

        public List<Category> GetAll()
        {
          return  _manageAppDbContext.categories.ToList();
        }
    }
}
