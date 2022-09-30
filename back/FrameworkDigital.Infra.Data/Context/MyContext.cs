using FrameworkDigital.Domain.Leads.Entities;
using FrameworkDigital.Infra.Data.Extensions;
using FrameworkDigital.Infra.Data.Leads.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace FrameworkDigital.Infra.Data.Context
{
    public class MyContext : DbContext
    {
        public DbSet<Lead> Lead { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddConfiguration(new LeadMap());
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        }
    }
}
