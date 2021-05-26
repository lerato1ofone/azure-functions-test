using Microsoft.EntityFrameworkCore;
using PracticalTest.Models;

namespace PracticalTest
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<TitleLookUp> TitleLookUp { get; set; }
    }
}
