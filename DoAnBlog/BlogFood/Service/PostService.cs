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
        private readonly IPostContentRepository postContentRepository ;
        private IMapper mapper;

        public PostService(IPostDbRepository postDbRepository, IPostContentRepository postContentRepository, IMapper mapper)
        {
            this.postDbRepository = postDbRepository;
            this.postContentRepository = postContentRepository;
            this.mapper = mapper;
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
