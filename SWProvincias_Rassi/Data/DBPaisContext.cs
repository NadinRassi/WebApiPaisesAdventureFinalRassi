using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using SWProvincias_Rassi.Models;

namespace SWProvincias_Rassi.Data
{
    public class DBPaisContext: DbContext
    {
        public DBPaisContext(DbContextOptions<DBPaisContext> options) : base(options) { }

        public DbSet<Ciudad> Ciudades { get; set; }

        public DbSet<Provincia> Provincias { get; set; }

    }
}
