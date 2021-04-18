using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SimpleCommunication.Core;

namespace SimpleCommunication.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GetSumOfOrdersController : ControllerBase
    {
        private readonly ILogger<GetSumOfOrdersController> _logger;

        public GetSumOfOrdersController(ILogger<GetSumOfOrdersController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public string Get()
        {
            try
            {
                DatabaseGetView databaseGetView = new();
                string sumOfOrders = databaseGetView.GetSumOfOrdersInSixMonth();
                return sumOfOrders;
            }
            catch
            {
                return "Some problem occure";
            }
        }
    }
}
