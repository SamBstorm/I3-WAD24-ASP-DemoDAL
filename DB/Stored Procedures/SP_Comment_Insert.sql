CREATE PROCEDURE [dbo].[SP_Comment_Insert]
	@user_id UNIQUEIDENTIFIER,
	@cocktail_id UNIQUEIDENTIFIER,
	@title NVARCHAR(64),
	@content NVARCHAR(512),
	@note TINYINT NULL
AS
BEGIN
	INSERT INTO [Comment] ([CreatedBy],[Concern],[Title],[Content],[Note])
		OUTPUT [inserted].[Comment_Id]
		VALUES
			(@user_id, @cocktail_id, @title, @content, @note)
END
