using BlogFoodApi.ViewModel;

namespace BlogFoodApi.Service
{
    public interface ICommentService
    {
        List<CommentViewModel> GetCommentParents(string PostID);

        List<CommentViewModel> GetCommentDepth(int Depth, string CommentParentsID);

        void DeleteComment(string CommentID);
    }
}
