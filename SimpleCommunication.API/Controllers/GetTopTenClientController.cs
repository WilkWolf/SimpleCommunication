using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SimpleCommunication.Core;

namespace SimpleCommunication.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GetTopTenClientController : ControllerBase
    {
        private readonly ILogger<GetTopTenClientController> _logger;

        public GetTopTenClientController(ILogger<GetTopTenClientController> logger)
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
