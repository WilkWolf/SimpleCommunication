using Newtonsoft.Json;
using SimpleCommunication.Infrastructure;
using System;

namespace SimpleCommunication.Core
{
    public class DatabaseGetView : IDatabaseGetView
    {
        public string GetTopTenCustomerInMonth()
        {
            try
            {
                StoredProcedure storedProcedure = new();

                var topUsers = storedProcedure.TopTenCustomerInMonth();
                var json = JsonConvert.SerializeObject(topUsers);
                return json;
            }
            catch (Exception e)
            {
                return $"Problem in converting data to json. {e.Message}";
            }
        }

        public string GetSumOfOrdersInSixMonth()
        {
            try
            {
                StoredProcedure storedProcedure = new();

                var sumOfOrders = storedProcedure.GetSumOfOrdersInSixMonth();
                var json = JsonConvert.SerializeObject(sumOfOrders);
                return json;
            }
            catch (Exception e)
            {
                return $"Problem in converting data to json. {e.Message}";
            }
        }

    }
}


