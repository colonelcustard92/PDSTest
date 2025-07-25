using UKParliament.CodeTest.Data;

namespace UKParliament.CodeTest.Services;

public class PersonService : IPersonService
{
    private readonly List<Person> _people = new List<Person>();

    PersonManagerContext _context = new PersonManagerContext();

    public PersonService()
    {
        
        // Initialize with some sample data
        _people.Add(new Person { Id = 1, FirstName = "John", LastName = "Doe", DateOfBirth = new DateTime(1990, 1, 1), Dept = new Department { Id = 1, Name = "Finance" } });
        _people.Add(new Person { Id = 2, FirstName = "Jane", LastName = "Smith", DateOfBirth = new DateTime(1985, 5, 15), Dept = new Department { Id = 2, Name = "Human Resources" } });
        _people.Add(new Person { Id = 3, FirstName = "Alice", LastName = "Johnson", DateOfBirth = new DateTime(1992, 3, 20), Dept = new Department { Id = 3, Name = "Information Technology" } });
        _people.Add(new Person { Id = 4, FirstName = "Bob", LastName = "Brown", DateOfBirth = new DateTime(1988, 7, 30), Dept = new Department { Id = 4, Name = "Marketing" } });
        _people.Add(new Person { Id = 5, FirstName = "Charlie", LastName = "Davis", DateOfBirth = new DateTime(1995, 12, 10), Dept = new Department { Id = 5, Name = "Operations" } });
        _people.Add(new Person { Id = 6, FirstName = "Eve", LastName = "White", DateOfBirth = new DateTime(1993, 11, 25), Dept = new Department { Id = 1, Name = "Finance" } });
    }

    public IEnumerable<Person> GetAllPeople()
    {
        return _people;
    }

    public Person? GetPersonById(int id)
    {
        return _people.FirstOrDefault(p => p.Id == id);
    }

}