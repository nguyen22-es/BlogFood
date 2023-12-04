using System;
using System.Collections.Generic;

namespace BlogFoodApi.Data.Food;

public partial class PostCategory
{
    public int LinkId { get; set; }

    public int? PostId { get; set; }

    public int? CategoryId { get; set; }

    public virtual Category? Category { get; set; }

    public virtual Post? Post { get; set; }
}
