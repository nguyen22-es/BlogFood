using DataAccess;
using DataAccess.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Repository
{
    public class PostRepository:IPostDbRepository
    {
        private readonly ManageAppDbContext _manageAppDbContext;
        public PostRepository(ManageAppDbContext manageAppDbContext)
        {

            this._manageAppDbContext = manageAppDbContext;
        }

        public void CreatePosts(Post posts)
        {
            throw new NotImplementedException();
        }

        public void DeletePosts(string id)
        {
            throw new NotImplementedException();
        }

        public List<Post> GetAllTitle()
        {
         var Post =  _manageAppDbContext.Posts.Include(c => c.User.DisplayName).OrderByDescending(x => x.DatePosted).ToList();

            return Post;
        }

        public void UpdatePosts(Post posts)
        {
            throw new NotImplementedException();
        }
    }
}
