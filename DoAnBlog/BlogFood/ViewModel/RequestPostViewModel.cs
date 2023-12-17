using Data.Data.Entities;

namespace BlogFoodApi.ViewModel
{
    public class RequestPostViewModel
    {
       public TitleViewModel Title { get; set; }

        public string category { get; set; }
       public string Content { get; set; }

        public string CookingTime { get; set; }

        public List<string> Ingredients { get; set; }   

    }
}
