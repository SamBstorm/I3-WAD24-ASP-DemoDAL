CREATE PROCEDURE [dbo].[SP_Cocktail_Insert]
	@name NVARCHAR(64),
	@description NVARCHAR(512) NULL,-- NULL manquant pour la description
	@instructions NVARCHAR(MAX),	-- NULL n'est pas valable pour les instructions
	@user_id UNIQUEIDENTIFIER
AS
BEGIN
	INSERT INTO [Cocktail] ([Name],[Description],[Instructions],[CreatedBy])
		OUTPUT [inserted].[Cocktail_Id]
		VALUES
			(@name, @description, @instructions, @user_id);
END