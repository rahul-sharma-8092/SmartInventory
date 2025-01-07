CREATE TABLE [dbo].[AdminUser] (
    [UserID]         INT            IDENTITY (1000, 1) NOT NULL,
    [Name]           NVARCHAR (255) NOT NULL,
    [Email]          NVARCHAR (100) NOT NULL,
    [Email2]         NVARCHAR (100) NULL,
    [Password]       NVARCHAR (MAX) NULL,
    [RoleId]         INT            NOT NULL,
    [Role]           NVARCHAR (20)  NOT NULL,
    [Mobile]         NVARCHAR (13)  NULL,
    [Status]         INT            DEFAULT ((1)) NULL,
    [Guid]           NVARCHAR (500) NULL,
    [GuidTimeStamp]  DATETIME       NULL,
    [IsGuidExpired]  BIT            NULL,
    [LoginTimeStamp] DATETIME       NULL,
    [IpAddress]      NVARCHAR (20)  NULL,
    [CreatedAT]      DATETIME       DEFAULT (getdate()) NULL,
    [UpdatedAT]      DATETIME       NULL,
    [IsDeleted]      BIT            DEFAULT ((0)) NULL,
    PRIMARY KEY CLUSTERED ([UserID] ASC),
    UNIQUE NONCLUSTERED ([Email] ASC)
);

