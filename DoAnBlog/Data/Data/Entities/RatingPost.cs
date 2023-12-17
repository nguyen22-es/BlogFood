using DataAccess.Data.Entities;

namespace Data.Data.Entities
{
    public class RatingPost
    {
        public string? PostId { get; set; }

        public string? UserId { get; set; }
        public int? Evaluate { get; set; }
        public virtual Post? Post { get; set; }

        public virtual ManageUser? User { get; set; }
    }
}
