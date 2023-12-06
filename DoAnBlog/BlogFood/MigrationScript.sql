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
    CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY ([UserId], [LoginProvider], [Name]),
    CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [Fllows] (
    [FollowerId] nvarchar(50) NOT NULL,
    [FollowId] nvarchar(max) NULL,
    [FollowingId] nvarchar(50) NULL,
    [ManageUserId] nvarchar(50) NULL,
    [ManageUserId1] nvarchar(50) NULL,
    CONSTRAINT [PK_Fllows] PRIMARY KEY ([FollowerId]),
    CONSTRAINT [FK_Fllows_AspNetUsers_FollowerId] FOREIGN KEY ([FollowerId]) REFERENCES [AspNetUsers] ([Id]),
    CONSTRAINT [FK_Fllows_AspNetUsers_FollowingId] FOREIGN KEY ([FollowingId]) REFERENCES [AspNetUsers] ([Id]),
    CONSTRAINT [FK_Fllows_AspNetUsers_ManageUserId] FOREIGN KEY ([ManageUserId]) REFERENCES [AspNetUsers] ([Id]),
    CONSTRAINT [FK_Fllows_AspNetUsers_ManageUserId1] FOREIGN KEY ([ManageUserId1]) REFERENCES [AspNetUsers] ([Id])
);
GO

CREATE TABLE [Posts] (
    [PostId] nvarchar(450) NOT NULL,
    [UserId] nvarchar(50) NULL,
    [NameFood] nvarchar(max) NOT NULL,
    [Title] nvarchar(max) NOT NULL,
    [Content] nvarchar(max) NOT NULL,
    [DatePosted] datetime2 NOT NULL,
    [Likes] int NULL,
    CONSTRAINT [PK_Posts] PRIMARY KEY ([PostId]),
    CONSTRAINT [FK_Posts_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id])
);
GO

CREATE TABLE [Comments] (
    [CommentID] nvarchar(450) NOT NULL,
    [Content] nvarchar(max) NOT NULL,
    [UserID] nvarchar(50) NOT NULL,
    [PostID] nvarchar(450) NOT NULL,
    [Depth] int NOT NULL,
    CONSTRAINT [PK_Comments] PRIMARY KEY ([CommentID]),
    CONSTRAINT [FK_Comments_AspNetUsers_UserID] FOREIGN KEY ([UserID]) REFERENCES [AspNetUsers] ([Id]),
    CONSTRAINT [FK_Comments_Posts_PostID] FOREIGN KEY ([PostID]) REFERENCES [Posts] ([PostId])
);
GO

CREATE TABLE [LikePosts] (
    [PostId] nvarchar(450) NOT NULL,
    [UserId] nvarchar(50) NOT NULL,
    [LikePostId] nvarchar(max) NULL,
    CONSTRAINT [PK_LikePosts] PRIMARY KEY ([PostId], [UserId]),
    CONSTRAINT [FK_LikePosts_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_LikePosts_Posts_PostId] FOREIGN KEY ([PostId]) REFERENCES [Posts] ([PostId]) ON DELETE CASCADE
);
GO

CREATE TABLE [PostCategories] (
    [LinkId] nvarchar(450) NOT NULL,
    [PostId] nvarchar(450) NULL,
    [CategoryId] nvarchar(450) NULL,
    [CategoryId1] nvarchar(450) NULL,
    CONSTRAINT [PK_PostCategories] PRIMARY KEY ([LinkId]),
    CONSTRAINT [FK_PostCategories_Categories_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [Categories] ([CategoryId]),
    CONSTRAINT [FK_PostCategories_Categories_CategoryId1] FOREIGN KEY ([CategoryId1]) REFERENCES [Categories] ([CategoryId]),
    CONSTRAINT [FK_PostCategories_Posts_PostId] FOREIGN KEY ([PostId]) REFERENCES [Posts] ([PostId])
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

CREATE INDEX [IX_Fllows_FollowingId] ON [Fllows] ([FollowingId]);
GO

CREATE INDEX [IX_Fllows_ManageUserId] ON [Fllows] ([ManageUserId]);
GO

CREATE INDEX [IX_Fllows_ManageUserId1] ON [Fllows] ([ManageUserId1]);
GO

CREATE INDEX [IX_LikePosts_UserId] ON [LikePosts] ([UserId]);
GO

CREATE INDEX [IX_PostCategories_CategoryId] ON [PostCategories] ([CategoryId]);
GO

CREATE INDEX [IX_PostCategories_CategoryId1] ON [PostCategories] ([CategoryId1]);
GO

CREATE INDEX [IX_PostCategories_PostId] ON [PostCategories] ([PostId]);
GO

CREATE INDEX [IX_Posts_UserId] ON [Posts] ([UserId]);
GO

CREATE TRIGGER tr_LikePost_Insert
ON LikePost
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE Post
    SET Likes = Likes + 1
    FROM Post
    INNER JOIN inserted ON Post.PostId = inserted.PostId;
END;
GO

-- Trigger khi delete khỏi bảng LikePost
CREATE TRIGGER tr_LikePost_Delete
ON LikePost
AFTER DELETE
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE Post
    SET Likes = Likes - 1
    FROM Post
    INNER JOIN deleted ON Post.PostId = deleted.PostId;
END;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231205114138_migrations', N'7.0.14');
GO

COMMIT;
GO

