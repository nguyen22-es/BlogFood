using System;
using System.Collections.Generic;

namespace BlogFoodApi.Data.Food;

public partial class User
{
    public int UserId { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string DisplayName { get; set; } = null!;

    public int? Followers { get; set; }

    public virtual ICollection<Follow> FollowFollowers { get; set; } = new List<Follow>();

    public virtual ICollection<Follow> FollowFollowings { get; set; } = new List<Follow>();

    public virtual ICollection<Post> Posts { get; set; } = new List<Post>();
}
