Use SacGo
GO

IF EXISTS
(select * from Information_schema.Routines where SPECIFIC_SCHEMA='dbo' 
AND SPECIFIC_NAME = 'ADD_NEW_PLACE_CATEGORY' AND Routine_Type='PROCEDURE')
begin
	drop procedure dbo.ADD_NEW_PLACE_CATEGORY
end
GO
--	=============================================
--  Author:		Aryan Maroufkhani
--  Description:	save a new place category
--  =============================================
CREATE PROCEDURE dbo.ADD_NEW_PLACE_CATEGORY
	@name as varchar(100)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	-- check for duplicate
	if exists (select name from dbo.PlaceCategories where name = @name)
	begin
		RAISERROR('Place category already exists' ,11, 2)
	end

    -- Insert statements for procedure here
	INSERT INTO dbo.PlaceCategories ([name])
	values (@name)
END
GO
