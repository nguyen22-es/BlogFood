using System;
using System.Collections.Generic;

namespace BlogFoodApi.Data.Food;

public partial class LikePost
{
    public string? LikePostId { get; set; }

    public int? PostId { get; set; }

    public int? UserId { get; set; }

    public virtual Post? Post { get; set; }

    public virtual User? User { get; set; }
}
