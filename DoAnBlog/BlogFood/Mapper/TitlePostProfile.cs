using AutoMapper;
using BlogFoodApi.ViewModel;
using Data.Data.Entities;
using DataAccess.Data.Entities;

namespace BlogFoodApi.Mapper
{
    public class TitlePostProfile:Profile
    {
        public TitlePostProfile()
        { // test
            CreateMap<Post, TitleViewModel>()
                .ForMember(dst => dst.PostID, opt => opt.MapFrom(x => x.PostId))
                .ForMember(dst => dst.NameWrite, opt => opt.MapFrom(x => x.User.DisplayName))
                .ForMember(dst => dst.Title, opt => opt.MapFrom(x => x.Title))
                .ForMember(dst => dst.NameFood, opt => opt.MapFrom(x => x.NameFood))
                .ForMember(dst => dst.Like, opt => opt.MapFrom(x => x.Likes))
                .ForMember(dst => dst.contenID, opt => opt.MapFrom(x => x.PostContentID))
                .ForMember(dst => dst.Date, opt => opt.MapFrom(x => x.DatePosted.ToString("dd / MM / yy")));
            CreateMap<TitleViewModel, Post>();
        }
    }
}
