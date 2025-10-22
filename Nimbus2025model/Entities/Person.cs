using System.ComponentModel.DataAnnotations;

namespace Nimbus2025model.Entities;
public class Person
{
    public int Id { get; set; }

    [StringLength(80)]
    public string FirstName { get; set; } = null!;

    [StringLength(80)]
    public string LastName { get; set; } = null!;
}
