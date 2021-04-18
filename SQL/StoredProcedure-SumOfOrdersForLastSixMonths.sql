USE [Shop]
GO
/****** Object:  StoredProcedure [dbo].[SumOfOrdersForLastSixMonths]    Script Date: 18.04.2021 23:32:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		WilkWolf
-- Create date: 18.04.2021
-- Description:	Get - sum of orders for the last 6 months
-- =============================================
ALTER PROCEDURE [dbo].[SumOfOrdersForLastSixMonths]
AS
BEGIN
Declare 
@LastDayOfCurrentMonth date,
@FirstDayOfSixMonthAgo date;

set @LastDayOfCurrentMonth = (select CONVERT(varchar,dateadd(d,-(day(dateadd(m,1,getdate()))),dateadd(m,1,getdate())),106));
set @FirstDayOfSixMonthAgo = (select CONVERT(varchar,dateadd(d,-(day(dateadd(m,-1,getdate()-2))),dateadd(m,-5,getdate()-1)),106));

	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT  Month(CreatedDate) as Month, count(Id) as SumOfOrders
	from  dbo.[Order] 
	where CreatedDate >= @FirstDayOfSixMonthAgo and CreatedDate <= @LastDayOfCurrentMonth
	group by Month(CreatedDate)

END
