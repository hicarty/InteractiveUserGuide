IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [InteractiveAmplifiers] (
    [Id] int NOT NULL IDENTITY,
    [Model] nvarchar(max) NULL,
    [Power] int NOT NULL,
    CONSTRAINT [PK_InteractiveAmplifiers] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [InteractiveElements] (
    [Id] int NOT NULL IDENTITY,
    [InteractiveAmplifierId] int NOT NULL,
    [Name] nvarchar(max) NULL,
    [Description] nvarchar(max) NULL,
    [Panel] nvarchar(max) NULL,
    [MeshName] nvarchar(max) NULL,
    CONSTRAINT [PK_InteractiveElements] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_InteractiveElements_InteractiveAmplifiers_InteractiveAmplifierId] FOREIGN KEY ([InteractiveAmplifierId]) REFERENCES [InteractiveAmplifiers] ([Id]) ON DELETE CASCADE
);

GO

CREATE INDEX [IX_InteractiveElements_InteractiveAmplifierId] ON [InteractiveElements] ([InteractiveAmplifierId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20190807100514_Initial', N'2.2.6-servicing-10079');

GO

