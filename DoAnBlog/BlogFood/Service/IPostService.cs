using BlogFoodApi.ViewModel;
using Data.Data.Entities;
using DataAccess.Data.Entities;

namespace BlogFoodApi.Service
{
    public interface IPostService
    {
        List<TitleViewModel> titleViewModels();

        PostContent GetContent(string PostID);
        void CreatePost(RequestPostViewModel requestPostViewModel);
    }
}
