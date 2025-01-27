CREATE PROCEDURE [dbo].[SP_Cocktail_GetByUserId]
	@user_id UNIQUEIDENTIFIER
AS
BEGIN
	SELECT	[Cocktail_Id],
			[Name], 
			[Description],
			[Instructions],
			[CreatedBy],
			[CreatedAt]
		FROM [Cocktail]
	WHERE [CreatedBy] = @user_id
END