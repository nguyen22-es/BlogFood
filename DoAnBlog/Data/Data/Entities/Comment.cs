using DataAccess.Data.Entities;

namespace Data.Data.Entities
{
    public class Comment
    {
        public  string CommentID { get; set; }
        public string Content { get; set; }

        public string UserID { get; set; }

        public string PostID { get; set; }
        public DateTime timeComment { get;set; }

        public int Depth { get; set; }

        public string CommentFatherID { get; set; }

        public ManageUser user { get; set; }

        public Post Post { get;set; }


    }
}
