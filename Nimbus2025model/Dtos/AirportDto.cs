namespace Nimbus2025model.Dtos;
public class AirportDto
{
    public string Name { get; set; } = null!;
    public string Code { get; set; } = null!;

    public List<string>? Cities { get; set; }
}
