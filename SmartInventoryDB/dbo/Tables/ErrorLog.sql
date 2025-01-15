CREATE TABLE [dbo].[ErrorLog] (
    [ErrorId]        BIGINT          IDENTITY (1, 1) NOT NULL,
    [Message]        NVARCHAR (MAX)  NULL,
    [StackTrace]     NVARCHAR (MAX)  NULL,
    [InnerException] NVARCHAR (MAX)  NULL,
    [URL]            NVARCHAR (MAX)  NULL,
    [UserId]         INT             NULL,
    [CreatedAT]      DATETIME        DEFAULT (getdate()) NULL,
    [LogLevel]       INT             DEFAULT ((1)) NULL,
    [IpAddress]      NVARCHAR (20)   NULL,
    [Browser]        NVARCHAR (1000) NULL,
    PRIMARY KEY CLUSTERED ([ErrorId] ASC)
);

