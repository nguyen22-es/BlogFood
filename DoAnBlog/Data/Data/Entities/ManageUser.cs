

using Data.Data.Entities;
using Microsoft.AspNetCore.Identity;

namespace DataAccess.Data.Entities
{
    public class ManageUser : IdentityUser
    {
   
        public string DisplayName { get; set; } = null!;

        public int? Followers { get; set; }

        public virtual ICollection<Follow> FollowFollowers { get; set; } = new List<Follow>();

        public virtual ICollection<Follow> FollowFollowings { get; set; } = new List<Follow>();

        public virtual ICollection<Post> Posts { get; set; } = new List<Post>();
       
    }
}
