namespace SimpleCommunication.Infrastructure.Models
{
    class TopTenCustomerInMonthModel
    {
        public int Id { get; set; }
        public int CountOfOrders { get; set; }
        public string UsernFullName { get; set; }
        public int Month { get; set; }

    }
}
