using System.ComponentModel.DataAnnotations;
namespace UKParliament.CodeTest.Data;

public class Person
{
    public int Id { get; set; }

    [Required(AllowEmptyStrings = false)]
    public required string FirstName { get; set; }

    [Required(AllowEmptyStrings = false)]
    public required string LastName { get; set; }

    [Required(AllowEmptyStrings = false)]
    public required DateTime DateOfBirth { get; set; }

    public required Department Dept { get; set; }
}