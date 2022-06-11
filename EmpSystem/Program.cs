using EmpSystem;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

var builder = WebApplication.CreateBuilder(args);

string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connectionString));
var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// create
app.MapPost("/empsystem/employees", async (Employee employee, ApplicationContext db) =>
{
    // adding to the database
    await db.Employees.AddAsync(employee);
    await db.SaveChangesAsync();
    return employee;
});

// read
app.MapGet("/empsystem/employees", async (ApplicationContext db) => await db.Employees.ToListAsync());
app.MapGet("empsystem/employees/{id:int}", async (int id, ApplicationContext db) =>
{
    Employee? employee = await db.Employees.FirstOrDefaultAsync(e => id == e.Id);

    if (employee == null) return Results.NotFound(new { message = "Employee is not found" });
    return Results.Json(employee);
});

// update
app.MapPut("/empsystem/employees", async (Employee empData, ApplicationContext db) =>
{
    Employee? employee = await db.Employees.FirstOrDefaultAsync(e => empData.Id == e.Id);

    if (employee == null) return Results.NotFound(new { message = "Employee is not found" });

    employee.FirstName = empData.FirstName;
    employee.LastName = empData.LastName;
    employee.Position = empData.Position;
    employee.Salary = empData.Salary;
    employee.Email = empData.Email;
    employee.PhoneNumber = empData.PhoneNumber;
    employee.BirthDate = empData.BirthDate;

    await db.SaveChangesAsync();
    return Results.Json(employee);
});

// delete
app.MapDelete("/empsystem/employees/{id:int}", async (int id, ApplicationContext db) =>
{
    Employee? employee = await db.Employees.FirstOrDefaultAsync(e => id == e.Id);

    if (employee == null) return Results.NotFound(new { message = "Employee is not found" });

    db.Employees.Remove(employee);
    await db.SaveChangesAsync();
    return Results.Json(employee);
});

app.Run();
