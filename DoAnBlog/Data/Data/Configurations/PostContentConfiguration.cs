using Data.Data.Entities;
using DataAccess.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Data.Configurations
{
    public class PostContentConfiguration : IEntityTypeConfiguration<PostContent>
    {
        public void Configure(EntityTypeBuilder<PostContent> builder)
        {
            builder.ToTable("PostContents");

            builder.HasKey(e => e.ContentPostID);

            builder.Property(e => e.PostId)
                .IsRequired();


            builder.Property(e => e.Content)
                .IsRequired(false);


            builder.HasOne(e => e.Post)
                .WithMany()
                .HasForeignKey(e => e.PostId)
                .IsRequired(false);

        }
    }
}
