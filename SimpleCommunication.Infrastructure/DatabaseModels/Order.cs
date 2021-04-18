using System;
using System.Collections.Generic;

#nullable disable

namespace SimpleCommunication.Infrastructure.DatabaseModels
{
    public partial class Order
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
