CREATE PROCEDURE SP_SM_SUBMODULE_INSERT
@NAME NVARCHAR(200),
@MODULE_ID INT,
@SUBMODULE_KEY NVARCHAR(200),
@POSITION INT, 
@ROUTE NVARCHAR(200),
@IS_ACTIVE INT
AS
BEGIN
	INSERT INTO HMS_SM_SUBMODULE(NAME, MODULE_ID, SUBMODULE_KEY, POSITION, ROUTE, IS_ACTIVE)
	VALUES
	(
		@NAME, @MODULE_ID, @SUBMODULE_KEY, @POSITION, @ROUTE, @IS_ACTIVE
	)
END

GO

EXEC SP_SM_SUBMODULE_INSERT 'Blood Group', 2, 'BLOOD_GROUP',2,'BloodGroup/Index', 1

SELECT * FROM HMS_SM_SUBMODULE

