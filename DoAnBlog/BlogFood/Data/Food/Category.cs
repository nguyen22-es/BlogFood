using System;
using System.Collections.Generic;

namespace BlogFoodApi.Data.Food;

public partial class Category
{
    public int CategoryId { get; set; }

    public string FoodType { get; set; } = null!;

    public virtual ICollection<PostCategory> PostCategories { get; set; } = new List<PostCategory>();
}
