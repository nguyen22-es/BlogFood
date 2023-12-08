using BlogFoodApi.Repositories;
using DataAccess.Data.Entities;

namespace BlogFoodApi.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryDbRepository  _categoryDbRepository;
        public CategoryService(ICategoryDbRepository categoryDbRepository) 
        {
            _categoryDbRepository = categoryDbRepository;

        }

        public List<Category> GetCategory()
        {
           return _categoryDbRepository.GetAll();
        }
    }
}
