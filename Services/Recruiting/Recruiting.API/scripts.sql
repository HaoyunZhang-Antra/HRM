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

CREATE TABLE [Jobs] (
    [Id] int NOT NULL IDENTITY,
    [JobCode] uniqueidentifier NOT NULL,
    [Title] nvarchar(max) NOT NULL,
    [Description] nvarchar(max) NOT NULL,
    [StartDate] datetime2 NULL,
    [IsActive] bit NULL,
    [NumberOfPositions] int NOT NULL,
    [ClosedOn] datetime2 NULL,
    [ClosedReason] nvarchar(max) NULL,
    [CreatedOn] datetime2 NULL,
    CONSTRAINT [PK_Jobs] PRIMARY KEY ([Id])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230315194540_InitialMigration', N'7.0.4');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230316153357_UpdatingJobsTable', N'7.0.4');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Jobs]') AND [c].[name] = N'Title');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Jobs] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [Jobs] ALTER COLUMN [Title] nvarchar(80) NOT NULL;
GO

DECLARE @var1 sysname;
SELECT @var1 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Jobs]') AND [c].[name] = N'Description');
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Jobs] DROP CONSTRAINT [' + @var1 + '];');
ALTER TABLE [Jobs] ALTER COLUMN [Description] nvarchar(2048) NOT NULL;
GO

DECLARE @var2 sysname;
SELECT @var2 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Jobs]') AND [c].[name] = N'ClosedReason');
IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [Jobs] DROP CONSTRAINT [' + @var2 + '];');
ALTER TABLE [Jobs] ALTER COLUMN [ClosedReason] nvarchar(1024) NULL;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230316154649_CreatingCandidateTable', N'7.0.4');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Jobs] ADD [JobStatusLookUpId] int NOT NULL DEFAULT 0;
GO

CREATE TABLE [Candidates] (
    [Id] int NOT NULL IDENTITY,
    [FirstName] nvarchar(50) NOT NULL,
    [MiddleName] nvarchar(50) NULL,
    [LastName] nvarchar(50) NOT NULL,
    [Email] nvarchar(512) NOT NULL,
    [ResumeURL] nvarchar(2048) NULL,
    [CreatedOn] datetime2 NOT NULL,
    CONSTRAINT [PK_Candidates] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [JobStatusLookUp] (
    [Id] int NOT NULL IDENTITY,
    [JobStatusCode] nvarchar(max) NOT NULL,
    [JobStatusDescription] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_JobStatusLookUp] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Submission] (
    [Id] int NOT NULL IDENTITY,
    [JobId] int NOT NULL,
    [CandidateId] int NOT NULL,
    [SubmittedOn] datetime2 NULL,
    [SelectedForInterview] datetime2 NULL,
    [RejectedOn] datetime2 NULL,
    [RejectedReason] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Submission] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Submission_Candidates_CandidateId] FOREIGN KEY ([CandidateId]) REFERENCES [Candidates] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Submission_Jobs_JobId] FOREIGN KEY ([JobId]) REFERENCES [Jobs] ([Id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_Jobs_JobStatusLookUpId] ON [Jobs] ([JobStatusLookUpId]);
GO

CREATE INDEX [IX_Submission_CandidateId] ON [Submission] ([CandidateId]);
GO

CREATE INDEX [IX_Submission_JobId] ON [Submission] ([JobId]);
GO

ALTER TABLE [Jobs] ADD CONSTRAINT [FK_Jobs_JobStatusLookUp_JobStatusLookUpId] FOREIGN KEY ([JobStatusLookUpId]) REFERENCES [JobStatusLookUp] ([Id]) ON DELETE CASCADE;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230316155659_JobStatusLookUpTable', N'7.0.4');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230316160012_SubmissionsTable', N'7.0.4');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Jobs] DROP CONSTRAINT [FK_Jobs_JobStatusLookUp_JobStatusLookUpId];
GO

ALTER TABLE [Submission] DROP CONSTRAINT [FK_Submission_Candidates_CandidateId];
GO

ALTER TABLE [Submission] DROP CONSTRAINT [FK_Submission_Jobs_JobId];
GO

ALTER TABLE [Submission] DROP CONSTRAINT [PK_Submission];
GO

ALTER TABLE [JobStatusLookUp] DROP CONSTRAINT [PK_JobStatusLookUp];
GO

EXEC sp_rename N'[Submission]', N'Submissions';
GO

EXEC sp_rename N'[JobStatusLookUp]', N'JobStatusLookUps';
GO

EXEC sp_rename N'[Submissions].[IX_Submission_JobId]', N'IX_Submissions_JobId', N'INDEX';
GO

EXEC sp_rename N'[Submissions].[IX_Submission_CandidateId]', N'IX_Submissions_CandidateId', N'INDEX';
GO

DECLARE @var3 sysname;
SELECT @var3 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Candidates]') AND [c].[name] = N'FirstName');
IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [Candidates] DROP CONSTRAINT [' + @var3 + '];');
ALTER TABLE [Candidates] ALTER COLUMN [FirstName] nvarchar(100) NOT NULL;
GO

DECLARE @var4 sysname;
SELECT @var4 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Candidates]') AND [c].[name] = N'CreatedOn');
IF @var4 IS NOT NULL EXEC(N'ALTER TABLE [Candidates] DROP CONSTRAINT [' + @var4 + '];');
ALTER TABLE [Candidates] ADD DEFAULT (getdate()) FOR [CreatedOn];
GO

ALTER TABLE [Submissions] ADD CONSTRAINT [PK_Submissions] PRIMARY KEY ([Id]);
GO

ALTER TABLE [JobStatusLookUps] ADD CONSTRAINT [PK_JobStatusLookUps] PRIMARY KEY ([Id]);
GO

CREATE UNIQUE INDEX [IX_Candidates_Email] ON [Candidates] ([Email]);
GO

ALTER TABLE [Jobs] ADD CONSTRAINT [FK_Jobs_JobStatusLookUps_JobStatusLookUpId] FOREIGN KEY ([JobStatusLookUpId]) REFERENCES [JobStatusLookUps] ([Id]) ON DELETE CASCADE;
GO

ALTER TABLE [Submissions] ADD CONSTRAINT [FK_Submissions_Candidates_CandidateId] FOREIGN KEY ([CandidateId]) REFERENCES [Candidates] ([Id]) ON DELETE CASCADE;
GO

ALTER TABLE [Submissions] ADD CONSTRAINT [FK_Submissions_Jobs_JobId] FOREIGN KEY ([JobId]) REFERENCES [Jobs] ([Id]) ON DELETE CASCADE;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230316160748_UpdatingCandidateTable', N'7.0.4');
GO

COMMIT;
GO

