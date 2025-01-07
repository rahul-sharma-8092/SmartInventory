CREATE TABLE [dbo].[ForgotPasswordRequest] (
    [ReqID]       INT            IDENTITY (1, 1) NOT NULL,
    [Guid]        NVARCHAR (100) NULL,
    [StoreUserID] INT            NOT NULL,
    [IpAddress]   NVARCHAR (20)  NULL,
    [CreatedAT]   DATETIME       DEFAULT (getdate()) NULL,
    [UpdatedAT]   DATETIME       NULL,
    [IsDeleted]   BIT            DEFAULT ((0)) NULL,
    PRIMARY KEY CLUSTERED ([ReqID] ASC),
    FOREIGN KEY ([StoreUserID]) REFERENCES [dbo].[StoreUser] ([StoreUserID])
);

