using Microsoft.EntityFrameworkCore;
using EmpleatsMySQLVSCode.Models;

namespace EmpleatsMySQLVSCode.Data
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