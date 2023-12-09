using API.Repository;
using AutoMapper;
using BlogFoodApi.Repositories;
using BlogFoodApi.ViewModel;
using Data.Data.Entities;
using DataAccess.Data.Entities;
using Microsoft.AspNetCore.Mvc;

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

        public async Task CreatePost(RequestPostViewModel requestPostViewModel)
        {


            var post = new Post
            {

                PostId = Guid.NewGuid().ToString(),
                Title = requestPostViewModel.Title,
                NameFood = requestPostViewModel.NameFood,
                UserId = requestPostViewModel.UserID,
                DatePosted = DateTime.Now

            };

           await postDbRepository.CreatePosts(post);


            var postContent = new PostContent
            {
                ContentPostID = Guid.NewGuid().ToString(),
                Content = requestPostViewModel.Content,
                PostId = post.PostId,
                
            };

            postContentRepository.CreatePostContent(postContent);
         
        }

        public async Task DeletePost(string PostID)
        {
             await  postDbRepository.DeletePosts(PostID);
        }

        public RequestPostViewModel GetContent(string PostID)
        {
            var Content = postContentRepository.GetContent(PostID);
            var title = postDbRepository.GetTitle(PostID);
            var Request = new RequestPostViewModel { 
            
            Content = Content.Content,
            Date = title.DatePosted.ToString("G"),
            NameFood = title.NameFood,
            UserID = title.UserId,
            Title = title.Title,
            NameUser = title.User.DisplayName,
            PostId = title.PostId
            };

          

            return Request;
        }

        public List<TitleViewModel> titleViewModels()
        {
            var title = postDbRepository.GetAllTitle();

            var titleSameViewModel = mapper.Map<List<Post>, List<TitleViewModel>>(title);



            return titleSameViewModel;
        }

        public async Task UpdatePost([FromBody] RequestPostViewModel requestPostViewModel)
        {
            var Post = new Post
            {
                PostId  = requestPostViewModel.PostId,
                UserId  = requestPostViewModel.UserID,

                NameFood = requestPostViewModel.NameFood,

                Title =requestPostViewModel.Title,
             };


            await postDbRepository.UpdatePosts(Post);


             await    postContentRepository.UpdatePostContent(requestPostViewModel.PostId, requestPostViewModel.Content);
        }
    }
}
