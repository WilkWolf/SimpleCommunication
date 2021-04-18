using Microsoft.EntityFrameworkCore;

namespace SimpleCommunication.Infrastructure.DatabaseModels
{
    [Keyless]
    public class SPTopTenCustomerInMonth
    {
        public int Id { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.Column("Count of orders")]
        public int CountOfOrders { get; set; }
        public string Fullname { get; set; }
        public int Month { get; set; }
    }
}
