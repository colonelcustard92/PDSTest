using Microsoft.EntityFrameworkCore;

namespace UKParliament.CodeTest.Data;

public class PersonManagerContext : DbContext
{
    public PersonManagerContext(DbContextOptions<PersonManagerContext> options) : base(options)
    {

    }

    public PersonManagerContext()
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Department>().HasData(
            new Department { Id = 1, Name = "Sales" },
            new Department { Id = 2, Name = "Marketing" },
            new Department { Id = 3, Name = "Finance" },
            new Department { Id = 4, Name = "HR" });

        modelBuilder.Entity<Person>().HasData(
            new Person { Id = 1, FirstName = "John", LastName = "Doe", DateOfBirth = new DateTime(1990, 1, 1), DeptId = 1 },
            new Person { Id = 2, FirstName = "Jane", LastName = "Smith", DateOfBirth = new DateTime(1985, 5, 15), DeptId = 2 },
            new Person { Id = 3, FirstName = "Alice", LastName = "Johnson", DateOfBirth = new DateTime(1992, 3, 20), DeptId = 3 },
            new Person { Id = 4, FirstName = "Bob", LastName = "Brown", DateOfBirth = new DateTime(1988, 7, 30), DeptId = 4 },
            new Person { Id = 5, FirstName = "Charlie", LastName = "Davis", DateOfBirth = new DateTime(1995, 12, 10), DeptId = 5 },
            new Person { Id = 6, FirstName = "Eve", LastName = "White", DateOfBirth = new DateTime(1993, 11, 25), DeptId = 1 });
    }

    public DbSet<Person> People { get; set; }
    

    public DbSet<Department> Departments { get; set; }
}