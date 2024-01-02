using Dapper;

using DataAccess;
using DataAccess.Data.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace API.Repository
{
    public class LikePostRepository : ILikePostDbRepository
    {
        private static string connectionString = "Data Source=sonzsz;Initial Catalog=BlogFood;Integrated Security=True;Encrypt=False;Trust Server Certificate=True";
        private ManageAppDbContext _manageAppDbContext;
        public LikePostRepository(ManageAppDbContext manageAppDbContext)
        {

            _manageAppDbContext = manageAppDbContext;
        }

        public void CreatePostLike(string UserLike, string PostID)
        {
            var postLike = new LikePost
            {
                PostId = PostID,
                UserId = UserLike
            };

            _manageAppDbContext.likePosts.Add(postLike);
            _manageAppDbContext.SaveChanges();

        }

        public void DeletePostLike(string UserLike, string PostID)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    var query = "delete from BlogFood.dbo.likePosts where PostId=@PostId and UserId=@UserId";
                    var paramObject = new { PostId = PostID, UserId = UserLike };
                    connection.Execute(query, paramObject);
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
              
            }
        }







        public bool IsLike(string UserLike, string PostID)
        {
            var LikePost = _manageAppDbContext.likePosts.FirstOrDefault(c => c.PostId == PostID && c.UserId == UserLike);
            if (LikePost != null) return true;

            return false;
            
        }

      
    }
}
