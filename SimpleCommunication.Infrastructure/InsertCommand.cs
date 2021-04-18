using SimpleCommunication.Infrastructure.DatabaseModels;
using System.Collections.Generic;
using SimpleCommunication.Infrastructure.Models;
using System;

namespace SimpleCommunication.Infrastructure
{
    public class InsertCommand : IInsertCommand
    {
        public string InsertRowsIntoOrderTable(List<OrderModel> orderList)
        {
            try
            {
                List<Order> list = new();
                using (var context = new ShopContext())
                {
                    foreach (var order in orderList)
                    {
                        var newOrder = new Order()
                        {
                            CustomerId = order.CustomerId,
                            CreatedDate = order.CreatedDate
                        };
                        list.Add(newOrder);
                    }
                    context.Orders.AddRange(list);
                    context.SaveChanges();
                    return "Added 200 rows into Order table";
                }
            }
            catch (Exception e)
            {
                return "Problem with adding rows." + e.Message;
            }
        }

        public string InsertRowsIntoOrderDetailsTable(List<OrderDetailsModel> orderList)
        {
            try
            {
                List<OrderDetail> list = new();
                using (var context = new ShopContext())
                {
                    foreach (var order in orderList)
                    {
                        var newOrder = new OrderDetail()
                        {
                            OrderId = order.OrderId,
                            ProductId = order.ProductId,
                            Quantity = order.Quantity
                        };
                        list.Add(newOrder);
                    }
                    context.OrderDetails.AddRange(list);
                    context.SaveChanges();
                    return "Added 500 rows into OrderDetail table";
                }
            }
            catch (Exception e)
            {
                return "Problem with adding rows." + e.Message;
            }
        }
    }
}
