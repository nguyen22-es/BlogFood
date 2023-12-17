using Data.Data.Entities;
using DataAccess.Data.Entities;

namespace BlogFoodApi.Repositories
{
    public interface IPostCategoryRepository
    {

         Task CreateCategory(PostCategory postContent);

    //    void DeletePostContent(PostContent postContent);



    }
}
