using AutoMapper;
using BlogFoodApi.ViewModel;
using Data.Data.Entities;
using DataAccess.Helpers;

namespace BlogFoodApi.Mapper
{
    public class CommentProfile : Profile
    {
        public CommentProfile()
        { // test
            CreateMap<Comment, CommentViewModel>()
                .ForMember(dst => dst.CommentID, opt => opt.MapFrom(x => x.CommentID))
                .ForMember(dst => dst.nameComment, opt => opt.MapFrom(x => x.user.DisplayName))
                .ForMember(dst => dst.Depth, opt => opt.MapFrom(x => x.Depth))
                .ForMember(dst => dst.Content, opt => opt.MapFrom(x => x.Content))
                .ForMember(dst => dst.CoutChild, opt => opt.MapFrom(x => x.CoutChild))
                .ForMember(dst => dst.CommentParentsID, opt => opt.MapFrom(x => x.CommentFatherID == null ? "0" : x.CommentFatherID))
                .ForMember(dst => dst.TimeComment, opt => opt.MapFrom(x => x.timeComment.ToString("dd / MM / yy")));
            CreateMap<CommentViewModel, Comment>();
        }

    }
}
