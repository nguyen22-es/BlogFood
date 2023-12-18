
using Data.Data.Entities;
using System;
using System.Collections.Generic;

namespace DataAccess.Data.Entities
{

    public partial class Post
    {
        public string PostId { get; set; }

        public string? UserId { get; set; }

        public string NameFood { get; set; } 

        public DateTime DatePosted { get; set; } 

        public float? average { get; set; }

        public int? Likes { get; set; }

        public string Thumbnail { get; set; }


        public virtual ICollection<RatingPost> ratingPost { get; set; }
        public virtual PostCategory PostCategories { get; set; }
        public virtual PostContent PostContent { get; set; }
        public  ManageUser? User { get; set; }

       
    }
}
