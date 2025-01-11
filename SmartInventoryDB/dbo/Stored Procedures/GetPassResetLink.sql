-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE     PROCEDURE [dbo].[GetPassResetLink]
	@Email NVARCHAR(255),
	@IpAddress NVARCHAR(20),
	@Guid NVARCHAR(255)
AS
BEGIN
	DECLARE @ReturnCode INT = 0;
	DECLARE @GUID_New NVARCHAR(255) = '';
	DECLARE @MinDate DATETIME = '1753-01-01';
	DECLARE @StoreUserID INT = 0;

	IF EXISTS(Select 1 from StoreUser where IsDeleted = 0 AND Email = @Email)
	BEGIN
		SET @StoreUserID  = ISNULL((SELECT StoreUserID FROM StoreUser WHERE IsDeleted = 0 AND Email = @Email),0);

		UPDATE StoreUser SET [Guid] = @Guid, [GuidTimeStamp] = GETDATE(), [IsGuidExpired] = 0, IpAddress = @IpAddress 
		WHERE IsDeleted = 0 AND Email = @Email

		UPDATE ForgotPasswordRequest SET IsDeleted = 1, UpdatedAT = GETDATE() WHERE StoreUserID = @StoreUserID AND IsDeleted = 0;
		
		INSERT INTO ForgotPasswordRequest([Guid], IpAddress, StoreUserID) VALUES(@Guid, @IpAddress, @StoreUserID)

		SET @ReturnCode = 1;
		SET @GUID_New = @Guid;

	END
	ELSE
	BEGIN
		SET @ReturnCode = 0;
	END

	SELECT @ReturnCode AS [ReturnCode], ISNULL(Email,'') AS Email, @GUID_New AS [Guid], 
	ISNULL([GuidTimeStamp], @MinDate) AS [GuidTimeStamp],[IsGuidExpired], CONCAT(FirstName, ' ', LastName) AS FullName 
	FROM StoreUser WHERE ISNULL(IsDeleted,0) = 0 AND ISNULL(Email,'') = @Email;
END