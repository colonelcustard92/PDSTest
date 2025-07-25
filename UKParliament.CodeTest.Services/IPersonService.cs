using UKParliament.CodeTest.Data;
namespace UKParliament.CodeTest.Services;

public interface IPersonService
{
    /// <summary>
    /// Retrieves all persons.
    /// </summary>
    /// <returns>An enumerable collection of persons.</returns>
    IEnumerable<Person> GetAllPeople();

    /// <summary>
    /// Retrieves a person by their ID.
    /// </summary>
    /// <param name="id">The ID of the person to retrieve.</param>
    /// <returns>The person with the specified ID, or null if not found.</returns>
    Person? GetPersonById(int id);

}