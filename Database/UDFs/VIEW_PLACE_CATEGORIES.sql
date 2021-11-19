
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
