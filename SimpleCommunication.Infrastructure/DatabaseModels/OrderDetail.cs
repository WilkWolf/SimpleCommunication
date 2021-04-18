﻿using System;
using System.Collections.Generic;

#nullable disable

namespace SimpleCommunication.Infrastructure.DatabaseModels
{
    public partial class OrderDetail
    {
        public int ProductId { get; set; }
        public int OrderId { get; set; }
        public int Quantity { get; set; }

        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
