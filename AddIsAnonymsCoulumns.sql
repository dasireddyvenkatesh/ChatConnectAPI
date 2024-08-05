BEGIN TRANSACTION;
GO

ALTER TABLE [ChatConnect].[Methods] ADD [IsAnonymous] bit NOT NULL DEFAULT CAST(0 AS bit);
GO

ALTER TABLE [ChatConnect].[Controllers] ADD [IsAnonymous] bit NOT NULL DEFAULT CAST(0 AS bit);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240725115117_AddIsAnonymsCoulumns', N'8.0.7');
GO

COMMIT;
GO

