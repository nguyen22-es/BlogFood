using BlogFoodApi.ViewModel;
using Data.Data.Entities;
using DataAccess.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BlogFoodApi.Service
{
    public interface IPostService
    {
        List<TitleViewModel> titleViewModels();

        List<TitleViewModel> GetPostUser(string UserID);

        List<TitleViewModel> PostTrue();
        RequestPostViewModel GetContent(string PostID);
        Task CreatePost(RequestPostViewModel requestPostViewModel, string UserID);

        Task UpdatePost([FromBody] RequestPostViewModel requestPostViewModel);

        Task DeletePost(string PostID);
    }
}
