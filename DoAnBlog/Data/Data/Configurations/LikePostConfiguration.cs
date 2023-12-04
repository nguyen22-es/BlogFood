using DataAccess.Entities;
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
            builder.ToTable("Messages"); // Đặt tên bảng là "Messages"
            builder.HasKey(m => m.MessageID);

            builder.Property(m => m.MessageID)
                .ValueGeneratedOnAdd();

            builder.Property(m => m.TimeSend)
                .IsRequired();

            builder.HasOne(m => m.FromUser)
                .WithMany(u => u.Messages)
                .HasForeignKey(m => m.SenderUserID)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(m => m.privateChatRoom)
                .WithMany(c => c.Messages)
                .HasForeignKey(m => m.RoomID)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
