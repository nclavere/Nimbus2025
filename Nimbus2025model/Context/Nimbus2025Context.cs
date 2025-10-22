using Microsoft.EntityFrameworkCore;
using Nimbus2025model.Entities;

namespace Nimbus2025model.Context;
public class Nimbus2025Context : DbContext
{
    public DbSet<Airport> Airports { get; set; }
    public DbSet<Booking> Bookings { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<Company> Companies { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Flight> Flights { get; set; }
    public DbSet<Passenger> Passengers { get; set; }
    public DbSet<Person> Persons { get; set; }

    public Nimbus2025Context(DbContextOptions<Nimbus2025Context> options)
        : base(options)
    {

    }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //    optionsBuilder.UseSqlServer(
    //        @"Server=(localdb)\mssqllocaldb;Database=Nimbus2025;ConnectRetryCount=0");
    //}

}
