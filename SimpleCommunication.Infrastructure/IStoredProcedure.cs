using SimpleCommunication.Infrastructure.DatabaseModels;
using System.Collections.Generic;

namespace SimpleCommunication.Infrastructure
{
    public interface IStoredProcedure
    {
        public List<SPTopTenCustomerInMonth> TopTenCustomerInMonth();
    }
}