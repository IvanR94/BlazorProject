USE [IzvestajTehnickogBlazor]
GO
/****** Object:  StoredProcedure [dbo].[Add_New_Tech_Report]    Script Date: 17.3.2024. 15:33:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[Add_New_Tech_Report]
	@ZaposleniID INT,
	@TipTehnickogPregledaID INT,
	@DatumVrsenjaTehnickogPregleda DATE,
	@StatusTehnickogPregleda BIT,
	@MarkaVozila NVARCHAR(50),
	@ModelVozila NVARCHAR(50),
	@Godiste INT,
	@ImeVlasnika NVARCHAR(50),
	@PrezimeVlasnika NVARCHAR(250)
AS
BEGIN
	INSERT INTO Vlasnik
	(
		Ime,
		Prezime
	)
	VALUES
	(
		@ImeVlasnika,
		@PrezimeVlasnika
	)

	DECLARE @LastVlasnikID INT;
	SET @LastVlasnikID = SCOPE_IDENTITY();

	INSERT INTO Vozilo
	(
		MarkaVozila,
		ModelVozila,
		Godiste,
		VlasnikID
	)
	VALUES
	(
		@MarkaVozila,
		@ModelVozila,
		@Godiste,
		@LastVlasnikID
	)

	DECLARE @LastVehicleID INT;
	SET @LastVehicleID = SCOPE_IDENTITY();

	INSERT INTO IzvestajTehnickogPregleda
	(
		ZaposleniID,
		TipTehnickogPregledaID,
		DatumVrsenjaTehnickogPregleda,
		StatusTehnickogPregleda,
		VoziloID
	)
	VALUES
	(
		@ZaposleniID,
		@TipTehnickogPregledaID,
		@DatumVrsenjaTehnickogPregleda,
		@StatusTehnickogPregleda,
		@LastVehicleID
	)
END
