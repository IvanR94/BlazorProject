-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[Delete_Tech_Report]
	@IzvestajTehnickogID INT
AS
BEGIN
	DELETE FROM IzvestajTehnickogPregleda
	WHERE BrojIzvestajaID = @IzvestajTehnickogID
END