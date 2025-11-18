namespace Nimbus2025Transverse.Dtos;
public class AirportDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Code { get; set; } = null!;

    public List<string>? Cities { get; set; }

    public override string ToString()
    {
        return $"{Name} - {Code}";
    }

}
