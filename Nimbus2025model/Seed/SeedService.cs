using Nimbus2025model.Context;
using Nimbus2025model.Entities;

namespace Nimbus2025model.Seed;
public static class SeedService
{
    public static async Task<bool> Seed(Nimbus2025Context context)
    {
        bool result = false;

        if (!context.Companies.Any())
        {
            context.Companies.Add(new Company { Name = "Air France" });
            context.Companies.Add(new Company { Name = "Ryan Air" });
            context.Companies.Add(new Company { Name = "Volotea" });
            context.Companies.Add(new Company { Name = "Air Dubai" });
            await context.SaveChangesAsync();
            result=true;
        }

        if (!context.Cities.Any())
        {
            context.Cities.Add(new City { Name = "Pau" });
            context.Cities.Add(new City { Name = "Tarbes" });
            context.Cities.Add(new City { Name = "Paris" });
            context.Cities.Add(new City { Name = "Marseille" });
            context.Cities.Add(new City { Name = "Reykjavik" });
            await context.SaveChangesAsync();
            result = true;
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

            await context.SaveChangesAsync();
            result = true;
        }

        return result;
    }
}
