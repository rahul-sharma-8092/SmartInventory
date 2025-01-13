-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE   PROCEDURE AddStoreUserTOTP
	@StoreUserId INT,
	@Email NVARCHAR(255),
	@SecretKey NVARCHAR(255)
AS
BEGIN
	
	UPDATE StoreUser SET SecretKey2FA = @SecretKey, TimeStamp2FA = GETDATE(), Is2FAEnabled = 1
	WHERE IsDeleted = 0 AND StoreUserID = @StoreUserId AND Email = @Email;

END