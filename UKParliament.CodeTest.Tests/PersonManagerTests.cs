using Microsoft.EntityFrameworkCore;
using UKParliament.CodeTest.Data;
using UKParliament.CodeTest.Services;
using Xunit;

namespace UKParliament.CodeTest.Tests
{
    public class PersonServiceTests
    {
        private PersonManagerContext GetInMemoryContext()
        {
            var options = new DbContextOptionsBuilder<PersonManagerContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString()) // Unique DB per test
                .Options;

            return new PersonManagerContext(options);
        }

        private void SeedData(PersonManagerContext context)
        {
            context.People.AddRange(
                new Person { Id = 1, FirstName = "John", LastName = "Doe", DateOfBirth = new DateTime(1990, 1, 1), DeptId = 1 },
                new Person { Id = 2, FirstName = "Jane", LastName = "Smith", DateOfBirth = new DateTime(1992, 2, 2), DeptId = 2 }
            );
            context.SaveChanges();
        }

        [Fact]
        public void GetAllPeople_ReturnsAllPeople()
        {
            using var context = GetInMemoryContext();
            SeedData(context);

            var service = new PersonService(context);
            var result = service.GetAllPeople();

            Assert.Equal(2, result.Count());
        }

        [Fact]
        public void GetPersonById_ReturnsCorrectPerson()
        {
            using var context = GetInMemoryContext();
            SeedData(context);

            var service = new PersonService(context);
            var result = service.GetPersonById(1);

            Assert.NotNull(result);
            Assert.Equal("John", result.FirstName);
        }

        [Fact]
        public void AddPerson_AddsNewPerson()
        {
            using var context = GetInMemoryContext();
            var service = new PersonService(context);

            var newPerson = new Person
            {
                Id = 3,
                FirstName = "Alice",
                LastName = "Wonderland",
                DateOfBirth = new DateTime(1988, 3, 3),
                DeptId = 3
            };

            service.AddPerson(newPerson);

            var allPeople = service.GetAllPeople();
            Assert.Single(allPeople);
            Assert.Equal("Alice", allPeople.First().FirstName);
        }

        [Fact]
        public void AddPerson_Throws_When_Null()
        {
            using var context = GetInMemoryContext();
            var service = new PersonService(context);

            Assert.Throws<ArgumentNullException>(() => service.AddPerson(null));
        }

        [Fact]
        public void DeletePerson_RemovesCorrectPerson()
        {
            using var context = GetInMemoryContext();
            SeedData(context);

            var service = new PersonService(context);
            service.DeletePerson(1);

            var remaining = service.GetAllPeople();
            Assert.Single(remaining);
            Assert.Equal(2, remaining.First().Id);
        }

        [Fact]
        public void UpdateUser_UpdatesFieldsCorrectly()
        {
            using var context = GetInMemoryContext();
            SeedData(context);

            var service = new PersonService(context);
            var updated = new Person
            {
                Id = 1,
                FirstName = "Johnny",
                LastName = "Doeman",
                DateOfBirth = new DateTime(1991, 1, 1),
                DeptId = 5
               
            };

            service.UpdateUser(updated);

            var person = service.GetPersonById(1);
            Assert.Equal("Johnny", person.FirstName);
            Assert.Equal(5, person.DeptId);
        }
    }
}
