using System;
using System.Collections.Generic;

namespace BlogFoodApi.Data.Food;

public partial class Post
{
    public int PostId { get; set; }

    public int? UserId { get; set; }

    public string Title { get; set; } = null!;

    public string Content { get; set; } = null!;

    public byte[] DatePosted { get; set; } = null!;

    public int? Likes { get; set; }

    public virtual ICollection<PostCategory> PostCategories { get; set; } = new List<PostCategory>();

    public virtual User? User { get; set; }
}
