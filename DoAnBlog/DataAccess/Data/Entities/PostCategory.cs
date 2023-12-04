
using System;
using System.Collections.Generic;

namespace DataAccess.Data.Entities
{

    public partial class PostCategory
    {
        public string LinkId { get; set; }

        public string? PostId { get; set; }

        public string? CategoryId { get; set; }

        public virtual Category? Category { get; set; }

        public virtual Post? Post { get; set; }
    }
}
