

using DataAccess.Data.Entities;

namespace API.Repository
{
    public interface IPostDbRepository
    {
        Post GetTitle(string PostID);
       Task CreatePosts(Post posts);
        List<Post> GetAllTitle();
        Task DeletePosts(string id);
        Task UpdatePosts(Post  posts); // sửa post

    }
}
