using System.ComponentModel.DataAnnotations;
namespace UKParliament.CodeTest.Data;

public class Person
{

    public int Id { get; set; }
    [Required(AllowEmptyStrings = false)]
    public string FirstName { get; set; } = default!;
    [Required(AllowEmptyStrings = false)]
    public string LastName { get; set; } = default!;
    public DateTime DateOfBirth { get; set; }

    public int DeptId { get; set; }             // Foreign key
    public Department Dept { get; set; } = default!; // Navigation property — not required by C#

    
 
}