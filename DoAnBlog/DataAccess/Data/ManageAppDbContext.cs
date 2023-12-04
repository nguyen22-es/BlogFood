
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using DataAccess.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ManageAppDbContext:IdentityDbContext<ManageUser>
    {
        public ManageAppDbContext(DbContextOptions options) : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<IdentityRole>().Property(x => x.Id).HasMaxLength(50).IsRequired(true);
            builder.Entity<ManageUser>().Property(x => x.Id).HasMaxLength(50).IsRequired(true);

            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }


       public DbSet<ManageUser> ManageUsers { get; set; }
        public DbSet<Follow>   follows { get; set; }
        public DbSet<LikePost>  likePosts { get; set; }
        public DbSet<Post>  Posts { get; set; }
        public DbSet<Category>  categories { get; set; }
        public DbSet<PostCategory>  postCategories { get; set;}



    }
}
