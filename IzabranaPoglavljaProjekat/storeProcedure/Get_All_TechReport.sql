USE [IzvestajTehnickogBlazor]
GO
/****** Object:  StoredProcedure [dbo].[Get_All_TechReport]    Script Date: 16.3.2024. 13:21:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[Get_All_TechReport]
AS
BEGIN
	SELECT	IzvestajTehnickogPregleda.BrojIzvestajaID
			,CONVERT(DATE, IzvestajTehnickogPregleda.DatumVrsenjaTehnickogPregleda) AS DatumVrsenjaTehnickogPregleda
			, IzvestajTehnickogPregleda.StatusTehnickogPregleda
			, IzvestajTehnickogPregleda.Napomena
			, CONCAT(Zaposleni.Ime, ' ', Zaposleni.Prezime) AS ImePrezimeZaposlenog
			, TipTehnickogPregleda.NazivTehnickogPregleda AS TipTehnickogPregleda
			, CONCAT(Vozilo.MarkaVozila, ' ', Vozilo.ModelVozila) AS Vozilo
	FROM	IzvestajTehnickogPregleda
			INNER JOIN Zaposleni
				ON IzvestajTehnickogPregleda.ZaposleniID = Zaposleni.ZaposleniID
			INNER JOIN TipTehnickogPregleda
				ON IzvestajTehnickogPregleda.TipTehnickogPregledaID = TipTehnickogPregleda.TipTehnickogPregledaID
			INNER JOIN Vozilo
				ON IzvestajTehnickogPregleda.VoziloID = Vozilo.VoziloID
END
