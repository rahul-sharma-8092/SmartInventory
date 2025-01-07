CREATE TABLE [dbo].[DBServer] (
    [DBId]      INT            IDENTITY (1, 1) NOT NULL,
    [Name]      NVARCHAR (255) NULL,
    [Server]    NVARCHAR (255) NULL,
    [PublicIP]  NVARCHAR (100) NULL,
    [PrivateIP] NVARCHAR (100) NULL,
    [CreatedAT] DATETIME       DEFAULT (getdate()) NULL,
    [UpdatedAT] DATETIME       NULL,
    [IsDeleted] BIT            DEFAULT ((0)) NULL,
    PRIMARY KEY CLUSTERED ([DBId] ASC)
);

