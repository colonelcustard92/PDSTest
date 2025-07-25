using Xunit;
using UKParliament.CodeTest.Services;

namespace UKParliament.CodeTest.Tests;

public class PersonManagerTests
{
    [Fact]
    public void Call_To_Person_Service_Should_Return_List_Of_Persons()
    {
        // Arrange
        var personService = new PersonService();

        // Act
        var persons = personService.GetAllPeople();

        // Assert
        Assert.NotNull(persons);
        Assert.NotEmpty(persons);
    }
}