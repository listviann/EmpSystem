using Microsoft.EntityFrameworkCore;

namespace EmpSystem
{
    public enum Position { Low, Middle, High }

    [EntityTypeConfiguration(typeof(EmployeeConfiguration))]
    public class Employee
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public Position Position { get; set; }
        public decimal Salary { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
