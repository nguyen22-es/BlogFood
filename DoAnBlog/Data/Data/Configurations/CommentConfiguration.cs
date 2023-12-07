
using Data.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

public class CommentConfiguration : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.ToTable("Comments");
        builder.HasKey(r => r.CommentID);

        builder.HasOne(r => r.user)
            .WithMany()
            .HasForeignKey(r => r.UserID)
              .OnDelete(DeleteBehavior.NoAction);

        builder.Property(c => c.Content)
            .IsRequired();

        builder.Property(c => c.PostID)
            .IsRequired();
           
        builder.Property(c => c.UserID)
           .IsRequired();
           
        builder.Property(c => c.Depth)
     .IsRequired();

        builder.Property(c => c.CommentFatherID)
    .IsRequired();


        builder.HasOne(r => r.Post)
          .WithMany()
          .HasForeignKey(r => r.PostID)
            .OnDelete(DeleteBehavior.NoAction);
        builder.HasOne(r => r.user)
         .WithMany()
         .HasForeignKey(r => r.UserID)
           .OnDelete(DeleteBehavior.NoAction);
    }
}