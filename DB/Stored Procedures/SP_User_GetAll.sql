CREATE PROCEDURE [dbo].[SP_User_GetAll]
AS
BEGIN
	SELECT [User_Id], [First_Name], [Last_Name], [Email], [CreatedAt], [DisabledAt] FROM [User]
END
