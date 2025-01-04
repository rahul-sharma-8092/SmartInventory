-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE     PROCEDURE [dbo].[GetUserFullDetails]
	@UserId INT,
	@Email NVARCHAR(100)
AS
BEGIN
	SELECT UserID, LTRIM(RTRIM(FirstName)) AS FirstName, LTRIM(RTRIM(LastName)) AS LastName, LTRIM(RTRIM(Email)) AS Email,
	RoleId, LTRIM(RTRIM([Role])) AS [Role] FROM Users WITH (NOLOCK)
	WHERE UserID = @UserId AND Email = @Email
END