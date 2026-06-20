using Api.DTOs.DatabaseFile;
using DAL.Context;
using Microsoft.EntityFrameworkCore;

namespace Api.Services.DatabaseFile
{
    public class DatabaseFileProvider
    {
        private readonly CorcovadoDbContext _dbContext;

        public DatabaseFileProvider(CorcovadoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<DatabaseFileDTO>> GetDatabaseFiles()
        {
            var result = await _dbContext.DatabaseFile
                .Select(x => new DatabaseFileDTO 
                { 
                    DatabaseFileId = x.Id,
                    FileName = x.FileName,
                    FileExtension = x.FileExtension
                }).ToListAsync();

            return result;
        }
    }
}
