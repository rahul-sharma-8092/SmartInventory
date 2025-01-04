-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE   PROCEDURE GetUserAuthDetailsByEmail
	@Email NVARCHAR(100)
AS
BEGIN
	SELECT UserID, LTRIM(RTRIM(FirstName)) AS FirstName, LTRIM(RTRIM(LastName)) AS LastName, LTRIM(RTRIM(Email)) AS Email,
	LTRIM(RTRIM([Password])) AS [Password], RoleId, LTRIM(RTRIM([Role])) AS [Role] FROM Users WHERE Email = @Email
END