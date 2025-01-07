-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE   PROCEDURE AddStoreUserOTP
	@StoreUserId INT,
	@OTP NVARCHAR(10)
AS
BEGIN
	SET NOCOUNT OFF;

	UPDATE StoreUser SET OTP = @OTP, OTPTimeStamp = GETDATE() WHERE StoreUserId = @StoreUserId AND IsDeleted = 0;

END