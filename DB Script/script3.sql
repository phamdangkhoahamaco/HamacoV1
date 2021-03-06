USE [hamaco]
GO
/****** Object:  StoredProcedure [dbo].[bc_DNDH]    Script Date: 8/17/2020 10:12:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	bao cao danh muc don dat hang noi bo
-- =============================================
CREATE PROCEDURE [dbo].[bc_DNDH] 
	-- Add the parameters for the stored procedure here
	@StockCode varchar(100), @CompanyCode char(4),@Year int, @Month int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	if @StockCode = '' begin
		SELECT MMDoc, MMHeader from MMDocument where CompanyCode = @CompanyCode 
		and Year(RefDate) = @Year and Month(RefDate) = @Month
		order by MMDoc
	end
	else
	begin
		SELECT MMDoc,MMHeader from MMDocument where StockCode1=@StockCode and CompanyCode = @CompanyCode 
		and Year(RefDate) = @Year and Month(RefDate) = @Month
		order by MMDoc
	end
END
GO
/****** Object:  StoredProcedure [dbo].[bc_VATO]    Script Date: 8/17/2020 10:12:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[bc_VATO] 
	-- Add the parameters for the stored procedure here
	@StockCode varchar(100), @CompanyCode char(4)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	if @StockCode = '' begin
	SELECT StockCode, StockName,Inactive from Stock where CompanyCode = @CompanyCode order by StockCode
	end
	else
	begin
	SELECT StockCode, StockName,Inactive from Stock where StockCode=@StockCode and CompanyCode = @CompanyCode order by StockCode
	end
END
GO
