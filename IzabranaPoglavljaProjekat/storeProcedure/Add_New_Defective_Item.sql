USE [IzvestajTehnickogBlazor]
GO
/****** Object:  StoredProcedure [dbo].[Add_New_Defective_Item]    Script Date: 17.3.2024. 15:25:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[Add_New_Defective_Item]
	@TechReportID INT,
	@NazivStavke NVARCHAR(50),
	@OpisStavke NVARCHAR(MAX)
AS
BEGIN
	DECLARE @MaxID INT
	SELECT @MaxID = MAX(NeispravneStavkeID)
					FROM NeispravneStavke
	INSERT INTO NeispravneStavke
	(
		NeispravneStavkeID,
		BrojIzvestajaID,
		NazivNeispravnogDela,
		OpisNeispravnosti
	)
	VALUES
	(
		@MaxID + 1,
		@TechReportID,
		@NazivStavke,
		@OpisStavke
	)
END
