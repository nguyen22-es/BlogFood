
using BlogFoodApi.ViewModel;
using DataAccess.Data.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;


namespace API.SignalrHub
{

    [Authorize]
    public class ChatHub : Hub
    {
        public readonly static List<UserViewModel> _Connections = new List<UserViewModel>();
        private readonly static Dictionary<string, string> _ConnectionsMap = new Dictionary<string, string>();
        private readonly UserManager<ManageUser> _userManager;
        public ChatHub(UserManager<ManageUser> userManager)
        {

            _userManager = userManager;
        }

        public async Task TestMe(string someRandomText)
        {
          
        }
        public override async Task OnConnectedAsync()
        {
            await Clients.All.SendAsync("getProfileInfo", "khong cos");
            try
            {
                if (Context.User.Identity.IsAuthenticated)
                {
                    var user = await _userManager.GetUserAsync(Context.User);

                    var userViewModel = new UserViewModel
                    {
                        DisplayName = user.DisplayName,
                        UserName = user.UserName

                    };

                    if (user != null)
                    {
                        
                      

                        if (!_Connections.Any(u => u.UserName == user.UserName) && !_ConnectionsMap.Any(u => u.Key == user.Id))
                        {
                            _Connections.Add(userViewModel);
                            _ConnectionsMap.Add(user.Id, Context.ConnectionId);
                        }

                        await Clients.Caller.SendAsync("getProfileInfo",  user.DisplayName, user.Id);
                    }
                    else
                    {
                        await Clients.Caller.SendAsync("onError", "User not found");
                    }
                }
                else
                {
                    await Clients.Caller.SendAsync("onError", "User not authenticated");
                    // Handle the case where the user is not authenticated
                }
            }
            catch (Exception ex)
            {
                await Clients.Caller.SendAsync("onError", "OnConnected:" + ex.Message);
            }

            await base.OnConnectedAsync();
        }
        private string GetDevice()
         {
             var device = Context.GetHttpContext().Request.Headers["Device"].ToString();
             if (!string.IsNullOrEmpty(device) && (device.Equals("Desktop") || device.Equals("Mobile")))
                 return device;

             return "Web";
         }

     }
}
