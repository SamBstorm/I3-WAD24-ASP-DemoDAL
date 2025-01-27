CREATE PROCEDURE [dbo].[SP_Comment_Update]
	@comment_id UNIQUEIDENTIFIER,
	@title NVARCHAR(64),
	@content NVARCHAR(512),
	@note TINYINT NULL
AS
BEGIN
	UPDATE	[Comment]
		SET [Title] = @title,
			[Content] = @content,
			[Note] = @note
		WHERE [Comment_Id] = @comment_id
END