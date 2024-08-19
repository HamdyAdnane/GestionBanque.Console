using GestionBanqueDbContext.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionBanqueDbContext.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<InformationsBanque> Banques { get; set; } = null!;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            var ConnectionString = configuration.GetSection("ConnectionString").Value;
            optionsBuilder.UseSqlServer(ConnectionString);
        }
    }
}
