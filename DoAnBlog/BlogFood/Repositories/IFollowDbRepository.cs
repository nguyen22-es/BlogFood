

namespace API.Repository
{
    public interface IFollowDbRepository
    {

        void CreatFollow(string Follower ,string Following);
 
        void DeleteFollow(string Follower, string Following);
        bool IsFollow(string Follower, string Following);



    }
}
