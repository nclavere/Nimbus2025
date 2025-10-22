using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nimbus2025model.Entities;
public class City
{
    public int Id { get; set; }

    [StringLength(80)]
    public string Name { get; set; } = null!;

    public List<Flight>? Flights { get; set; }

    [InverseProperty(nameof(Airport.Cities))]
    public List<Airport>? Airports { get; set; }
}
