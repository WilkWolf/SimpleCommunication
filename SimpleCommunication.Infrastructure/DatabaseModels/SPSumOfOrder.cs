using Microsoft.EntityFrameworkCore;

namespace SimpleCommunication.Infrastructure.DatabaseModels
{
    [Keyless]
    public class SPSumOfOrder
    {
        public int Month { get; set; }
        public int SumOfOrders { get; set; }
    }
}
