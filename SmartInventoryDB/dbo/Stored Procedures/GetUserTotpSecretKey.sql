-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE GetUserTotpSecretKey
	@StoreUserId INT
AS
BEGIN
	
	Select ISNULL(SecretKey2FA,'') from StoreUser Where StoreUserID = @StoreUserId AND ISNULL(Is2FAEnabled,0) = 1 AND IsDeleted = 0;

END