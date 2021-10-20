using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telecom.Domain;

namespace Telecom.Data
{
    public class TelecomContext : DbContext
    {
        public DbSet<Person> People { get; set; }

        public DbSet<Account> Accounts { get; set; }

        public DbSet<Device> Devices { get; set; }

        public DbSet<Plan> Plans { get; set; }

        public TelecomContext(DbContextOptions options) : base(options)
        {

        }

        public TelecomContext()
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=telecom10202021.database.windows.net;Initial Catalog=Telecom;User ID=users;Password=Welcome1;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")
                    .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Name }, Microsoft.Extensions.Logging.LogLevel.Information)
                    .EnableSensitiveDataLogging();
                    
            }
        }

    }
}
