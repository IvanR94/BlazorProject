USE [IzvestajTehnickogBlazor]
GO
/****** Object:  StoredProcedure [dbo].[Get_All_Vehicles]    Script Date: 14.3.2024. 18:27:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[Get_All_Vehicles]
AS
BEGIN
	SELECT	Vozilo.VoziloID, Vozilo.MarkaVozila, Vozilo.ModelVozila, Vozilo.Godiste, CONCAT(Vlasnik.Ime, ' ', Vlasnik.Prezime) AS FullName
	FROM	Vozilo
			INNER JOIN Vlasnik
				ON Vozilo.VlasnikID = Vlasnik.VlasnikID
END
