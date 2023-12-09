
using DataAccess.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace DataAccess.Configurations
{
    public class LikePostConfiguration : IEntityTypeConfiguration<LikePost>
    {
        public void Configure(EntityTypeBuilder<LikePost> builder)
        {
            builder.ToTable("LikePosts");
            builder.HasKey(lp => new { lp.PostId, lp.UserId });

            // Các cấu hình khác...

            builder.HasOne(lp => lp.Post)
                .WithMany()
                .HasForeignKey(lp => lp.PostId)
                 .OnDelete(DeleteBehavior.Cascade); 

            builder.HasOne(lp => lp.User)
                .WithMany()
                .HasForeignKey(lp => lp.UserId)
                 .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
