CREATE PROCEDURE SP_SM_MODULE_EDIT
@ID INT,
@NAME NVARCHAR(200),
@MODULE_KEY NVARCHAR(200),
@POSITION INT,
@ICON NVARCHAR(200),
@DESCRIPTION NVARCHAR(MAX),
@IS_ACTIVE INT
AS
BEGIN
	UPDATE HMS_SM_MODULE
	SET
	NAME = @NAME,
	MODULE_KEY = @MODULE_KEY,
	POSITION = @POSITION,
	ICON = @ICON,
	DESCRIPTION = @DESCRIPTION,
	IS_ACTIVE = @IS_ACTIVE
	WHERE ID = @ID
END

GO

EXEC SP_SM_MODULE_EDIT 4, 'Patient', 'PATIENT', 4, 'fa fa-user', 'Patient Module', 1

SELECT * FROM HMS_SM_MODULE