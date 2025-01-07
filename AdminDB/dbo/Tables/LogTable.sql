CREATE TABLE [dbo].[LogTable] (
    [LogId]       BIGINT         IDENTITY (1, 1) NOT NULL,
    [LogType]     INT            NULL,
    [Activity]    NVARCHAR (MAX) NOT NULL,
    [StoreUserID] INT            DEFAULT ((0)) NULL,
    [IpAddress]   NVARCHAR (20)  NULL,
    [Timestamp]   DATETIME       DEFAULT (getdate()) NULL
);

