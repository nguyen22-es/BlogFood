using API.Repository;
using AutoMapper;
using BlogFoodApi.Repositories;
using BlogFoodApi.ViewModel;
using Data.Data.Entities;
using DataAccess.Data.Entities;

namespace BlogFoodApi.Service
{
    public class PostService : IPostService
    {
        private readonly IPostDbRepository postDbRepository;
        private readonly IPostContentRepository postContentRepository;
        private IMapper mapper;

        public PostService(IPostDbRepository postDbRepository, IPostContentRepository postContentRepository, IMapper mapper)
        {
            this.postDbRepository = postDbRepository;
            this.postContentRepository = postContentRepository;
            this.mapper = mapper;
        }

        public void CreatePost(RequestPostViewModel requestPostViewModel)
        {
            var postContent = new PostContent
            {
                ContentPostID = Guid.NewGuid().ToString(),
                Content = requestPostViewModel.Content
            };

            postContentRepository.CreatePostContent(postContent);


            var post = new Post
            {
                PostContentID = postContent.ContentPostID,
                PostId = Guid.NewGuid().ToString(),
                Title = requestPostViewModel.Title,
                NameFood = requestPostViewModel.NameFood,
                UserId = requestPostViewModel.UserID,
                DatePosted = DateTime.Now

            };

            postDbRepository.CreatePosts(post);



        }

        public PostContent GetContent(string PostID)
        {
            var Content = postContentRepository.GetContent(PostID);

            return Content;
        }

        public List<TitleViewModel> titleViewModels()
        {
            var title = postDbRepository.GetAllTitle();

            var titleSameViewModel = mapper.Map<List<Post>, List<TitleViewModel>>(title);



            return titleSameViewModel;
        }
    }
}
