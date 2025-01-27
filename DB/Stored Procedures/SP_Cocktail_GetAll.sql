CREATE PROCEDURE [dbo].[SP_Cocktail_GetAll]
AS
BEGIN
	SELECT	[Cocktail_Id],
			[Name], 
			[Description],
			[Instructions],
			[CreatedBy],
			[CreatedAt]
		FROM [Cocktail]
END