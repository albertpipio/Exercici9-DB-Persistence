using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using EmpleatsMySQLVSCode.Data;
using System;
using System.Linq;

namespace EmpleatsMySQLVSCode.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new EmpleatContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<EmpleatContext>>()))
            {
                // Look for any movies.
                if (context.Empleat.Any())
                {
                    return;   // DB has been seeded
                }

                context.Empleat.AddRange(
                    new Empleat
                    {
                        Name = "Albert",
                        Surname = "Pipió",
                        Position = "CEO",
                        Salary = 45000
                    },

                    new Empleat
                    {
                        Name = "Steve",
                        Surname = "Jobs",
                        Position = "Intern",
                        Salary = 500
                    },

                    new Empleat
                    {
                        Name = "Steve",
                        Surname = "Wozniak",
                        Position = "CTO",
                        Salary = 35000
                    },

                    new Empleat
                    {
                        Name = "Steven",
                        Surname = "Spielberg",
                        Position = "PR",
                        Salary = 25000
                    }
                );
                context.SaveChanges();
            }
        }
    }
}