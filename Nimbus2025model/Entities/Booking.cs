using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nimbus2025model.Entities;
public class Booking
{
    public int Id { get; set; }
    public DateTime? DateConfirmed { get; set; }
    public DateTime? DateCanceled { get; set; }

    [ForeignKey(nameof(Flight))]
    public int FlightId { get; set; }
    [DeleteBehavior(DeleteBehavior.Restrict)]
    public Flight? Flight { get; set; }

    [ForeignKey(nameof(Customer))]
    public int CustomerId { get; set; }
    [DeleteBehavior(DeleteBehavior.Restrict)]
    public Customer? Customer { get; set; }

    [ForeignKey(nameof(Passenger))]
    public int PassengerId { get; set; }
    [DeleteBehavior(DeleteBehavior.Restrict)]
    public Passenger? Passenger { get; set; }

}
