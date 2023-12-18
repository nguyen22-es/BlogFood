﻿// <auto-generated />
using System;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Data.Migrations
{
    [DbContext(typeof(ManageAppDbContext))]
    partial class ManageAppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Data.Data.Entities.Comment", b =>
                {
                    b.Property<string>("CommentID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CommentFatherID")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Depth")
                        .HasColumnType("int");

                    b.Property<string>("PostID")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UserID")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("timeComment")
                        .HasColumnType("datetime2");

                    b.HasKey("CommentID");

                    b.HasIndex("PostID");

                    b.HasIndex("UserID");

                    b.ToTable("Comments", (string)null);
                });

            modelBuilder.Entity("Data.Data.Entities.FoodIngredient", b =>
                {
                    b.Property<string>("FoodID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CookingTime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostID")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("FoodID");

                    b.HasIndex("PostID")
                        .IsUnique();

                    b.ToTable("FoodIngredients", (string)null);
                });

            modelBuilder.Entity("Data.Data.Entities.Ingredients", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FoodIngredientId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("NameIngredient")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("FoodIngredientId");

                    b.ToTable("Ingredients", (string)null);
                });

            modelBuilder.Entity("Data.Data.Entities.PostContent", b =>
                {
                    b.Property<string>("ContentPostID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ContentPostID");

                    b.HasIndex("PostId")
                        .IsUnique();

                    b.ToTable("PostContents", (string)null);
                });

            modelBuilder.Entity("Data.Data.Entities.RatingPost", b =>
                {
                    b.Property<string>("PostId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("Evaluate")
                        .HasColumnType("int");

                    b.HasKey("PostId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("RatingPosts", (string)null);
                });

            modelBuilder.Entity("DataAccess.Data.Entities.Category", b =>
                {
                    b.Property<string>("CategoryId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FoodType")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories", (string)null);
                });

            modelBuilder.Entity("DataAccess.Data.Entities.Follow", b =>
                {
                    b.Property<string>("FollowerId")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FollowId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FollowingId")
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("FollowerId");

                    b.HasIndex("FollowingId");

                    b.ToTable("Follows", (string)null);
                });

            modelBuilder.Entity("DataAccess.Data.Entities.LikePost", b =>
                {
                    b.Property<string>("PostId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("PostId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("LikePosts", (string)null);
                });

            modelBuilder.Entity("DataAccess.Data.Entities.ManageUser", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DisplayName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<int?>("Followers")
                        .HasColumnType("int");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("DataAccess.Data.Entities.Post", b =>
                {
                    b.Property<string>("PostId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("DatePosted")
                        .HasColumnType("datetime2");

                    b.Property<int?>("Likes")
                        .HasColumnType("int");

                    b.Property<string>("NameFood")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Thumbnail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(50)");

                    b.Property<float?>("average")
                        .HasColumnType("real");

                    b.HasKey("PostId");

                    b.HasIndex("UserId");

                    b.ToTable("Posts", (string)null);
                });

            modelBuilder.Entity("DataAccess.Data.Entities.PostCategory", b =>
                {
                    b.Property<string>("LinkId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CategoryId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("PostId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LinkId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("PostId")
                        .IsUnique()
                        .HasFilter("[PostId] IS NOT NULL");

                    b.ToTable("PostCategories", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUserToken<string>");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("IdentityUserToken", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUserToken<string>");

                    b.Property<DateTime>("ExpiredAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("IDaccessTokenJwt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsRevoked")
                        .HasColumnType("bit");

                    b.Property<bool>("IsUsed")
                        .HasColumnType("bit");

                    b.Property<DateTime>("IssuedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("RefreshTokenExpiry")
                        .HasColumnType("datetime2");

                    b.HasDiscriminator().HasValue("IdentityUserToken");
                });

            modelBuilder.Entity("Data.Data.Entities.Comment", b =>
                {
                    b.HasOne("DataAccess.Data.Entities.Post", "Post")
                        .WithMany()
                        .HasForeignKey("PostID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataAccess.Data.Entities.ManageUser", "user")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Post");

                    b.Navigation("user");
                });

            modelBuilder.Entity("Data.Data.Entities.FoodIngredient", b =>
                {
                    b.HasOne("DataAccess.Data.Entities.Post", "Post")
                        .WithOne()
                        .HasForeignKey("Data.Data.Entities.FoodIngredient", "PostID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Post");
                });

            modelBuilder.Entity("Data.Data.Entities.Ingredients", b =>
                {
                    b.HasOne("Data.Data.Entities.FoodIngredient", "FoodIngredient")
                        .WithMany("Ingredients")
                        .HasForeignKey("FoodIngredientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FoodIngredient");
                });

            modelBuilder.Entity("Data.Data.Entities.PostContent", b =>
                {
                    b.HasOne("DataAccess.Data.Entities.Post", "Post")
                        .WithOne("PostContent")
                        .HasForeignKey("Data.Data.Entities.PostContent", "PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Post");
                });

            modelBuilder.Entity("Data.Data.Entities.RatingPost", b =>
                {
                    b.HasOne("DataAccess.Data.Entities.Post", "Post")
                        .WithMany("ratingPost")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataAccess.Data.Entities.ManageUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Post");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DataAccess.Data.Entities.Follow", b =>
                {
                    b.HasOne("DataAccess.Data.Entities.ManageUser", "Follower")
                        .WithMany("FollowFollowers")
                        .HasForeignKey("FollowerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("DataAccess.Data.Entities.ManageUser", "Following")
                        .WithMany("FollowFollowings")
                        .HasForeignKey("FollowingId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Follower");

                    b.Navigation("Following");
                });

            modelBuilder.Entity("DataAccess.Data.Entities.LikePost", b =>
                {
                    b.HasOne("DataAccess.Data.Entities.Post", "Post")
                        .WithMany()
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataAccess.Data.Entities.ManageUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Post");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DataAccess.Data.Entities.Post", b =>
                {
                    b.HasOne("DataAccess.Data.Entities.ManageUser", "User")
                        .WithMany("Posts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("User");
                });

            modelBuilder.Entity("DataAccess.Data.Entities.PostCategory", b =>
                {
                    b.HasOne("DataAccess.Data.Entities.Category", "Category")
                        .WithMany("PostCategories")
                        .HasForeignKey("CategoryId");

                    b.HasOne("DataAccess.Data.Entities.Post", "Post")
                        .WithOne("PostCategories")
                        .HasForeignKey("DataAccess.Data.Entities.PostCategory", "PostId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Category");

                    b.Navigation("Post");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("DataAccess.Data.Entities.ManageUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("DataAccess.Data.Entities.ManageUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataAccess.Data.Entities.ManageUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("DataAccess.Data.Entities.ManageUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Data.Data.Entities.FoodIngredient", b =>
                {
                    b.Navigation("Ingredients");
                });

            modelBuilder.Entity("DataAccess.Data.Entities.Category", b =>
                {
                    b.Navigation("PostCategories");
                });

            modelBuilder.Entity("DataAccess.Data.Entities.ManageUser", b =>
                {
                    b.Navigation("FollowFollowers");

                    b.Navigation("FollowFollowings");

                    b.Navigation("Posts");
                });

            modelBuilder.Entity("DataAccess.Data.Entities.Post", b =>
                {
                    b.Navigation("PostCategories")
                        .IsRequired();

                    b.Navigation("PostContent")
                        .IsRequired();

                    b.Navigation("ratingPost");
                });
#pragma warning restore 612, 618
        }
    }
}
