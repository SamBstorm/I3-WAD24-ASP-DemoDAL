CREATE PROCEDURE [dbo].[SP_Cocktail_Delete]
	@cocktail_id UNIQUEIDENTIFIER
AS
BEGIN
	DELETE 
		FROM [Cocktail]
		WHERE [Cocktail_Id] = @cocktail_id
END