using UKParliament.CodeTest.Data;

namespace UKParliament.CodeTest.Services;

public class PersonService : IPersonService
{
    private readonly PersonManagerContext _context;

    public PersonService(PersonManagerContext context)
    {
        _context = context;
    }

    public IEnumerable<Person> GetAllPeople()
    {
        return _context.People.ToList();
    }

    public Person? GetPersonById(int id)
    {
        return _context.People.FirstOrDefault(p => p.Id == id);
    }

    public void AddPerson(Person person)
    {
        if (person == null) throw new ArgumentNullException(nameof(person));
        _context.People.Add(person);
        _context.SaveChanges();
       
    }

    public void DeletePerson(int id)
    {
    
        var person = _context.People.FirstOrDefault(p => p.Id == id);
        if (person != null)
        {
            _context.People.Remove(person);
            _context.SaveChanges();
        }
    }

    public void UpdateUser(Person person)
    {
        var personData = _context.People.FirstOrDefault(p => p.Id == person.Id);
        if (personData != null)
        {
            // Update properties as needed
            personData.FirstName = person.FirstName;
            personData.LastName = person.LastName;
            personData.DateOfBirth = person.DateOfBirth;
            personData.DeptId = person.DeptId;
            personData.Dept = person.Dept;
           
            _context.SaveChanges();
        }

    }
    

}