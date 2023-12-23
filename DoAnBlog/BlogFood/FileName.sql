IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [AspNetRoles] (
    [Id] nvarchar(50) NOT NULL,
    [Name] nvarchar(256) NULL,
    [NormalizedName] nvarchar(256) NULL,
    [ConcurrencyStamp] nvarchar(max) NULL,
    CONSTRAINT [PK_AspNetRoles] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [AspNetUsers] (
    [Id] nvarchar(50) NOT NULL,
    [DisplayName] nvarchar(max) NOT NULL,
    [Followers] int NULL,
    [UserName] nvarchar(256) NULL,
    [NormalizedUserName] nvarchar(256) NULL,
    [Email] nvarchar(256) NULL,
    [NormalizedEmail] nvarchar(256) NULL,
    [EmailConfirmed] bit NOT NULL,
    [PasswordHash] nvarchar(max) NULL,
    [SecurityStamp] nvarchar(max) NULL,
    [ConcurrencyStamp] nvarchar(max) NULL,
    [PhoneNumber] nvarchar(max) NULL,
    [PhoneNumberConfirmed] bit NOT NULL,
    [TwoFactorEnabled] bit NOT NULL,
    [LockoutEnd] datetimeoffset NULL,
    [LockoutEnabled] bit NOT NULL,
    [AccessFailedCount] int NOT NULL,
    CONSTRAINT [PK_AspNetUsers] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Categories] (
    [CategoryId] nvarchar(450) NOT NULL,
    [FoodType] nvarchar(150) NOT NULL,
    CONSTRAINT [PK_Categories] PRIMARY KEY ([CategoryId])
);
GO

CREATE TABLE [AspNetRoleClaims] (
    [Id] int NOT NULL IDENTITY,
    [RoleId] nvarchar(50) NOT NULL,
    [ClaimType] nvarchar(max) NULL,
    [ClaimValue] nvarchar(max) NULL,
    CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [AspNetUserClaims] (
    [Id] int NOT NULL IDENTITY,
    [UserId] nvarchar(50) NOT NULL,
    [ClaimType] nvarchar(max) NULL,
    [ClaimValue] nvarchar(max) NULL,
    CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [AspNetUserLogins] (
    [LoginProvider] nvarchar(450) NOT NULL,
    [ProviderKey] nvarchar(450) NOT NULL,
    [ProviderDisplayName] nvarchar(max) NULL,
    [UserId] nvarchar(50) NOT NULL,
    CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY ([LoginProvider], [ProviderKey]),
    CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [AspNetUserRoles] (
    [UserId] nvarchar(50) NOT NULL,
    [RoleId] nvarchar(50) NOT NULL,
    CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY ([UserId], [RoleId]),
    CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [AspNetUserTokens] (
    [UserId] nvarchar(50) NOT NULL,
    [LoginProvider] nvarchar(450) NOT NULL,
    [Name] nvarchar(450) NOT NULL,
    [Value] nvarchar(max) NULL,
    [Discriminator] nvarchar(max) NOT NULL,
    [RefreshTokenExpiry] datetime2 NULL,
    [IDaccessTokenJwt] nvarchar(max) NULL,
    [IsUsed] bit NULL,
    [IsRevoked] bit NULL,
    [IssuedAt] datetime2 NULL,
    [ExpiredAt] datetime2 NULL,
    CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY ([UserId], [LoginProvider], [Name]),
    CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [Follows] (
    [FollowerId] nvarchar(50) NOT NULL,
    [FollowId] nvarchar(max) NULL,
    [FollowingId] nvarchar(50) NULL,
    CONSTRAINT [PK_Follows] PRIMARY KEY ([FollowerId]),
    CONSTRAINT [FK_Follows_AspNetUsers_FollowerId] FOREIGN KEY ([FollowerId]) REFERENCES [AspNetUsers] ([Id]),
    CONSTRAINT [FK_Follows_AspNetUsers_FollowingId] FOREIGN KEY ([FollowingId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [Posts] (
    [PostId] nvarchar(450) NOT NULL,
    [UserId] nvarchar(50) NULL,
    [NameFood] nvarchar(max) NOT NULL,
    [DatePosted] datetime2 NOT NULL,
    [average] real NULL,
    [Likes] int NULL,
    [Thumbnail] nvarchar(max) NULL,
    CONSTRAINT [PK_Posts] PRIMARY KEY ([PostId]),
    CONSTRAINT [FK_Posts_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [Comments] (
    [CommentID] nvarchar(450) NOT NULL,
    [Content] nvarchar(max) NOT NULL,
    [UserID] nvarchar(50) NOT NULL,
    [PostID] nvarchar(450) NOT NULL,
    [timeComment] datetime2 NOT NULL,
    [Depth] int NOT NULL,
    [CommentFatherID] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Comments] PRIMARY KEY ([CommentID]),
    CONSTRAINT [FK_Comments_AspNetUsers_UserID] FOREIGN KEY ([UserID]) REFERENCES [AspNetUsers] ([Id]),
    CONSTRAINT [FK_Comments_Posts_PostID] FOREIGN KEY ([PostID]) REFERENCES [Posts] ([PostId]) ON DELETE CASCADE
);
GO

CREATE TABLE [FoodIngredients] (
    [FoodID] nvarchar(450) NOT NULL,
    [CookingTime] nvarchar(max) NOT NULL,
    [PostID] nvarchar(450) NOT NULL,
    CONSTRAINT [PK_FoodIngredients] PRIMARY KEY ([FoodID]),
    CONSTRAINT [FK_FoodIngredients_Posts_PostID] FOREIGN KEY ([PostID]) REFERENCES [Posts] ([PostId])
);
GO

CREATE TABLE [LikePosts] (
    [PostId] nvarchar(450) NOT NULL,
    [UserId] nvarchar(50) NOT NULL,
    CONSTRAINT [PK_LikePosts] PRIMARY KEY ([PostId], [UserId]),
    CONSTRAINT [FK_LikePosts_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]),
    CONSTRAINT [FK_LikePosts_Posts_PostId] FOREIGN KEY ([PostId]) REFERENCES [Posts] ([PostId]) ON DELETE CASCADE
);
GO

CREATE TABLE [PostCategories] (
    [LinkId] nvarchar(450) NOT NULL,
    [PostId] nvarchar(450) NULL,
    [CategoryId] nvarchar(450) NULL,
    CONSTRAINT [PK_PostCategories] PRIMARY KEY ([LinkId]),
    CONSTRAINT [FK_PostCategories_Categories_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [Categories] ([CategoryId]),
    CONSTRAINT [FK_PostCategories_Posts_PostId] FOREIGN KEY ([PostId]) REFERENCES [Posts] ([PostId]) ON DELETE CASCADE
);
GO

CREATE TABLE [PostContents] (
    [ContentPostID] nvarchar(450) NOT NULL,
    [PostId] nvarchar(450) NOT NULL,
    [Content] nvarchar(max) NULL,
    CONSTRAINT [PK_PostContents] PRIMARY KEY ([ContentPostID]),
    CONSTRAINT [FK_PostContents_Posts_PostId] FOREIGN KEY ([PostId]) REFERENCES [Posts] ([PostId]) ON DELETE CASCADE
);
GO

CREATE TABLE [RatingPosts] (
    [PostId] nvarchar(450) NOT NULL,
    [UserId] nvarchar(50) NOT NULL,
    [Evaluate] int NULL,
    CONSTRAINT [PK_RatingPosts] PRIMARY KEY ([PostId], [UserId]),
    CONSTRAINT [FK_RatingPosts_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]),
    CONSTRAINT [FK_RatingPosts_Posts_PostId] FOREIGN KEY ([PostId]) REFERENCES [Posts] ([PostId]) ON DELETE CASCADE
);
GO

CREATE TABLE [Ingredients] (
    [ID] nvarchar(450) NOT NULL,
    [NameIngredient] nvarchar(max) NOT NULL,
    [FoodIngredientId] nvarchar(450) NOT NULL,
    CONSTRAINT [PK_Ingredients] PRIMARY KEY ([ID]),
    CONSTRAINT [FK_Ingredients_FoodIngredients_FoodIngredientId] FOREIGN KEY ([FoodIngredientId]) REFERENCES [FoodIngredients] ([FoodID]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_AspNetRoleClaims_RoleId] ON [AspNetRoleClaims] ([RoleId]);
GO

CREATE UNIQUE INDEX [RoleNameIndex] ON [AspNetRoles] ([NormalizedName]) WHERE [NormalizedName] IS NOT NULL;
GO

CREATE INDEX [IX_AspNetUserClaims_UserId] ON [AspNetUserClaims] ([UserId]);
GO

CREATE INDEX [IX_AspNetUserLogins_UserId] ON [AspNetUserLogins] ([UserId]);
GO

CREATE INDEX [IX_AspNetUserRoles_RoleId] ON [AspNetUserRoles] ([RoleId]);
GO

CREATE INDEX [EmailIndex] ON [AspNetUsers] ([NormalizedEmail]);
GO

CREATE UNIQUE INDEX [UserNameIndex] ON [AspNetUsers] ([NormalizedUserName]) WHERE [NormalizedUserName] IS NOT NULL;
GO

CREATE INDEX [IX_Comments_PostID] ON [Comments] ([PostID]);
GO

CREATE INDEX [IX_Comments_UserID] ON [Comments] ([UserID]);
GO

CREATE INDEX [IX_Follows_FollowingId] ON [Follows] ([FollowingId]);
GO

CREATE UNIQUE INDEX [IX_FoodIngredients_PostID] ON [FoodIngredients] ([PostID]);
GO

CREATE INDEX [IX_Ingredients_FoodIngredientId] ON [Ingredients] ([FoodIngredientId]);
GO

CREATE INDEX [IX_LikePosts_UserId] ON [LikePosts] ([UserId]);
GO

CREATE INDEX [IX_PostCategories_CategoryId] ON [PostCategories] ([CategoryId]);
GO

CREATE UNIQUE INDEX [IX_PostCategories_PostId] ON [PostCategories] ([PostId]) WHERE [PostId] IS NOT NULL;
GO

CREATE UNIQUE INDEX [IX_PostContents_PostId] ON [PostContents] ([PostId]);
GO

CREATE INDEX [IX_Posts_UserId] ON [Posts] ([UserId]);
GO

CREATE INDEX [IX_RatingPosts_UserId] ON [RatingPosts] ([UserId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231218105858_migrations', N'7.0.14');
GO

COMMIT;
GO
