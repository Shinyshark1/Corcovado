using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class DatabaseFile
    {
        public int Id { get; set; }

        public required string FileName { get; set; }

        /// <remarks>
        /// Include the leading dot, e.g. ".txt", ".pdf", etc.
        /// </remarks>
        public required string FileExtension { get; set; }
    }
}
