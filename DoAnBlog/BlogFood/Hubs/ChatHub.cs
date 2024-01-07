
using API.Repository;
using AutoMapper;
using BlogFoodApi.ViewModel;
using Data.Data.Entities;
using DataAccess.Data.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;


namespace API.SignalrHub
{


    public class ChatHub : Hub
    {
        public readonly static List<UserViewModel> _Connections = new List<UserViewModel>();
        private readonly static Dictionary<string, string> _ConnectionsMap = new Dictionary<string, string>();
        private readonly IMapper _mapper;
        public readonly UserManager<ManageUser> _userManager;
        public readonly ICommentsDbRepository commentsDbRepository;
        public ChatHub(UserManager<ManageUser> userManager, ICommentsDbRepository commentsDbRepository,IMapper mappe)
        {
            this.commentsDbRepository = commentsDbRepository;
            _userManager = userManager;
            _mapper = mappe;

        }

        public async Task creatCommentt(string conten,string PostID,int depth,string CommentFatherID,string UserId)
        {
            
            var comment = new Comment
            {
                CommentID = Guid.NewGuid().ToString(),
                timeComment = DateTime.Now,
                CommentFatherID = CommentFatherID == "0" ? null: CommentFatherID,
                Content = conten,
                PostID = PostID,
                Depth = depth,
                UserID = UserId

            };

         var Comment = await  commentsDbRepository.CreateCommentAsync(comment);

          var commentView = _mapper.Map<Comment,CommentViewModel>(Comment);

            await Clients.All.SendAsync("newComment", commentView);
        }
        public override async Task OnConnectedAsync()
        {
           

         await Clients.Caller.SendAsync("getProfileInfo");
                   
            await base.OnConnectedAsync();
        }


     }
}
