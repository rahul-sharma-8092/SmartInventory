CREATE TABLE [dbo].[ErrorLog] (
    [ErrorId]        BIGINT         IDENTITY (1, 1) NOT NULL,
    [Message]        NVARCHAR (MAX) NULL,
    [StackTrace]     NVARCHAR (MAX) NULL,
    [InnerException] NVARCHAR (MAX) NULL,
    [Folder]         NVARCHAR (MAX) NULL,
    [UserId]         INT            NULL,
    [CreatedAT]      DATETIME       DEFAULT (getdate()) NULL,
    PRIMARY KEY CLUSTERED ([ErrorId] ASC)
);

