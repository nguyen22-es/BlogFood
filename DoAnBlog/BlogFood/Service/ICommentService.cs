using BlogFoodApi.ViewModel;

namespace BlogFoodApi.Service
{
    public interface ICommentService
    {
        List<CommentViewModel> GetCommentParents(string PostID);

        List<CommentViewModel> GetCommentDepth(CommentViewModel commentViewModel);

        void DeleteComment(string CommentID);

    }
}
