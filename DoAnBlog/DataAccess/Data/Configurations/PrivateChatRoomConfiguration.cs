using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialNetworking.Data.Entities;
using System;

public class PrivateChatRoomConfiguration : IEntityTypeConfiguration<PostCategory>
{
    public void Configure(EntityTypeBuilder<PostCategory> builder)
    {
        builder.HasKey(r => r.RoomID);

        builder.HasOne(r => r.User1)
            .WithMany()
            .HasForeignKey(r => r.IDuser1)
              .OnDelete(DeleteBehavior.NoAction);
     

        builder.HasOne(r => r.User2)
            .WithMany()
            .HasForeignKey(r => r.IDuser2)
              .OnDelete(DeleteBehavior.NoAction);
          

        builder.HasMany(r => r.Messages)
            .WithOne(m => m.privateChatRoom)
            .HasForeignKey(m => m.RoomID)
            .OnDelete(DeleteBehavior.Cascade);
    }
}