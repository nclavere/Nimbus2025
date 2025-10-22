namespace Nimbus2025model.Entities;
public class Passenger : Person
{
    public string IdentityNumber { get; set; } = null!;

    public int BirthYear { get; set; }
}
