CREATE TABLE [dbo].[Category] (
    [CategoryID]       INT             IDENTITY (1, 1) NOT NULL,
    [CategoryName]     NVARCHAR (255)  NOT NULL,
    [Description]      NVARCHAR (1000) NULL,
    [ParentCategoryID] INT             NULL,
    [IsActive]         BIT             DEFAULT ((1)) NULL,
    [CreatedAT]        DATETIME        DEFAULT (getdate()) NOT NULL,
    [UpdatedAT]        DATETIME        NULL,
    [IsDeleted]        BIT             DEFAULT ((0)) NULL,
    PRIMARY KEY CLUSTERED ([CategoryID] ASC),
    CONSTRAINT [FK_Categories_ParentCategory] FOREIGN KEY ([ParentCategoryID]) REFERENCES [dbo].[Category] ([CategoryID]),
    UNIQUE NONCLUSTERED ([CategoryName] ASC)
);

