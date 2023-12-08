using API.Repository;

namespace BlogFoodApi.Service
{
    public class FollowService : IFollowService
    {
        private readonly IFollowDbRepository followDbRepository;

        public FollowService(IFollowDbRepository followDbRepository)
        {
            this.followDbRepository = followDbRepository;
        }

        public void Follow(string Follower, string Following)
        {
            followDbRepository.CreatFollow(Follower, Following);
        }

        public void UnFollow(string Follower, string Following)
        {
            followDbRepository.DeleteFollow(Follower, Following);
        }
    }
}
