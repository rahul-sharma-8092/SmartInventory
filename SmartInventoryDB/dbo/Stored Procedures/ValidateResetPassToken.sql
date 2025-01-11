-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE   PROCEDURE ValidateResetPassToken
	@Token NVARCHAR(100)
AS
BEGIN
	DECLARE @ReturnCode INT = 0;
	DECLARE @Mindate DATETIME = '1753-01-01';

	IF EXISTS(SELECT 1 FROM StoreUser Where [Guid] = @Token AND DATEADD(MINUTE, 30, ISNULL([GuidTimeStamp], @Mindate)) > GETDATE() AND IsDeleted = 0)
	BEGIN 
		SET @ReturnCode = 1;

		SELECT @ReturnCode AS [ReturnCode], StoreUserId, CONCAT(FirstName, ' ', LastName) AS FullName, Email, 0 AS IsGuidExpired 
		FROM StoreUser WHERE [Guid] = @Token AND IsDeleted = 0
	END
END