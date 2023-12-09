using Data.Data.Entities;

namespace BlogFoodApi.Repositories
{
    public interface IPostContentRepository
    {
        PostContent CreatePostContent(PostContent postContent);

        Task UpdatePostContent(string postContent ,string ID);


        void DeletePostContent(PostContent postContent);

        PostContent GetContent(string PostID);
    }
}
