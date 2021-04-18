USE [Shop]
GO
/****** Object:  StoredProcedure [dbo].[TopTenCustomerInMonth]    Script Date: 18.04.2021 23:33:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		WilkWolf
-- Create date: 18.04.2021
-- Description:	Stored procedure to show top ten customers who have the most orders in current month
-- In one order is many orderDetails but we count only full order, not product in. 
-- =============================================
ALTER PROCEDURE [dbo].[TopTenCustomerInMonth]
AS
BEGIN
Declare 
@FirstDayOfCurrentMonth date,
@LastDayOfCurrentMonth date,
@FirstDayOfPrevMonth date,
@LastDayOfPrevMonth date,
@FirstDayOfTwoMonthAgo date,
@LastDayOfTwoMonthAgo date;

set @FirstDayOfCurrentMonth = (select CONVERT(varchar,dateadd(d,-(day(getdate()-1)),getdate()),106));
set @LastDayOfCurrentMonth = (select CONVERT(varchar,dateadd(d,-(day(dateadd(m,1,getdate()))),dateadd(m,1,getdate())),106));
set @FirstDayOfPrevMonth = (select CONVERT(varchar,dateadd(d,-(day(dateadd(m,-1,getdate()-2))),dateadd(m,-1,getdate()-1)),106));
set @LastDayOfPrevMonth = (select CONVERT(varchar,dateadd(d,-(day(dateadd(m,1,getdate()))),dateadd(m, 0,getdate())),106));
set @FirstDayOfTwoMonthAgo = (select CONVERT(varchar,dateadd(d,-(day(dateadd(m,-1,getdate()-2))),dateadd(m,-2,getdate()-1)),106));
set @LastDayOfTwoMonthAgo = (select CONVERT(varchar,dateadd(d,-(day(dateadd(m,1,getdate()))),dateadd(m,-1,getdate())),106));

	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT top(10) customer.Id, count(ord.CustomerId) as 'Count of orders', Concat(customer.Name, ' ', customer.Surname) as Fullname, Month(ord.CreatedDate) as Month
	from Customer customer 
		inner join dbo.[Order] ord 
		on customer.Id = ord.CustomerId
	where ord.CreatedDate >= @FirstDayOfCurrentMonth and ord.CreatedDate <= @LastDayOfCurrentMonth
	group by   customer.Surname, customer.Name, Month(ord.CreatedDate), customer.Id
		--order by 2 desc
		Union
			SELECT top(10) customer.Id, count(ord.CustomerId) as 'Count of orders', Concat(customer.Name, ' ', customer.Surname) as Fullname, Month(ord.CreatedDate) as Month
	from Customer customer 
		inner join dbo.[Order] ord 
		on customer.Id = ord.CustomerId
	where ord.CreatedDate >= @FirstDayOfPrevMonth and ord.CreatedDate <= @LastDayOfPrevMonth
	group by   customer.Surname, customer.Name, Month(ord.CreatedDate), customer.Id
		--order by 2 desc
		Union
	SELECT top(10) customer.Id, count(ord.CustomerId) as 'Count of orders', Concat(customer.Name, ' ', customer.Surname) as Fullname, Month(ord.CreatedDate) as Month
	from Customer customer 
		inner join dbo.[Order] ord 
		on customer.Id = ord.CustomerId
	where ord.CreatedDate >= @FirstDayOfTwoMonthAgo and ord.CreatedDate <= @LastDayOfTwoMonthAgo
	group by   customer.Surname, customer.Name, Month(ord.CreatedDate), customer.Id
		order by 4 desc,2 desc
END
