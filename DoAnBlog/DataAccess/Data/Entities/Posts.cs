using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;

namespace DataAccess.Data.Entities
{

    public partial class Post
    {
        public string PostId { get; set; }

        public string? UserId { get; set; }

        public string NameFood { get; set; }

        public string Title { get; set; } = null!;

        public string RecipesId { get; set; } = null!;

        public DateTime DatePosted { get; set; } 

        public int? Likes { get; set; }

        public virtual ICollection<PostCategory> PostCategories { get; set; } = new List<PostCategory>();

        public virtual ManageUser? User { get; set; }

        public virtual Recipes Recipes { get; set; }
    }
}
