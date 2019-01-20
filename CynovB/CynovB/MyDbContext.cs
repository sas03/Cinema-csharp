using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CynovB
{
    class MyDbContext : DbContext
    {
        public DbSet<Film> Films { get; set; }
        public DbSet<LongMetrage> LongMetrages { get; set; }
        public DbSet<CourtMetrage> CourtMetrages { get; set; }
        public DbSet<Serie> Series { get; set; }
        public DbSet<Client> Clients { get; set; }
    }
}
