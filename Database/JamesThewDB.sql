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
CREATE TABLE [Categories] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(100) NOT NULL,
    CONSTRAINT [PK_Categories] PRIMARY KEY ([Id])
);

CREATE TABLE [ContactMessages] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(100) NOT NULL,
    [Email] nvarchar(255) NOT NULL,
    [Message] nvarchar(max) NOT NULL,
    [CreatedAt] datetime2 NOT NULL,
    CONSTRAINT [PK_ContactMessages] PRIMARY KEY ([Id])
);

CREATE TABLE [Contests] (
    [Id] int NOT NULL IDENTITY,
    [Title] nvarchar(200) NOT NULL,
    [Description] nvarchar(max) NOT NULL,
    [EntryType] nvarchar(50) NOT NULL,
    [Prize] nvarchar(255) NOT NULL,
    [StartDate] datetime2 NOT NULL,
    [EndDate] datetime2 NOT NULL,
    [Status] nvarchar(20) NOT NULL,
    [CreatedAt] datetime2 NOT NULL,
    CONSTRAINT [PK_Contests] PRIMARY KEY ([Id])
);

CREATE TABLE [Faqs] (
    [Id] int NOT NULL IDENTITY,
    [Question] nvarchar(500) NOT NULL,
    [Answer] nvarchar(max) NOT NULL,
    [DisplayOrder] int NOT NULL,
    CONSTRAINT [PK_Faqs] PRIMARY KEY ([Id])
);

CREATE TABLE [SiteFeedbacks] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(100) NOT NULL,
    [Email] nvarchar(255) NOT NULL,
    [Subject] nvarchar(200) NOT NULL,
    [Category] nvarchar(50) NOT NULL,
    [Rating] int NOT NULL,
    [Comments] nvarchar(max) NOT NULL,
    [ShowOnHome] bit NOT NULL,
    [CreatedAt] datetime2 NOT NULL,
    CONSTRAINT [PK_SiteFeedbacks] PRIMARY KEY ([Id])
);

CREATE TABLE [Users] (
    [Id] int NOT NULL IDENTITY,
    [FullName] nvarchar(100) NOT NULL,
    [Email] nvarchar(255) NOT NULL,
    [Phone] nvarchar(20) NOT NULL,
    [PasswordHash] nvarchar(max) NOT NULL,
    [Role] nvarchar(20) NOT NULL,
    [AvatarPath] nvarchar(255) NOT NULL,
    [IsBlocked] bit NOT NULL,
    [CreatedAt] datetime2 NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY ([Id])
);

CREATE TABLE [ContestEntries] (
    [Id] int NOT NULL IDENTITY,
    [ContestId] int NOT NULL,
    [UserId] int NULL,
    [GuestName] nvarchar(100) NOT NULL,
    [GuestEmail] nvarchar(255) NOT NULL,
    [EntryType] nvarchar(50) NOT NULL,
    [Title] nvarchar(200) NOT NULL,
    [CategoryId] int NULL,
    [Ingredients] nvarchar(max) NOT NULL,
    [Procedure] nvarchar(max) NOT NULL,
    [Description] nvarchar(max) NOT NULL,
    [ImagePath] nvarchar(255) NOT NULL,
    [Status] nvarchar(20) NOT NULL,
    [SubmittedAt] datetime2 NOT NULL,
    CONSTRAINT [PK_ContestEntries] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_ContestEntries_Categories_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [Categories] ([Id]),
    CONSTRAINT [FK_ContestEntries_Contests_ContestId] FOREIGN KEY ([ContestId]) REFERENCES [Contests] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_ContestEntries_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([Id]) ON DELETE SET NULL
);

CREATE TABLE [PasswordResetTokens] (
    [Id] int NOT NULL IDENTITY,
    [UserId] int NOT NULL,
    [TokenHash] nvarchar(255) NOT NULL,
    [ExpiresAt] datetime2 NOT NULL,
    [UsedAt] datetime2 NULL,
    CONSTRAINT [PK_PasswordResetTokens] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_PasswordResetTokens_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([Id]) ON DELETE CASCADE
);

CREATE TABLE [Recipes] (
    [Id] int NOT NULL IDENTITY,
    [Title] nvarchar(200) NOT NULL,
    [CategoryId] int NOT NULL,
    [Ingredients] nvarchar(max) NOT NULL,
    [Procedure] nvarchar(max) NOT NULL,
    [PrepMinutes] int NOT NULL,
    [CookMinutes] int NOT NULL,
    [ImagePath] nvarchar(255) NOT NULL,
    [Access] nvarchar(20) NOT NULL,
    [AuthorId] int NOT NULL,
    [CreatedAt] datetime2 NOT NULL,
    [UpdatedAt] datetime2 NOT NULL,
    CONSTRAINT [PK_Recipes] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Recipes_Categories_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [Categories] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Recipes_Users_AuthorId] FOREIGN KEY ([AuthorId]) REFERENCES [Users] ([Id]) ON DELETE NO ACTION
);

