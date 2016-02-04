using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP5API.Models
{
    using Microsoft.Data.Entity;

    // >dnx . ef migrations add testMigration
    public class DataEventRecordContext : DbContext
    {
        public DbSet<DataEventRecord> DataEventRecords { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<DataEventRecord>().HasKey(m => m.Id);
            base.OnModelCreating(builder);
        }
    }
}
