

using DataAccess.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace DataAccess.Configurations
{
    public class FlollowConfiguration : IEntityTypeConfiguration<Follow>
    {
        public void Configure(EntityTypeBuilder<Follow> builder)
        {
            builder.ToTable("Follows"); 
            builder.HasKey(f => f.FollowerId); 

            builder.Property(f => f.FollowerId)
                .IsRequired();


            builder.Property(f => f.FollowerId)
                .IsRequired();
                


            builder.HasOne(f => f.Follower)
           .WithMany(f => f.FollowFollowers)
           .HasForeignKey(f => f.FollowerId)
           .OnDelete(DeleteBehavior.NoAction);

           
               builder.HasOne(f => f.Following)
              .WithMany(f => f.FollowFollowings)
              .HasForeignKey(f => f.FollowingId)
              .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
