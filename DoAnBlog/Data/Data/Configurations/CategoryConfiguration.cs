
using DataAccess.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace DataAccess.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories"); 
            builder.HasKey(c => c.CategoryId); 

            builder.Property(c => c.CategoryId)
                .IsRequired();

            builder.Property(c => c.FoodType)
                .IsRequired()
                .HasMaxLength(150);



            // Cấu hình liên kết đến bài viết (Post)
            builder.HasMany(c => c.PostCategories) 
                .WithOne() 
                .HasForeignKey(pc => pc.CategoryId);


        }
    }
}
