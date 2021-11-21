Use SacGo
GO

IF EXISTS
(select * from Information_schema.Routines where SPECIFIC_SCHEMA='dbo' 
AND SPECIFIC_NAME = 'VIEW_PLACE_CATEGORIES' AND Routine_Type='FUNCTION')
begin
	drop function dbo.VIEW_PLACE_CATEGORIES
end
GO

-- =============================================
-- Author:		Aryan Maroufkhani
-- Description:	Get place categories
-- =============================================
CREATE FUNCTION dbo.VIEW_PLACE_CATEGORIES 
(	
	@id bigint
)
RETURNS TABLE 
AS
RETURN 
(
	SELECT
		*
	FROM dbo.PlaceCategories as pc
	where (
		(@id is null) or (@id = pc.id)
	)
)
GO
