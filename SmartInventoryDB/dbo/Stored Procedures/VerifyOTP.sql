-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE   PROCEDURE VerifyOTP
	@StoreUserId INT,
	@Email NVARCHAR(255),
	@Otp NVARCHAR(10),
	@ReturnVal INT OUTPUT
AS
BEGIN
	
	IF EXISTS (SELECT 1 FROM StoreUser WHERE StoreUserId = @StoreUserId AND Email = @Email AND OTPTimeStamp < DATEADD(MINUTE, -5, GETDATE()))
    BEGIN
        SET @ReturnVal = 0;
    END
    ELSE IF EXISTS (SELECT 1 FROM StoreUser WHERE StoreUserId = @StoreUserId AND Email = @Email AND Otp = @Otp AND OTPTimeStamp > DATEADD(MINUTE, -5, GETDATE()))
    BEGIN
        SET @ReturnVal = 1;
		UPDATE StoreUser SET OTP = NULL WHERE StoreUserId = @StoreUserId AND Email = @Email;
    END
	ELSE
	BEGIN
		SET @ReturnVal = 2;
	END

END