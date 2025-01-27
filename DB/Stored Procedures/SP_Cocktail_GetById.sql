CREATE PROCEDURE [dbo].[SP_Cocktail_GetById]
	@cocktail_id UNIQUEIDENTIFIER
AS
BEGIN
	SELECT	[Cocktail_Id],
			[Name], 
			[Description],
			[Instructions],
			[CreatedBy],
			[CreatedAt]
		FROM [Cocktail]
	WHERE [Cocktail_Id] = @cocktail_id
END