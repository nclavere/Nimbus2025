
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nimbus2025model.Entities;
public class Airport
{
    public int Id { get; set; }

    [StringLength(80)]
    public string Name { get; set; } = null!;

    [StringLength(4)]
    public string Code { get; set; } = null!;

    [InverseProperty(nameof(Flight.AirportFrom))]
    public List<Flight>? FlightFroms { get; set; }
    
    [InverseProperty(nameof(Flight.AirportTo))]
    public List<Flight>? FlightTos { get; set; }

    [InverseProperty(nameof(City.Airports))]
    public List<City>? Cities { get; set; }

}
