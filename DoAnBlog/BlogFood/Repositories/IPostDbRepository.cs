

using DataAccess.Data.Entities;

namespace API.Repository
{
    public interface IPostDbRepository
    {
        void CreatePosts(Post posts);
        List<Post> GetAllTitle();
        void DeletePosts(string id);
        void UpdatePosts(Post  posts); // sửa post

    }
}
