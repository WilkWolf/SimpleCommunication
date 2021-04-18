using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SimpleCommunication.Core;

namespace SimpleCommunication.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TopTenClientController : ControllerBase
    {
        private readonly ILogger<TopTenClientController> _logger;

        public TopTenClientController(ILogger<TopTenClientController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public string Get()
        {
            try
            {
                DatabaseGetView databaseGetView = new();
                string topTenUsersJson = databaseGetView.GetTopTenCustomerInMonth();
                return topTenUsersJson;
            }
            catch
            {
                return "Some problem occure";
            }
        }
    }
}
