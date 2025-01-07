-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- EXEC GetUserAuthDetailsByEmail 'rahulsh8092@gmail.com'
-- =============================================
CREATE   PROCEDURE GetUserAuthDetailsByEmail
	@Email NVARCHAR(255)
AS
BEGIN
		
	Select StoreUserID, CONCAT(FirstName, ' ', LastName) AS FullName, Email, [Password], GroupId, Mobile, [Status], 
	ForceUpdatePassword, Is2FAEnabled, IsOTPEnabled, 
	IIF(WrongLoginAttempt >= 5 AND DATEDIFF(MINUTE, ISNULL(LoginAttemptTime, GETDATE()), GETDATE()) < 10, 1, 0) AS IsTempBlocked,
	IIF(ISNULL(ForceUpdatePassword,0) = 1 AND DATEDIFF(DAY, ISNULL(LastModifiedPassword, GETDATE()), GETDATE()) < 30, 1, 0) AS ForceUpdatePassword
	
	FROM StoreUser WITH (NOLOCK) WHERE Email = @Email AND IsDeleted = 0;

END