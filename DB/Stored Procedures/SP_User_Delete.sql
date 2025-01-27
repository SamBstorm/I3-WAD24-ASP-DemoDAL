CREATE PROCEDURE [dbo].[SP_User_Delete]
	@user_id UNIQUEIDENTIFIER
AS
BEGIN
	UPDATE [Cocktail]
		SET [CreatedBy] = NULL
		WHERE [CreatedBy] = @user_id;
	UPDATE [Comment]
		SET [CreatedBy] = NULL
		WHERE [CreatedBy] = @user_id;
	UPDATE [User]
		SET [DisabledAt] = GETDATE()
		WHERE [User_Id] = @user_id;
END