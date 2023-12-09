﻿using DataAccess;
using DataAccess.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Repository
{
    public class PostRepository : IPostDbRepository
    {
        private readonly ManageAppDbContext _manageAppDbContext;
        public PostRepository(ManageAppDbContext manageAppDbContext)
        {

            this._manageAppDbContext = manageAppDbContext;
        }

        public async Task CreatePosts(Post posts)
        {
            await  _manageAppDbContext.Posts.AddAsync(posts);
          await  _manageAppDbContext.SaveChangesAsync();

        }


        public List<Post> GetAllTitle()
        {
            var posts = _manageAppDbContext.Posts.Include(p => p.User).OrderByDescending(x => x.DatePosted).ToList();

            return posts;
        }

        public Post GetTitle(string PostID)
        {
            var posts = _manageAppDbContext.Posts.Include(c => c.User).FirstOrDefault(c => c.PostId == PostID);

            return posts;
        }

        public async Task UpdatePosts(Post posts)
        {
            var postSame = await _manageAppDbContext.Posts.FirstOrDefaultAsync(p => p.PostId == posts.PostId);

            postSame.Title = postSame.Title;
            postSame.NameFood = postSame.NameFood;

             _manageAppDbContext.Posts.Update(postSame);

        }

        async Task IPostDbRepository.DeletePosts(string id)
        {
            var posts = await _manageAppDbContext.Posts.FirstOrDefaultAsync(c => c.PostId == id);


             _manageAppDbContext.Posts.Remove(posts);
        }
    }
}
