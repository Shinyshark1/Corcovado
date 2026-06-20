using DAL.Configurations.Constants;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Configurations
{
    public class DatabaseFileConfiguration : IEntityTypeConfiguration<DatabaseFile>
    {
        public void Configure(EntityTypeBuilder<DatabaseFile> builder)
        {
            builder.HasKey(databaseFile => databaseFile.Id);

            builder.Property(databaseFile => databaseFile.FileName)
                .HasMaxLength(DatabaseFileConstants.FileNameLength)
                .IsRequired();

            builder.Property(databaseFile => databaseFile.FileExtension)
                .HasMaxLength(DatabaseFileConstants.FileExtensionLength)
                .IsRequired();
        }
    }
}
