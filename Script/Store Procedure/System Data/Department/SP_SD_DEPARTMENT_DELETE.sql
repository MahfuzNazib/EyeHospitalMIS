CREATE PROCEDURE SP_SD_DEPARTMENT_DELETE
@ID INT
AS
BEGIN
	DELETE TOP (1) FROM HMS_SD_DEPARTMENTS WHERE ID = @ID;
END
