CREATE PROCEDURE [dbo].[SP_User_GetAllActive]
AS
BEGIN
	SELECT	[User_Id],
			[First_Name],
			[Last_Name],
			[Email],
			[CreatedAt],
			[DisabledAt] 
		FROM [User]
		WHERE [DisabledAt] IS NULL
END
