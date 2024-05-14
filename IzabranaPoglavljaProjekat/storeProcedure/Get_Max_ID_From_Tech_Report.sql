-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE Get_Max_ID_From_Tech_Report 

AS
BEGIN
	SELECT	MAX(BrojIzvestajaID)
	FROM	IzvestajTehnickogPregleda;
END
GO
