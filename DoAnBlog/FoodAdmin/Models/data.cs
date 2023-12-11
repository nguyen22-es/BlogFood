namespace FoodAdminClient.Models
{
    public class ImgurData
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public long Datetime { get; set; }
        public string Type { get; set; }
        public bool Animated { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Size { get; set; }
        public int Views { get; set; }
        public int Bandwidth { get; set; }
        public object Vote { get; set; }
        public bool Favorite { get; set; }
        public object Nsfw { get; set; }
        public object Section { get; set; }
        public object AccountUrl { get; set; }
        public int AccountId { get; set; }
        public bool IsAd { get; set; }
        public bool InMostViral { get; set; }
        public bool HasSound { get; set; }
        public List<string> Tags { get; set; }
        public int AdType { get; set; }
        public string AdUrl { get; set; }
        public string Edited { get; set; }
        public bool InGallery { get; set; }
        public string Deletehash { get; set; }
        public string Name { get; set; }
        public string Link { get; set; }
    }

    public class ImgurApiResponse
    {
        public ImgurData Data { get; set; }
        public bool Success { get; set; }
        public int Status { get; set; }
    }
}
