-- =============================================
-- Author:		<Rahul Sharma>
-- Create date: <06-JAN-2025>
-- Description:	<Description,,>
-- =============================================
CREATE   PROCEDURE [dbo].[GetStoreDetails]
	@StoreUserName NVARCHAR(255)
AS
BEGIN
	
	SELECT S.*, D.[Server] FROM StoreList S
	INNER JOIN DBServer D ON S.[DBId] = D.[DBId]
	WHERE StoreUserName = @StoreUserName AND S.IsDeleted = 0

END
