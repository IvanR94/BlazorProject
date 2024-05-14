-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE Delete_Vehicle
	@VoziloID INT
AS
BEGIN
	DELETE FROM Vozilo
	WHERE VoziloID = @VoziloID
END
GO
