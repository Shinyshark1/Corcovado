using Api.Services.DatabaseFile;
using DTO.DatabaseFile;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DatabaseFileController : ControllerBase
    {
        private readonly DatabaseFileProvider _databaseFileProvider;

        public DatabaseFileController(DatabaseFileProvider databaseFileProvider)
        {
            _databaseFileProvider = databaseFileProvider;
        }

        [HttpGet]
        public async Task<ActionResult<List<DatabaseFileDTO>>> Get()
        {
            var result = await _databaseFileProvider.GetDatabaseFiles();
            return Ok(result);
        }
    }
}
