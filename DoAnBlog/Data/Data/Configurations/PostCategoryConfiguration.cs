﻿using DataAccess.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace DataAccess.Configurations
{
    public class PostCategoryConfiguration : IEntityTypeConfiguration<PostCategory>
    {
        public void Configure(EntityTypeBuilder<PostCategory> builder)
        {
            builder.ToTable("PostCategories"); 

            builder.HasKey(e => e.LinkId); 

            builder.Property(e => e.LinkId)
                .IsRequired(); 
           

            builder.Property(e => e.PostId)
                .IsRequired(false); 

            builder.Property(e => e.CategoryId)
                .IsRequired(false); 

           
            builder.HasOne(e => e.Post)
                .WithOne(e => e.PostCategories)
                .HasForeignKey<PostCategory>(e => e.PostId)
                  .OnDelete(DeleteBehavior.Cascade);
              

            builder.HasOne(e => e.Category)
                .WithMany(e => e.PostCategories)
                .HasForeignKey(e => e.CategoryId)
                .IsRequired(false);
        }
    }
}
