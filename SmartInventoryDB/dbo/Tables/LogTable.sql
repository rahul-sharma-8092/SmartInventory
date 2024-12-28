CREATE TABLE [dbo].[LogTable] (
    [LogId]     BIGINT         IDENTITY (1, 1) NOT NULL,
    [LogType]   INT            NULL,
    [Activity]  NVARCHAR (255) NOT NULL,
    [UserID]    INT            NULL,
    [IpAddress] NVARCHAR (20)  NULL,
    [Timestamp] DATETIME       DEFAULT (getdate()) NULL,
    PRIMARY KEY CLUSTERED ([LogId] ASC),
    CONSTRAINT [FK_Log_User] FOREIGN KEY ([UserID]) REFERENCES [dbo].[Users] ([UserID])
);

