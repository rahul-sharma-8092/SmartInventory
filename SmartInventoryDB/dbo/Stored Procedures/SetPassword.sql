-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE SetPassword
	@StoreUserId INT,
	@Email NVARCHAR(255),
	@Password NVARCHAR(MAX)
AS
BEGIN
	SET NOCOUNT OFF;

    UPDATE StoreUser SET [Password] = @Password, LastModifiedPassword = GETDATE(), [Guid] = NULL
	WHERE Email = @Email AND StoreUserID = @StoreUserId AND IsDeleted = 0;
END