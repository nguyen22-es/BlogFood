using DataAccess.Data.Entities;

namespace Data.Data.Entities
{
    public class PostContent
    {
        public string ContentPostID { get; set; }

        public string PostId { get; set; }
        public string? Content { get; set; }

        public Post Post { get; set; }
      
   
    }
}
