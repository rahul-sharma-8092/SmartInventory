-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE DeleteCategory
	@Id INT
AS
BEGIN
	
	UPDATE Category SET IsDeleted = 1 WHERE CategoryID = @Id;

	SELECT ISNULL(CategoryName, '') AS CategoryName FROM Category WHERE CategoryID = @Id AND IsDeleted = 1;
END