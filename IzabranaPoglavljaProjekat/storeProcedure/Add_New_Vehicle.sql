-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE Add_New_Vehicle
	@MarkaVozila NVARCHAR(50),
	@ModelVozila NVARCHAR(50),
	@GodisteVozila INT,
	@ImeVlasnika NVARCHAR(50),
	@PrezimeVlasnika NVARCHAR(100)
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
		@GodisteVozila,
		@LastVlasnikID
	)
END
GO
