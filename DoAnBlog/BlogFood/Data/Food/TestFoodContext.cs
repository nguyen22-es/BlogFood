using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BlogFoodApi.Data.Food;

public partial class TestFoodContext : DbContext
{
    public TestFoodContext()
    {
    }

    public TestFoodContext(DbContextOptions<TestFoodContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Follow> Follows { get; set; }

    public virtual DbSet<LikePost> LikePosts { get; set; }

    public virtual DbSet<Post> Posts { get; set; }

    public virtual DbSet<PostCategory> PostCategories { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=sonzsz;Initial Catalog=TestFood;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__Categori__19093A2B1DA3E680");

            entity.Property(e => e.CategoryId)
                .ValueGeneratedNever()
                .HasColumnName("CategoryID");
            entity.Property(e => e.FoodType)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Follow>(entity =>
        {
            entity.HasKey(e => e.FollowId).HasName("PK__Follows__2CE8108EAC93C738");

            entity.ToTable(tb =>
                {
                    tb.HasTrigger("decrement_followers");
                    tb.HasTrigger("increment_followers");
                });

            entity.Property(e => e.FollowId)
                .ValueGeneratedNever()
                .HasColumnName("FollowID");
            entity.Property(e => e.FollowerId).HasColumnName("FollowerID");
            entity.Property(e => e.FollowingId).HasColumnName("FollowingID");

            entity.HasOne(d => d.Follower).WithMany(p => p.FollowFollowers)
                .HasForeignKey(d => d.FollowerId)
                .HasConstraintName("FK__Follows__Followe__5535A963");

            entity.HasOne(d => d.Following).WithMany(p => p.FollowFollowings)
                .HasForeignKey(d => d.FollowingId)
                .HasConstraintName("FK__Follows__Followi__5629CD9C");
        });

        modelBuilder.Entity<LikePost>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Like_Post");

            entity.Property(e => e.LikePostId)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("LikePostID");
            entity.Property(e => e.PostId).HasColumnName("PostID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Post).WithMany()
                .HasForeignKey(d => d.PostId)
                .HasConstraintName("FK_Like_Post_Posts");

            entity.HasOne(d => d.User).WithMany()
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_Like_Post_Users");
        });

        modelBuilder.Entity<Post>(entity =>
        {
            entity.HasKey(e => e.PostId).HasName("PK__Posts__AA12603863C52FEE");

            entity.Property(e => e.PostId)
                .ValueGeneratedNever()
                .HasColumnName("PostID");
            entity.Property(e => e.Content).HasColumnType("text");
            entity.Property(e => e.DatePosted)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.Likes).HasDefaultValueSql("((0))");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.Posts)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Posts__UserID__4AB81AF0");
        });

        modelBuilder.Entity<PostCategory>(entity =>
        {
            entity.HasKey(e => e.LinkId).HasName("PK__Post_Cat__2D122155A4BE6716");

            entity.ToTable("Post_Category");

            entity.Property(e => e.LinkId)
                .ValueGeneratedNever()
                .HasColumnName("LinkID");
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.PostId).HasColumnName("PostID");

            entity.HasOne(d => d.Category).WithMany(p => p.PostCategories)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK__Post_Cate__Categ__4F7CD00D");

            entity.HasOne(d => d.Post).WithMany(p => p.PostCategories)
                .HasForeignKey(d => d.PostId)
                .HasConstraintName("FK__Post_Cate__PostI__4E88ABD4");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CCACDAA06D86");

            entity.HasIndex(e => e.Username, "UQ__Users__536C85E4DB43E860").IsUnique();

            entity.Property(e => e.UserId)
                .ValueGeneratedNever()
                .HasColumnName("UserID");
            entity.Property(e => e.DisplayName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Followers).HasDefaultValueSql("((0))");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
