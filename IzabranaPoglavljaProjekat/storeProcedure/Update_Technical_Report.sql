USE [IzvestajTehnickogBlazor]
GO
/****** Object:  StoredProcedure [dbo].[Update_Technical_Report]    Script Date: 23.3.2024. 12:24:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[Update_Technical_Report]
	@IDTehnickog INT,
	@TipTehnickogID INT
AS
BEGIN
	UPDATE	IzvestajTehnickogPregleda
	SET		TipTehnickogPregledaID = @TipTehnickogID
	WHERE	BrojIzvestajaID = @IDTehnickog
END
