CREATE TABLE [dbo].[StoreList] (
    [StoreId]       INT             IDENTITY (100, 1) NOT NULL,
    [StoreName]     NVARCHAR (4000) NULL,
    [StoreUserName] NVARCHAR (100)  NULL,
    [SubscriberId]  INT             NULL,
    [Subscriber]    NVARCHAR (255)  NULL,
    [DBId]          INT             DEFAULT ((1)) NOT NULL,
    [DBName]        NVARCHAR (255)  NULL,
    [DBUserName]    NVARCHAR (255)  NULL,
    [DBPassword]    NVARCHAR (255)  NULL,
    [Status]        INT             DEFAULT ((1)) NULL,
    [CreatedAT]     DATETIME        DEFAULT (getdate()) NULL,
    [UpdateAT]      DATETIME        NULL,
    [IsDeleted]     BIT             DEFAULT ((0)) NULL,
    PRIMARY KEY CLUSTERED ([StoreId] ASC),
    FOREIGN KEY ([DBId]) REFERENCES [dbo].[DBServer] ([DBId])
);

