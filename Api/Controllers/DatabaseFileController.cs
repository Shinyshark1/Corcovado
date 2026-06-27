using Api.Services.DatabaseFile;
using DTO.DatabaseFile;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DatabaseFileController : ControllerBase
    {
        private readonly DatabaseFileRepository _databaseFileRepository;
        private readonly DatabaseFileService _databaseFileService;

        public DatabaseFileController(DatabaseFileRepository databaseFileRepository, DatabaseFileService databaseFileService)
        {
            _databaseFileRepository = databaseFileRepository;
            _databaseFileService = databaseFileService;
        }

        [HttpGet]
        public async Task<ActionResult<List<DatabaseFileDTO>>> Get()
        {
            var result = await _databaseFileRepository.GetDatabaseFiles();
            return Ok(result);
        }

        [HttpDelete("{databaseFileId}")]
        public async Task<IActionResult> Delete(int databaseFileId)
        {
            var deleteResult = await _databaseFileService.DeleteDatabaseFile(databaseFileId);
            if (!deleteResult)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
