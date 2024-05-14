-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[Update_Vehicle]
	@VoziloID INT,
	@MarkaVozila NVARCHAR(50),
	@ModelVozila NVARCHAR(50),
	@GodisteVozila INT,
	@ImeVlasnika NVARCHAR(50),
	@PrezimeVlasnika NVARCHAR(100)
AS
BEGIN
	DECLARE @idVlasnika INT =
	(SELECT	VlasnikID
	 FROM	Vozilo
	 WHERE VoziloID = @VoziloID
	)

	UPDATE	Vozilo
	SET		MarkaVozila = @MarkaVozila
			, ModelVozila = @ModelVozila
			, Godiste = @GodisteVozila
	WHERE	VoziloID = @VoziloID

	UPDATE	Vlasnik 
	SET		Ime = @ImeVlasnika
			, Prezime = @PrezimeVlasnika
	WHERE VlasnikID = @idVlasnika
END
GO
