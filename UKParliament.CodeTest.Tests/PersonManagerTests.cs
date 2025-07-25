using Xunit;
using UKParliament.CodeTest.Services;
using Microsoft.EntityFrameworkCore;
using UKParliament.CodeTest.Data;

namespace UKParliament.CodeTest.Tests;

public class PersonManagerTests
{


    [Fact]
    public void Call_To_Person_Service_Should_Return_List_Of_Persons()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<PersonManagerContext>()
        .UseInMemoryDatabase(databaseName: "TestDb")
        .Options;

        using var context = new PersonManagerContext(options);

        // Seed test data
        context.People.Add(new Person { Id = 1, FirstName = "Test", LastName = "User", DateOfBirth = DateTime.Today });
        context.SaveChanges();


        var personService = new PersonService(context);

        // Act
        var persons = personService.GetAllPeople();

        // Assert
        Assert.NotNull(persons);
        Assert.NotEmpty(persons);
    }
}