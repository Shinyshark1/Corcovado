namespace DTO.DatabaseFile
{
    public class DatabaseFileDTO
    {
        public int DatabaseFileId { get; init; }

        public required string FileName { get; init; }

        public required string FileExtension { get; init; }
    }
}
