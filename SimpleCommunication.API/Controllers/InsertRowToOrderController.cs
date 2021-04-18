using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SimpleCommunication.Core;

namespace SimpleCommunication.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InsertRowToOrderController : ControllerBase
    {
        private readonly ILogger<InsertRowToOrderController> _logger;

        public InsertRowToOrderController(ILogger<InsertRowToOrderController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public string Post()
        {
            try
            {
                DatabaseInsertRows databaseInsertRow = new();
                databaseInsertRow.AddRowsIntoOrderTable();
                return "Added 200 rows into Order table";
            }
            catch
            {
                return "Some problem occure";
            }
        }
    }
}
