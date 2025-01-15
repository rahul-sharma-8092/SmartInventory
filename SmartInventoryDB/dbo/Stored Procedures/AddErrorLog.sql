-- =============================================
-- Author:		Rahul Sharma
-- Create date: 14/01/2025
-- Description:	AddErrorLog
-- =============================================
CREATE   PROCEDURE [dbo].[AddErrorLog]
	@Message NVARCHAR(MAX),
	@StackTrace NVARCHAR(MAX),
	@InnerException NVARCHAR(MAX),
	@URL NVARCHAR(MAX),
	@IpAddress NVARCHAR(20),
	@Browser NVARCHAR(100),
	@LogLevel INT,
	@UserId INT = 0
AS
BEGIN

	INSERT INTO ErrorLog([Message], [StackTrace], [InnerException], [URL], [IpAddress], [Browser], [UserId], [LogLevel])
	VALUES(@Message, @StackTrace, @InnerException, @URL, @IpAddress, @Browser, @UserId, @LogLevel)

END