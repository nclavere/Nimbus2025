using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nimbus2025model.Entities;
public class Flight
{
    public int Id { get; set; }
    public bool IsOpen { get; set; } 
    public DateTime Departure { get; set; }
    public DateTime Arrival { get; set; }

    [ForeignKey(nameof(Company))]
    public int CompanyId { get; set; }
    public Company? Company { get; set; }


    [ForeignKey(nameof(AirportFrom))]
    public int AirportFromId { get; set; }

    [DeleteBehavior(DeleteBehavior.Restrict)]
    public Airport? AirportFrom { get; set; }


    [ForeignKey(nameof(AirportTo))]
    public int AirportToId { get; set; }
    [DeleteBehavior(DeleteBehavior.Restrict)]
    public Airport? AirportTo{ get; set; }

    public List<Booking>? Bookings { get; set; }

    public List<City>? Cities { get; set; }

}
