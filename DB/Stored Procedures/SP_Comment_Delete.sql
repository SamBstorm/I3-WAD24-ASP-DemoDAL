CREATE PROCEDURE [dbo].[SP_Comment_Delete]
	@comment_id UNIQUEIDENTIFIER
AS
BEGIN
	DELETE
		FROM [Comment]
		WHERE [Comment_Id] = @comment_id
END