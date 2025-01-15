-- =============================================
-- Author:		Rahul Sharma
-- Create date: 14-01-2025
-- Description:	Add/Update Category
-- =============================================
CREATE   PROCEDURE [dbo].[AddUpdateCategory]
	@CategoryID INT,
	@CategoryName NVARCHAR(255),
	@Description NVARCHAR(1000),
	@ParentCategoryID INT NULL,
	@IsActive BIT,
	@StoreUserId INT,
	@UserName NVARCHAR(255)
AS
BEGIN
	
	IF(@CategoryID > 0)
	BEGIN 
		UPDATE Category SET CategoryName = LTRIM(RTRIM(@CategoryName)), [Description] = LTRIM(RTRIM(@Description)), IsActive = @IsActive,
		[ParentCategoryID] = IIF(ISNULL(@ParentCategoryID,0) = 0, NULL, @ParentCategoryID), UpdatedAT = GETDATE()
		WHERE CategoryID = @CategoryID AND IsDeleted = 0;
	END
	ELSE
	BEGIN
		IF NOT EXISTS(SELECT 1 FROM Category WHERE [CategoryName] = @CategoryName)
		BEGIN
			INSERT INTO Category([CategoryName], [Description], [IsActive], [ParentCategoryID])
			VALUES(LTRIM(RTRIM(@CategoryName)), LTRIM(RTRIM(@Description)), @IsActive, IIF(ISNULL(@ParentCategoryID,0) = 0, NULL, @ParentCategoryID))
		END
	END
	
	SELECT ISNULL(SCOPE_IDENTITY(),0) AS [ReturnVal];
END