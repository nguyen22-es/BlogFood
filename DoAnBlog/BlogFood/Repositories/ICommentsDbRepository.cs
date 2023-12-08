using Data.Data.Entities;


namespace API.Repository
{
    public interface ICommentsDbRepository
    {

        Task<Comment> CreateCommentAsync(Comment comment); 
        List<Comment> GetAllCommentsParents(string postId);

        List<Comment> GetAllCommentsDepth(int Depth, string CommentFatherID);
      
        Task DeleteCommentAsync(string id); 
        Task<Comment> UpdateCommentAsync(string comment,string content); 
    }
}
