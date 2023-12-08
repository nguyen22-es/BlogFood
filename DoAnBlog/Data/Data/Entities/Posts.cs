﻿
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

        public string Title { get; set; } 

        public string PostContentID { get; set; } 

        public DateTime DatePosted { get; set; } 

        public int? Likes { get; set; }

        public virtual ICollection<PostCategory> PostCategories { get; set; } = new List<PostCategory>();
        public virtual PostContent PostContent { get; set; }
        public  ManageUser? User { get; set; }

       
    }
}
