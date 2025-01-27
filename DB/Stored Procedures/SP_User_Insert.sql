CREATE PROCEDURE [dbo].[SP_User_Insert]
	@first_name NVARCHAR(64),
	@last_name NVARCHAR(64),
	@email NVARCHAR(320),
	@password NVARCHAR(32)
AS
BEGIN
	DECLARE @salt UNIQUEIDENTIFIER
	SET @salt = NEWID()
	INSERT INTO [User] ([First_Name],[Last_Name],[Email],[Password],[Salt])
	OUTPUT [inserted].[User_Id]
	VALUES (@first_name, @last_name, @email, [dbo].[SF_SaltAndHash](@password, @salt), @salt)
END