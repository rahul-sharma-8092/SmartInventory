CREATE TABLE [dbo].[EmailHistory] (
    [Id]          BIGINT          IDENTITY (1, 1) NOT NULL,
    [From]        NVARCHAR (255)  NULL,
    [To]          NVARCHAR (MAX)  NULL,
    [CC]          NVARCHAR (4000) NULL,
    [Bcc]         NVARCHAR (4000) NULL,
    [Subject]     NVARCHAR (MAX)  NULL,
    [Body]        NVARCHAR (MAX)  NULL,
    [Attachment]  NVARCHAR (MAX)  NULL,
    [Status]      INT             NULL,
    [CreatedAT]   DATETIME        DEFAULT (getdate()) NULL,
    [OTP]         NVARCHAR (25)   NULL,
    [StoreUserId] INT             DEFAULT ((0)) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

