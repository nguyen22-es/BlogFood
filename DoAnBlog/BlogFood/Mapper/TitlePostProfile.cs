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
                .ForMember(dst => dst.NameFood, opt => opt.MapFrom(x => x.NameFood))
                .ForMember(dst => dst.Like, opt => opt.MapFrom(x => x.Likes))
                .ForMember(dst => dst.Thumbnail, opt => opt.MapFrom(x => x.Thumbnail))
             .ForMember(dst => dst.Rating, opt => opt.MapFrom(x => x.average != null ? (int)x.average : 0))
                .ForMember(dst => dst.Date, opt => opt.MapFrom(x => x.DatePosted.ToString("dd / MM / yy")));
            CreateMap<TitleViewModel, Post>();
        }
    }
}
