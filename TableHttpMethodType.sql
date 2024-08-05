BEGIN TRANSACTION;
GO

ALTER TABLE [ChatConnect].[Methods] ADD [HttpTypeId] int NOT NULL DEFAULT 0;
GO

CREATE TABLE [ChatConnect].[HttpMethodType] (
    [TypeId] int NOT NULL IDENTITY,
    [Type] nvarchar(255) NOT NULL,
    CONSTRAINT [PK_HttpMethodType] PRIMARY KEY ([TypeId])
);
GO

CREATE INDEX [IX_Methods_HttpTypeId] ON [ChatConnect].[Methods] ([HttpTypeId]);
GO

ALTER TABLE [ChatConnect].[Methods] ADD CONSTRAINT [FK_Methods_HttpMethodType_HttpTypeId] FOREIGN KEY ([HttpTypeId]) REFERENCES [ChatConnect].[HttpMethodType] ([TypeId]) ON DELETE CASCADE;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240730083640_TableHttpMethodType', N'8.0.7');
GO

COMMIT;
GO

