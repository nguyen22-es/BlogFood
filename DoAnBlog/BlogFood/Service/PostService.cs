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
        private readonly IPostCategoryRepository  category;
        private readonly IPostContentRepository postContentRepository;
        private IMapper mapper;

        public PostService(IPostCategoryRepository category,IPostDbRepository postDbRepository, IPostContentRepository postContentRepository, IMapper mapper)
        {
            this.postDbRepository = postDbRepository;
            this.postContentRepository = postContentRepository;
            this.mapper = mapper;
            this.category = category;
        }

  

        public async Task CreatePost(RequestPostViewModel requestPostViewModel,string UserID)
        {


            var post = new Post
            {

                PostId = Guid.NewGuid().ToString(),
                NameFood = requestPostViewModel.Title.NameFood,             
                UserId = UserID,
                Likes = 0,
                DatePosted = DateTime.Now,
                Thumbnail = requestPostViewModel.Title.Thumbnail,
                Description = requestPostViewModel.Title.Description,
                IsPosted = false

            };

           await postDbRepository.CreatePosts(post);

            var postContent = new PostContent
            {
                ContentPostID = Guid.NewGuid().ToString(),
                Content = requestPostViewModel.Content,
                PostId = post.PostId,
                
            };

            await postContentRepository.CreatePostContent(postContent);

            var PostCategory = new PostCategory {LinkId = Guid.NewGuid().ToString(), CategoryId = requestPostViewModel.category,PostId = post.PostId };
             await category.CreateCategory(PostCategory);

            var Food = new FoodIngredient {FoodID = Guid.NewGuid().ToString(), PostID = post.PostId, CookingTime = requestPostViewModel.CookingTime };
            await postContentRepository.CreateFood(Food);


            foreach (var item in requestPostViewModel.Ingredients)
            {
                await postContentRepository.CreateIngredient(new Ingredients { NameIngredient = item,ID = Guid.NewGuid().ToString() , FoodIngredientId = Food.FoodID});
            }


        }

        public async Task DeletePost(string PostID)
        {
             await  postDbRepository.DeletePosts(PostID);
        }

        public RequestPostViewModel GetContent(string PostID)
        {
            var Content = postContentRepository.GetContent(PostID);
            var title = postDbRepository.GetTitle(PostID);
            var Food = postDbRepository.GetFood(PostID);
            var Ingredients = new List<string>();
            foreach (var item in Food.Ingredients)
            {

                Ingredients.Add(item.NameIngredient);
            }

            var titleViewModel = mapper.Map<Post, TitleViewModel>(title);
         
            var Request = new RequestPostViewModel { 
                Title = titleViewModel,
                Content = Content.Content,
                CookingTime = Food.CookingTime,
                Ingredients = Ingredients,
                category = title.PostCategories.Category.FoodType

            };

          

            return Request;
        }

        public List<TitleViewModel> PostTrue()
        {
            var title = postDbRepository.GetPostTrueTitle();

            var titleSameViewModel = mapper.Map<List<Post>, List<TitleViewModel>>(title);



            return titleSameViewModel;
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
              /*  PostId  = requestPostViewModel.PostId,
                UserId  = requestPostViewModel.UserID,

                FoodID = requestPostViewModel.NameFood,

                NameFood =requestPostViewModel.Title,*/
             };


            await postDbRepository.UpdatePosts(Post);


         //    await    postContentRepository.UpdatePostContent(requestPostViewModel.PostId, requestPostViewModel.Content);
        }
    }
}
