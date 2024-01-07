using Data.Data.Entities;
using DataAccess;

using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace API.Repository
{
    public class CommentsRepository:ICommentsDbRepository
    {
        private readonly ManageAppDbContext _manageAppDbContext;

        public CommentsRepository(ManageAppDbContext manageAppDbContext)
        {
            _manageAppDbContext = manageAppDbContext;
        }

        public async Task<Comment> CreateCommentAsync(Comment comment)
        {
            _manageAppDbContext.comments.Add(comment);
            await _manageAppDbContext.SaveChangesAsync();

         
            var foundComment = await _manageAppDbContext.comments.FindAsync(comment.CommentID);
            return foundComment;
        }

        public async Task DeleteCommentAsync(string id)
        {
            var foundComment = await _manageAppDbContext.comments.FindAsync(id);
            _manageAppDbContext.comments.Remove(foundComment);
        }

        public List<Comment> GetAllCommentsDepth(int Depth, string CommentFatherID)
        {
            var foundComment = new List<Comment>();
            if (Depth < 2)
            {
                foundComment = _manageAppDbContext.comments.Where(c => c.CommentFatherID == CommentFatherID && c.Depth == Depth+1).OrderByDescending(c => c.timeComment).ToList();
            }
                foundComment = _manageAppDbContext.comments.Where(c => c.CommentFatherID == CommentFatherID && c.Depth == Depth).OrderByDescending(c => c.timeComment).ToList();

            return foundComment;
        }

        public List<Comment> GetAllCommentsParents(string postId)
        {
            var foundComment =  _manageAppDbContext.comments.Include(f => f.user).Where(c => c.PostID == postId && c.Depth == 0).OrderByDescending(c => c.timeComment).ToList();

            if (foundComment != null)
            {
                return foundComment;
            }

            return foundComment;
        }


        public async Task<Comment> UpdateCommentAsync(string comment,string content)
        {
            var foundComment = await _manageAppDbContext.comments.FirstOrDefaultAsync(c =>c.CommentID ==comment);

            foundComment.Content = content;

            _manageAppDbContext.comments.Update(foundComment);
            await _manageAppDbContext.SaveChangesAsync();

            return foundComment;

        }
    }
}
