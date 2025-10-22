using System.ComponentModel.DataAnnotations;

namespace Nimbus2025model.Entities;
public class Customer : Person
{
    [StringLength(6)]
    public string? Code { get; set; } = null;
}
