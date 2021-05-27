using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace PracticalTest
{
    public class PracticalTestContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-37BVSQ0;Initial Catalog=Company;Integrated Security=True");

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}