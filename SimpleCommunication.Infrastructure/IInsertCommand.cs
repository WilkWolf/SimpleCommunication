using SimpleCommunication.Infrastructure.Models;
using System.Collections.Generic;

namespace SimpleCommunication.Infrastructure
{
    public interface IInsertCommand
    {
        public string InsertRowsIntoOrderTable(List<OrderModel> orderList);
        public string InsertRowsIntoOrderDetailsTable(List<OrderDetailsModel> orderList);
    }
}