using Microsoft.EntityFrameworkCore;
using SimpleCommunication.Infrastructure.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleCommunication.Infrastructure
{
    public class StoredProcedure : IStoredProcedure
    {
        public List<SPSumOfOrder> GetSumOfOrdersInSixMonth()
        {
            try
            {
                var context = new ShopContext();
                var sumOfOrders = context.SPSumOfOrders.FromSqlInterpolated($"SumOfOrdersForLastSixMonths").ToList();
                return sumOfOrders;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public List<SPTopTenCustomerInMonth> TopTenCustomerInMonth()
        {
            try
            {
                var context = new ShopContext();
                var topUsers = context.SPTopTenCustomerInMonths.FromSqlInterpolated($"TopTenCustomerInMonth").ToList();
                return topUsers;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
