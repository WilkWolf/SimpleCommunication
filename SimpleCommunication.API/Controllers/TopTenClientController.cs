using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SimpleCommunication.API.Models;
using System.Collections.Generic;
using System.Linq;

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
        public IEnumerable<ClientWithOrderQuantity> Get()
        {
            return Enumerable.Range(1, 10).Select(index => new ClientWithOrderQuantity
            {
                FullName = "John Doe",
                ClientId = 1,
                OrderQuantity = 1
            })
            .ToArray();
        }
    }
}
