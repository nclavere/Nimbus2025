using Microsoft.EntityFrameworkCore;
using Nimbus2025model.Context;
using Nimbus2025model.Entities;

using var context = new Nimbus2025Context();

//context.Airports.RemoveRange(context.Airports);
//context.SaveChanges();
//context.Cities.RemoveRange(context.Cities);
//context.SaveChanges();

if (!context.Companies.Any())
{
    context.Companies.Add(new Company { Name = "Air France" });
    context.Companies.Add(new Company { Name = "Ryan Air" });
    context.Companies.Add(new Company { Name = "Volotea" });
    context.Companies.Add(new Company { Name = "Air Dubai" });
    context.SaveChanges();
}

if (!context.Cities.Any())
{
    context.Cities.Add(new City { Name = "Pau" });
    context.Cities.Add(new City { Name = "Tarbes" });
    context.Cities.Add(new City { Name = "Paris" });
    context.Cities.Add(new City { Name = "Marseille" });
    context.Cities.Add(new City { Name = "Reykjavik" });
    context.SaveChanges();
}



if (!context.Airports.Any())
{
    var pau = context.Cities.Where(city => city.Name == "Pau").First();
    var tarbes = context.Cities.Where(city => city.Name == "Tarbes").First();
    var paris = context.Cities.Where(city => city.Name == "Paris").First();
    var reykjavik = context.Cities.Where(city => city.Name == "Reykjavik").First();

    context.Airports.Add(new Airport
    {
        Name = "Aéroport Pau-Pyrénées",
        Code = "PUF",
        Cities = new List<City> { pau, tarbes },
    });

    context.Airports.Add(new Airport
    {
        Name = "Aéroport de Tarbes-Lourdes Pyrénées",
        Code = "LDE",
        Cities = new List<City> { pau, tarbes },
    });

    context.Airports.Add(new Airport
    {
        Name = "Aéroport de Paris-Charles de Gaulle",
        Code = "CDG",
        Cities = new List<City> { paris },
    });

    context.Airports.Add(new Airport
    {
        Name = "Aéroport de Paris-Orly",
        Code = "ORY",
        Cities = new List<City> { paris },
    });

    context.Airports.Add(new Airport
    {
        Name = "Aéroport de Reykjavik",
        Code = "RKV",
        Cities = new List<City> { reykjavik },
    });

    context.SaveChanges();
}

var p = context.Cities.Where(city => city.Name.StartsWith("Paris")).First();
p.Name = "Paris";
context.SaveChanges();

var airports = context.Airports
    .Include(a => a.Cities)
    .Where(a => a.Cities!.Any(c => c.Name == "Paris"))
    .ToList();

airports.ForEach(a =>
{
    Console.WriteLine($"{a.Name} : {a.Code}");
    if (a.Cities != null)
    {
        a.Cities.ForEach(city => Console.WriteLine($"\tCity: {city.Name}"));
    }
    else
    {
        Console.WriteLine("\tNo associated cities.");
    }
});



Console.Write("Press any key to exit...");
Console.ReadKey();