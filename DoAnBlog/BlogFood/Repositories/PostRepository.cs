using DataAccess;
using DataAccess.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Repository
{
    public class PostRepository : IPostDbRepository
    {
        private readonly ManageAppDbContext _manageAppDbContext;
        public PostRepository(ManageAppDbContext manageAppDbContext)
        {

            this._manageAppDbContext = manageAppDbContext;
        }

        public void CreatePosts(Post posts)
        {
            _manageAppDbContext.Posts.Add(posts);
            _manageAppDbContext.SaveChanges();

        }

        public void DeletePosts(string id)
        {
            throw new NotImplementedException();
        }

        public List<Post> GetAllTitle()
        {
            var posts = _manageAppDbContext.Posts.Include(p => p.User).OrderByDescending(x => x.DatePosted).ToList();

            return posts;
        }

        public void UpdatePosts(Post posts)
        {
            throw new NotImplementedException();
        }
    }
}
