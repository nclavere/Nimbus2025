namespace Nimbus2025Transverse.Dtos;
public class FlightDto
{
    public int Id { get; set; }
    public bool IsOpen { get; set; }
    public DateTime Departure { get; set; }
    public DateTime Arrival { get; set; }

    public string CompagnyName { get; set; } = null!;

    public AirportDto AirportFrom { get; set; } = null!;
    public AirportDto AirportTo { get; set; } = null!;

    public List<string>? Cities { get; set; }

}
