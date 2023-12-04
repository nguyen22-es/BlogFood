using System;
using System.Collections.Generic;

namespace BlogFoodApi.Data.Food;

public partial class Follow
{
    public int FollowId { get; set; }

    public int? FollowerId { get; set; }

    public int? FollowingId { get; set; }

    public virtual User? Follower { get; set; }

    public virtual User? Following { get; set; }
}
