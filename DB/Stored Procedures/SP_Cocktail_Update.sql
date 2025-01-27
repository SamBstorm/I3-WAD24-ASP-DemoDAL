CREATE PROCEDURE [dbo].[SP_Cocktail_Update]
	@cocktail_id UNIQUEIDENTIFIER,
	@name NVARCHAR(64),
	@description NVARCHAR(512) NULL,
	@instructions NVARCHAR(MAX)
AS
BEGIN
	UPDATE [Cocktail]
		SET [Name] = @name,
			[Description] = @description,
			[Instructions] = @instructions
		WHERE [Cocktail_Id] = @cocktail_id
END
