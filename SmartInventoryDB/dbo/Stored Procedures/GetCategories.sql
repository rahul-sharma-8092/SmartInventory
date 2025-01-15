-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetCategories]
	
AS
BEGIN
	SELECT C1.CategoryID, C1.CategoryName, ISNULL(C1.[Description],'') AS [Description],
	IIF(C1.IsActive = 1, 'Active', 'Inactive') AS [IsActive],
	ISNULL(C2.CategoryName,'') AS [ParentName], C1.CreatedAT
	FROM Category C1
	LEFT JOIN Category C2 ON C1.CategoryID = ISNULL(C2.ParentCategoryID,0)
	WHERE C1.IsDeleted = 0
END