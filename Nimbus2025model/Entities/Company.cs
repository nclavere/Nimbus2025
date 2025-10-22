using System.ComponentModel.DataAnnotations;

namespace Nimbus2025model.Entities;
public class Company
{
    public int Id { get; set; }

    [StringLength(80)]
    public string Name { get; set; } = null!;

    public List<Flight>? Flights { get; set; }
}
