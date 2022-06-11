using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmpSystem
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasIndex(e => e.Email).IsUnique();
            builder.HasIndex(e => e.PhoneNumber).IsUnique();
        }
    }
}
