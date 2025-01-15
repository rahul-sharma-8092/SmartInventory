-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE   PROCEDURE TrackLoginHistory
	@StoreUserID INT,
	@Email NVARCHAR(255),
	@IpAddress NVARCHAR(20),
	@Message NVARCHAR(4000),
	@IsFailed BIT
AS
BEGIN
	
	INSERT INTO LoginHistory(StoreUserID, Email, IpAddress, [Message], IsFailed)
	VALUES(@StoreUserID, @Email, @IpAddress, @Message, @IsFailed)

END