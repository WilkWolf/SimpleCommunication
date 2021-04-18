namespace SimpleCommunication.Core
{
    public interface IDatabaseGetView
    {
        public string GetTopTenCustomerInMonth();
        public string GetSumOfOrdersInSixMonth();
    }
}