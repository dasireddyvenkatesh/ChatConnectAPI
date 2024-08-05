BEGIN TRANSACTION;
GO

CREATE TABLE [ChatConnect].[Controllers] (
    [ControllerId] int NOT NULL IDENTITY,
    [ControllerName] nvarchar(255) NOT NULL,
    CONSTRAINT [PK_Controllers] PRIMARY KEY ([ControllerId])
);
GO

CREATE TABLE [ChatConnect].[Roles] (
    [RoleId] int NOT NULL IDENTITY,
    [RoleName] nvarchar(255) NOT NULL,
    CONSTRAINT [PK_Roles] PRIMARY KEY ([RoleId])
);
GO

CREATE TABLE [ChatConnect].[Methods] (
    [MethodId] int NOT NULL IDENTITY,
    [MethodName] nvarchar(255) NOT NULL,
    [ControllerId] int NOT NULL,
    [RoleId] int NOT NULL,
    CONSTRAINT [PK_Methods] PRIMARY KEY ([MethodId]),
    CONSTRAINT [FK_Methods_Controllers_ControllerId] FOREIGN KEY ([ControllerId]) REFERENCES [ChatConnect].[Controllers] ([ControllerId]) ON DELETE CASCADE,
    CONSTRAINT [FK_Methods_Roles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [ChatConnect].[Roles] ([RoleId]) ON DELETE CASCADE
);
GO

CREATE TABLE [ChatConnect].[UserRoles] (
    [Id] int NOT NULL IDENTITY,
    [UserId] int NOT NULL,
    [RoleId] int NOT NULL,
    CONSTRAINT [PK_UserRoles] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_UserRoles_Roles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [ChatConnect].[Roles] ([RoleId]) ON DELETE CASCADE,
    CONSTRAINT [FK_UserRoles_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [ChatConnect].[Users] ([UserId]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_Methods_ControllerId] ON [ChatConnect].[Methods] ([ControllerId]);
GO

CREATE INDEX [IX_Methods_RoleId] ON [ChatConnect].[Methods] ([RoleId]);
GO

CREATE INDEX [IX_UserRoles_RoleId] ON [ChatConnect].[UserRoles] ([RoleId]);
GO

CREATE INDEX [IX_UserRoles_UserId] ON [ChatConnect].[UserRoles] ([UserId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240723103429_CreateLoginAndRoleTable', N'8.0.7');
GO

COMMIT;
GO

