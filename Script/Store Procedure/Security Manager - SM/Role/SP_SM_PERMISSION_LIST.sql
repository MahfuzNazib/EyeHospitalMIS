-- Role Submodule
-- Get All Permission List With Key

CREATE PROCEDURE SP_SM_PERMISSION_LIST
AS
BEGIN
	SELECT ID, DISPLAY_NAME, PERMISSION_KEY, MODULE_ID, IS_TOPBAR, PARENT_ID
	FROM HMS_SM_PERMISSION
	WHERE IS_ACTIVE = 1
END

GO

EXEC SP_SM_PERMISSION_LIST

SELECT * FROM HMS_SM_PERMISSION WHERE IS_TOPBAR IS NOT NULL AND PARENT_ID IS NULL