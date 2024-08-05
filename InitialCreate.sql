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

IF SCHEMA_ID(N'ChatConnect') IS NULL EXEC(N'CREATE SCHEMA [ChatConnect];');
GO

CREATE TABLE [ChatConnect].[Users] (
    [UserId] int NOT NULL IDENTITY,
    [Username] nvarchar(100) NOT NULL,
    [Email] nvarchar(255) NOT NULL,
    [Password] nvarchar(1000) NOT NULL,
    [IsActive] bit NOT NULL,
    [IsEmailVerified] bit NOT NULL,
    [EmailOtpDate] datetime2 NULL,
    [EmailOtp] int NULL,
    [FailedLoginAttempts] int NOT NULL,
    [LockoutEnd] datetime2 NULL,
    [SecurityStamp] nvarchar(1000) NULL,
    [DeviceIp] nvarchar(255) NULL,
    [TwoStepVerfication] bit NOT NULL,
    [CreatedAt] datetime2 NOT NULL,
    [UpdatedAt] datetime2 NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY ([UserId])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240720081947_InitialCreate', N'8.0.7');
GO

COMMIT;
GO

