using DataAccess.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.ToTable("Posts"); 

            builder.HasKey(p => p.PostId); 

            builder.Property(p => p.PostId)
                .IsRequired(); 

            builder.Property(p => p.UserId)
                .IsRequired(false); 

            builder.Property(p => p.NameFood)
                .IsRequired(); 

            builder.Property(p => p.Title)
                .IsRequired(); 


            builder.Property(p => p.DatePosted)
                .IsRequired(); 

            builder.Property(p => p.Likes)
                .IsRequired(false);


            builder.HasOne(p => p.User)
                .WithMany(u => u.Posts)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Cascade);
               

            /* modelBuilder.Entity<Post>()
        .HasOne(p => p.User)         // Một bài post thuộc về một người dùng
        .WithMany(u => u.Posts)      // Một người dùng có thể có nhiều bài post
        .HasForeignKey(p => p.UserId)
        .OnDelete(DeleteBehavior.Cascade); */


 
        }
    }
}