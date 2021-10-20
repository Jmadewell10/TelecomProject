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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //One Login per One Person
            modelBuilder.Entity<Person>()
                .HasOne<Login>(p => p.Login)
                .WithOne(l => l.Person)
                .HasForeignKey<Login>(l => l.PersonId);

            //One Account Per One Person
            modelBuilder.Entity<Person>()
                .HasOne<Account>(p => p.Account)
                .WithOne(a => a.Person)
                .HasForeignKey<Account>(a => a.PersonId);

            //Many Devices to Many People
            modelBuilder.Entity<Person>()
                .HasMany<Device>(p => p.Devices)
                .WithMany(d => d.People)
                .UsingEntity<PersonDevice>(pd => pd.HasOne<Device>().WithMany(),
                                           pd => pd.HasOne<Person>().WithMany());

            //Many Plans to Many Accounts
            modelBuilder.Entity<Account>()
                .HasMany<Plan>(a => a.plans)
                .WithMany(pl => pl.Accounts)
                .UsingEntity<AccountPlans>(ap => ap.HasOne<Plan>().WithMany(),
                                           ap => ap.HasOne<Account>().WithMany());

        }

    }
}
