using System;
using System.Collections.Generic;



namespace DataAccess.Data.Entities
{

    public partial class Category
    {
        public string CategoryId { get; set; }

        public string FoodType { get; set; } = null!;

        public virtual ICollection<PostCategory> PostCategories { get; set; } = new List<PostCategory>();
    }
}
