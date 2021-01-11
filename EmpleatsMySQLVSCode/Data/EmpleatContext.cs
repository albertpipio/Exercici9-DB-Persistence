using Microsoft.EntityFrameworkCore;
using EmpleatsSQLVSCode.Models;

namespace EmpleatsSQLVSCode.Data
{
    public class EmpleatContext : DbContext
    {
        public EmpleatContext (DbContextOptions<EmpleatContext> options)
            : base(options)
        {
        }

        public DbSet<Empleat> Empleat { get; set; }
    }
}