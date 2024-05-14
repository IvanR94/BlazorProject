-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE Get_Defective_Items_For_Report 
	@TechReportID INT
AS
BEGIN
	SELECT NeispravneStavke.NazivNeispravnogDela, NeispravneStavke.OpisNeispravnosti
	FROM	NeispravneStavke
			INNER JOIN IzvestajTehnickogPregleda
				ON NeispravneStavke.BrojIzvestajaID = IzvestajTehnickogPregleda.BrojIzvestajaID
	WHERE IzvestajTehnickogPregleda.BrojIzvestajaID = @TechReportID
END
GO
