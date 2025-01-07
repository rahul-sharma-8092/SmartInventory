-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE   PROCEDURE AddEmailHistoryWithOTP
	@StoreUserId INT,
	@OTP NVARCHAR(10),
	@To NVARCHAR(4000),
	@From NVARCHAR(255),
	@Subject NVARCHAR(MAX),
	@Body NVARCHAR(MAX),
	@Status INT
AS
BEGIN
	SET NOCOUNT OFF;

    INSERT INTO EmailHistory(StoreUserId, OTP, [To], [From], [Subject], Body, [Status])
	VALUES(@StoreUserId, @OTP, @To, @From, @Subject, @Body, @Status)

END