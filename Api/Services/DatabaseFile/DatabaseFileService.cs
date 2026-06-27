using DAL.Context;
using DTO.DatabaseFile;
using Microsoft.EntityFrameworkCore;

namespace Api.Services.DatabaseFile
{
    public class DatabaseFileService
    {
        private readonly CorcovadoDbContext _dbContext;
        private readonly ILogger<DatabaseFileService> _logger;

        public DatabaseFileService(CorcovadoDbContext dbContext, ILogger<DatabaseFileService> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<bool> DeleteDatabaseFile(int databaseFileId)
        {
            var deletedFiles = await _dbContext.DatabaseFile
                .Where(dbf => dbf.Id == databaseFileId)
                .ExecuteDeleteAsync();

            if(deletedFiles == 0 )
            {
                _logger.LogTrace("No database file with id {DatabaseFileId} was found to delete.", databaseFileId);
                return false;
            }

            return true;
        }

        // upload
    }
}