CREATE TABLE [Subscriptions] (
    [Id] int NOT NULL IDENTITY,
    [UserId] int NOT NULL,
    [Plan] nvarchar(50) NOT NULL,
    [Amount] decimal(18,2) NOT NULL,
    [StartDate] datetime2 NOT NULL,
    [ExpiryDate] datetime2 NOT NULL,
    [PaymentStatus] nvarchar(50) NOT NULL,
    [CreatedAt] datetime2 NOT NULL,
    CONSTRAINT [PK_Subscriptions] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Subscriptions_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([Id]) ON DELETE CASCADE
);

CREATE TABLE [Tips] (
    [Id] int NOT NULL IDENTITY,
    [Title] nvarchar(200) NOT NULL,
    [CategoryId] int NOT NULL,
    [Description] nvarchar(max) NOT NULL,
    [ImagePath] nvarchar(255) NOT NULL,
    [Access] nvarchar(20) NOT NULL,
    [AuthorId] int NOT NULL,
    [CreatedAt] datetime2 NOT NULL,
    CONSTRAINT [PK_Tips] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Tips_Categories_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [Categories] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Tips_Users_AuthorId] FOREIGN KEY ([AuthorId]) REFERENCES [Users] ([Id]) ON DELETE NO ACTION
);

CREATE TABLE [Announcements] (
    [Id] int NOT NULL IDENTITY,
    [Type] nvarchar(50) NOT NULL,
    [Title] nvarchar(200) NOT NULL,
    [Message] nvarchar(max) NOT NULL,
    [ContestId] int NULL,
    [WinnerEntryId] int NULL,
    [PostedAt] datetime2 NOT NULL,
    CONSTRAINT [PK_Announcements] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Announcements_ContestEntries_WinnerEntryId] FOREIGN KEY ([WinnerEntryId]) REFERENCES [ContestEntries] ([Id]) ON DELETE SET NULL,
    CONSTRAINT [FK_Announcements_Contests_ContestId] FOREIGN KEY ([ContestId]) REFERENCES [Contests] ([Id])
);

CREATE TABLE [RecipeFeedbacks] (
    [Id] int NOT NULL IDENTITY,
    [RecipeId] int NOT NULL,
    [UserId] int NULL,
    [Name] nvarchar(100) NOT NULL,
    [Email] nvarchar(255) NOT NULL,
    [Rating] int NOT NULL,
    [Comment] nvarchar(max) NOT NULL,
    [CreatedAt] datetime2 NOT NULL,
    CONSTRAINT [PK_RecipeFeedbacks] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_RecipeFeedbacks_Recipes_RecipeId] FOREIGN KEY ([RecipeId]) REFERENCES [Recipes] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_RecipeFeedbacks_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([Id])
);

CREATE INDEX [IX_Announcements_ContestId] ON [Announcements] ([ContestId]);

CREATE UNIQUE INDEX [IX_Announcements_WinnerEntryId] ON [Announcements] ([WinnerEntryId]) WHERE [WinnerEntryId] IS NOT NULL;

CREATE INDEX [IX_ContestEntries_CategoryId] ON [ContestEntries] ([CategoryId]);

CREATE INDEX [IX_ContestEntries_ContestId] ON [ContestEntries] ([ContestId]);

CREATE INDEX [IX_ContestEntries_UserId] ON [ContestEntries] ([UserId]);

CREATE INDEX [IX_PasswordResetTokens_UserId] ON [PasswordResetTokens] ([UserId]);

CREATE INDEX [IX_RecipeFeedbacks_RecipeId] ON [RecipeFeedbacks] ([RecipeId]);

CREATE INDEX [IX_RecipeFeedbacks_UserId] ON [RecipeFeedbacks] ([UserId]);

CREATE INDEX [IX_Recipes_AuthorId] ON [Recipes] ([AuthorId]);

CREATE INDEX [IX_Recipes_CategoryId] ON [Recipes] ([CategoryId]);

CREATE INDEX [IX_Subscriptions_UserId] ON [Subscriptions] ([UserId]);

CREATE INDEX [IX_Tips_AuthorId] ON [Tips] ([AuthorId]);

CREATE INDEX [IX_Tips_CategoryId] ON [Tips] ([CategoryId]);

CREATE UNIQUE INDEX [IX_Users_Email] ON [Users] ([Email]);

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20261005113526_InitialCreate', N'10.0.12');

COMMIT;
GO

