using Microsoft.EntityFrameworkCore;

namespace EmpSystem
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; } = null!;

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }
    }
}
