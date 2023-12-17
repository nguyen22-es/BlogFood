namespace Data.Data.Entities
{
    public class Ingredients
    {
        public string ID { get; set; }

        public string NameIngredient { get; set; }

        public string FoodIngredientId { get;set; }

        public FoodIngredient FoodIngredient { get; set; }

    }
}
