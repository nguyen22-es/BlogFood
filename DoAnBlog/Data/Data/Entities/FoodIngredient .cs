using DataAccess.Data.Entities;

namespace Data.Data.Entities
{
    public class FoodIngredient
    {
        public string FoodID { get; set; }

        public string CookingTime { get; set; }

        public string PostID { get; set; }

        public List<Ingredients> Ingredients { get; set;}

        public Post Post { get; set; } 


    }
}
