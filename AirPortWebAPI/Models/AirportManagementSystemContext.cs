using Microsoft.EntityFrameworkCore;
using System;

namespace AirPortWebAPI.Models
{
    public class AirportManagementSystemContext:DbContext
    {
        public AirportManagementSystemContext(DbContextOptions<AirportManagementSystemContext> options):base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Race> Races { get; set; }
        public DbSet<Ticket> Ticket { get; set; }
        public DbSet<Cart> Carts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 2,
                    UserName = "Billy Herringthon",
                    Password = "aniki",
                    Email = "bossofthisgym@gmail.com"
                }
              );
            modelBuilder.Entity<Cart>().HasData(
                new Cart
                {
                    Id=1,
                    UserId = 1,
                }
              );
            modelBuilder.Entity<Race>().HasData(
                new Race
                {
                    Id=1,
                    FlightDate = new DateTime(2023,1,1,17,15,0),
                    DeparturePoint = "Warsaw",
                    DestinationPoint = "London",
                    RaceNumber = "777A",
                    PlaneNumber = "28f",
                },
                new Race
                {
                    Id = 2,
                    FlightDate = new DateTime(2023, 1, 1,8,30,0),
                    DeparturePoint = "Warsaw",
                    DestinationPoint = "Bucharest",
                    RaceNumber = "777B",
                    PlaneNumber = "15b",
                },
                new Race
                {
                    Id = 3,
                    FlightDate = new DateTime(2023, 1, 1, 20, 15, 0),
                    DeparturePoint = "Warsaw",
                    DestinationPoint = "Bucharest",
                    RaceNumber = "777C",
                    PlaneNumber = "778a",
                }
              );
            modelBuilder.Entity<Ticket>().HasData(               
                new Ticket
                {
                    Id = 1,
                    TicketNumber = "111",
                    SeatNumber = "15",
                    RaceId = 1,
                    UserId = null
                },
                new Ticket
                {
                    Id = 2,
                    TicketNumber = "112",
                    SeatNumber = "28",
                    RaceId = 2,
                    UserId = null
                },
                new Ticket
                {
                    Id = 3,
                    TicketNumber = "114",
                    SeatNumber = "9",
                    RaceId = 1,
                    UserId = null
                },
                new Ticket
                {
                    Id = 4,
                    TicketNumber = "121",
                    SeatNumber = "18",
                    RaceId = 1,
                    UserId = null
                }
               );
        }
    }
}
