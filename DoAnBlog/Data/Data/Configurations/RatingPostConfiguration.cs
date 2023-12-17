using DataAccess.Data.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Data.Data.Entities;

namespace Data.Data.Configurations
{
    public class RatingPostConfiguration: IEntityTypeConfiguration<RatingPost>
    {
        public void Configure(EntityTypeBuilder<RatingPost> builder)
    {
        builder.ToTable("RatingPosts");
        builder.HasKey(lp => new { lp.PostId, lp.UserId });

           
            builder.Property(p => p.Evaluate)
                   .IsRequired(false);

            builder.HasOne(lp => lp.Post)
            .WithMany(n => n.ratingPost)
            .HasForeignKey(lp => lp.PostId)
             .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(lp => lp.User)
            .WithMany()
            .HasForeignKey(lp => lp.UserId)
             .OnDelete(DeleteBehavior.NoAction);

    }
    

    }
}
