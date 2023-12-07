using Microsoft.AspNetCore.Identity;

namespace Data.Data.Entities
{
    public class managerToken 
    {
        public bool IsUsed { get; set; }
        public bool IsRevoked { get; set; }
        public DateTime IssuedAt { get; set; }
        public DateTime ExpiredAt { get; set; }
    }
}





