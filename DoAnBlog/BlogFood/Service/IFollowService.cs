namespace BlogFoodApi.Service
{
    public interface IFollowService
    {
        void Follow(string Follower,string Following);
        void UnFollow(string Follower, string Following);
    }
}
