CREATE PROCEDURE [dbo].[SP_Comment_GetByUserId]
	@user_id UNIQUEIDENTIFIER
AS
BEGIN
	SELECT	[Comment_id],
			[Title],
			[Content],
			[Concern],
			[CreatedBy],
			[CreatedAt],
			[Note]
		FROM [Comment]
		WHERE [CreatedBy] = @user_id
END
