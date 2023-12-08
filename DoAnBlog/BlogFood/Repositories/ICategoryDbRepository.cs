using DataAccess.Data.Entities;

namespace BlogFoodApi.Repositories
{
    public interface ICategoryDbRepository
    {
        void CreateFriend(Category category);
        List<Category> GetAll();


    }
}
