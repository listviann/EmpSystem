using Microsoft.EntityFrameworkCore;

namespace EmpSystem
{
    [EntityTypeConfiguration(typeof(EmployeeConfiguration))]
    public class Employee
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Position { get; set; }
        public int Salary { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
