using Data.Data.Entities;
using DataAccess;
using Microsoft.EntityFrameworkCore;

namespace BlogFoodApi.Repositories
{
    public class PostContentRepository : IPostContentRepository
    {
        private readonly ManageAppDbContext _manageAppDbContext;
        public PostContentRepository(ManageAppDbContext manageAppDbContext)
        {
            _manageAppDbContext = manageAppDbContext;
        }

        public PostContent CreatePostContent(PostContent postContent)
        {
            var post = _manageAppDbContext.postContents.Add(postContent);
            _manageAppDbContext.SaveChanges();

            return post.Entity;
        }

        public void DeletePostContent(PostContent postContent)
        {
            var postContents = _manageAppDbContext.postContents.FirstOrDefault(i => i.ContentPostID == postContent.ContentPostID);

            _manageAppDbContext.postContents.Remove(postContents);
        }

        public PostContent GetContent(string PostID)
        {
            var postContents = _manageAppDbContext.postContents.FirstOrDefault(i => i.PostId == PostID);

            return postContents;
        }

        public async Task UpdatePostContent(string postContent, string ID)
        {
            var postContents = await _manageAppDbContext.postContents.FirstOrDefaultAsync(i => i.ContentPostID == ID);

            postContents.Content = postContent;

            _manageAppDbContext.postContents.Update(postContents);
          await _manageAppDbContext.SaveChangesAsync();



        }
    }
}
