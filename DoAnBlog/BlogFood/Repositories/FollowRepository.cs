using DataAccess;
using DataAccess.Data.Entities;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;


namespace API.Repository
{
    public class FollowRepository:IFollowDbRepository
    {
        private readonly ManageAppDbContext _manageAppDbContext;
        public FollowRepository(ManageAppDbContext manageAppDbContext)
        {

            this._manageAppDbContext = manageAppDbContext;
        }

        public void CreatFollow(string Follower, string Following)
        {
            var up = new Follow
            {
                FollowId =  Guid.NewGuid().ToString(),
                FollowerId = Follower,
                FollowingId = Following,

            };


            _manageAppDbContext.Add(up);
            _manageAppDbContext.SaveChanges();

          
        }

        public void DeleteFollow(string Follower, string Following)
        {
            var down = _manageAppDbContext.follows.FirstOrDefault(c => c.FollowerId == Follower || c.FollowerId == Following);

            _manageAppDbContext.follows.Remove(down);

        }
    }
}
