CREATE PROCEDURE [dbo].[SP_Comment_GetByCocktailId]
	@cocktail_id UNIQUEIDENTIFIER
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
		WHERE [Concern] = @cocktail_id
END