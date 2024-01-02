using API.Repository;
using DataAccess.Data.Entities;

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

        public bool IsFollow(string Follower, string Following)
        {
            var IsFollow = followDbRepository.IsFollow(Follower, Following);
            return IsFollow;
        }

        public void UnFollow(string Follower, string Following)
        {
            followDbRepository.DeleteFollow(Follower, Following);
        }
    }
}
