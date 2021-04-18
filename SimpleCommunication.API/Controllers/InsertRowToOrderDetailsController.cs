using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SimpleCommunication.Core;

namespace SimpleCommunication.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InsertRowToOrderDetailsController : ControllerBase
    {
        private readonly ILogger<InsertRowToOrderDetailsController> _logger;

        public InsertRowToOrderDetailsController(ILogger<InsertRowToOrderDetailsController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public string Post()
        {
            try
            {
                DatabaseInsertRows databaseInsertRow = new();
                return databaseInsertRow.AddRowsIntoOrderDetailsTable();
            }
            catch
            {
                return "Some problem occur F";
            }
        }
    }
}
