using Microsoft.EntityFrameworkCore;
using case_cadding_dropdown.Models;

namespace case_cadding_dropdown.Data
{
    public class CaseCaddingDbContext : DbContext
    {
        public CaseCaddingDbContext(DbContextOptions<CaseCaddingDbContext> options) : base(options)
        {

        }
        public DbSet<country> CountryTable { get; set; }
        public DbSet<city> CityTable { get; set; }
        public DbSet<state> StateTable { get; set; }

    }
}
