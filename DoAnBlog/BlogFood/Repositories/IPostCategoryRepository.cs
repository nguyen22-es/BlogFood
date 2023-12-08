using Data.Data.Entities;

namespace BlogFoodApi.Repositories
{
    public interface IPostCategoryRepository
    {

        void CreatePostContent(PostContent postContent);

        void DeletePostContent(PostContent postContent);



    }
}
