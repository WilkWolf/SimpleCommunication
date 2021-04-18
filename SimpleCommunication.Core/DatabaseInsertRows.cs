﻿using SimpleCommunication.Infrastructure.Models;
using SimpleCommunication.Infrastructure;
using System;
using System.Collections.Generic;

namespace SimpleCommunication.Core
{
    public class DatabaseInsertRows : IDatabaseInsertRows
    {
        public string AddRowsIntoOrderTable()
        {
            try
            {
                InsertCommand insertCommand = new();

                List<OrderModel> orders = new();
                Random random = new();
                for (int idx = 0; idx < 200; idx++)
                {
                    OrderModel order = new();
                    order.CustomerId = random.Next(1, 23);

                    DateTime start = DateTime.Now.AddMonths(-6);
                    int range = (DateTime.Today - start).Days;
                    order.CreatedDate = start.AddDays(random.Next(range));

                    orders.Add(order);
                }

                return insertCommand.InsertRowsIntoOrderTable(orders);
            }
            catch (Exception e)
            {
                return $"Problem in creating data {e.Message}";
            }
        }
    }
}
