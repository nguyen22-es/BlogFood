using API.Repository;
using AutoMapper;
using BlogFoodApi.ViewModel;
using Data.Data.Entities;

namespace BlogFoodApi.Service
{
    public class CommentService : ICommentService
    {
        public readonly ICommentsDbRepository commentsDbRepository;
        private readonly IMapper _mapper;
        public CommentService(ICommentsDbRepository commentsDbRepository, IMapper mapper)
        {
            this.commentsDbRepository = commentsDbRepository;
            _mapper = mapper;
        }

        public void DeleteComment(string CommentID)
        {
            commentsDbRepository.DeleteCommentAsync(CommentID);
        }

        List<CommentViewModel> ICommentService.GetCommentDepth(int Depth, string CommentParentsID)
        {
            var comment = commentsDbRepository.GetAllCommentsDepth(Depth, CommentParentsID);

            var commentSameViewModel = _mapper.Map<List<Comment>, List<CommentViewModel>>(comment);


            return commentSameViewModel;
        }

        List<CommentViewModel> ICommentService.GetCommentParents(string PostID)
        {
            var comment = commentsDbRepository.GetAllCommentsParents(PostID);

            var commentSameViewModel = _mapper.Map<List<Comment>, List<CommentViewModel>>(comment);


            return commentSameViewModel;
        }


     

    }
}
