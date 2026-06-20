using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Context
{
    public class CorcovadoDbContext : DbContext
    {
        public CorcovadoDbContext(DbContextOptions<CorcovadoDbContext> options) : base(options)
        {
        }

        // DbSets here
        public DbSet<DatabaseFile> DatabaseFile => Set<DatabaseFile>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CorcovadoDbContext).Assembly);
        }
    }
}
