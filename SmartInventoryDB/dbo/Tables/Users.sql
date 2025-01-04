CREATE TABLE [dbo].[Users] (
    [UserID]         INT            IDENTITY (1000, 1) NOT NULL,
    [FirstName]      NVARCHAR (100) NOT NULL,
    [LastName]       NVARCHAR (100) NULL,
    [Email]          NVARCHAR (100) NOT NULL,
    [Password]       NVARCHAR (255) NULL,
    [RoleId]         INT            NOT NULL,
    [Role]           NVARCHAR (20)  NOT NULL,
    [Mobile]         NVARCHAR (13)  NULL,
    [Guid]           NVARCHAR (500) NULL,
    [GuidTimeStamp]  DATETIME       NULL,
    [IsGuidExpired]  BIT            DEFAULT ((0)) NULL,
    [LoginTimeStamp] DATETIME       NULL,
    [IpAddress]      NVARCHAR (20)  NULL,
    [CreatedAT]      DATETIME       DEFAULT (getdate()) NULL,
    [UpdatedAT]      DATETIME       NULL,
    [IsDeleted]      BIT            DEFAULT ((0)) NULL,
    [Status]         INT            DEFAULT ((0)) NULL,
    PRIMARY KEY CLUSTERED ([UserID] ASC),
    UNIQUE NONCLUSTERED ([Email] ASC)
);

