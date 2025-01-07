CREATE TABLE [dbo].[LoginHistory] (
    [Id]          BIGINT          IDENTITY (1, 1) NOT NULL,
    [StoreUserID] INT             NULL,
    [Email]       NVARCHAR (255)  NULL,
    [IpAddress]   NVARCHAR (20)   NULL,
    [Message]     NVARCHAR (4000) NULL,
    [TimeStamp]   DATETIME        DEFAULT (getdate()) NULL,
    [IsFailed]    BIT             NULL,
    [IsAdmin]     BIT             DEFAULT ((0)) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

