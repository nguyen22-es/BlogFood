using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;

namespace DataAccess.Data.Entities
{

    public partial class Follow
    {
        public string FollowId { get; set; }

        public string? FollowerId { get; set; }

        public string? FollowingId { get; set; }

        public virtual ManageUser? Follower { get; set; }

        public virtual ManageUser? Following { get; set; }
    }

}