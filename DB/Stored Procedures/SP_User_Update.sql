CREATE PROCEDURE [dbo].[SP_User_Update]
	@first_name NVARCHAR(64),
	@last_name NVARCHAR(64),
	@email NVARCHAR(320),
	@user_id UNIQUEIDENTIFIER
AS
BEGIN
	UPDATE [User]
		SET	[First_Name] = @first_name,
			[Last_Name] = @last_name,
			[Email] = @email
		WHERE [User_Id] = @user_id
END
