-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE Delete_all_item_for_techReport
	@IDTehnickog INT
AS
BEGIN
	DELETE FROM NeispravneStavke
	WHERE BrojIzvestajaID = @IDTehnickog
END
GO
