namespace BlogFoodApi.ViewModel
{
    public class CommentViewModel
    {
        public string CommentID { get; set; }
        public string Content { get; set; }
        public int Depth { get; set; }
        public string nameComment { get; set; }

        public string TimeComment { get; set; }

        public string CommentParentsID { get; set; }

    }
}
