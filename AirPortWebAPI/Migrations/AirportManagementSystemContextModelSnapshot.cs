// <auto-generated />
using System;
using AirPortWebAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace AirPortWebAPI.Migrations
{
    [DbContext(typeof(AirportManagementSystemContext))]
    partial class AirportManagementSystemContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("AirPortWebAPI.Models.Cart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Carts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            UserId = 1
                        });
                });

            modelBuilder.Entity("AirPortWebAPI.Models.Race", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("DeparturePoint")
                        .HasColumnType("text");

                    b.Property<string>("DestinationPoint")
                        .HasColumnType("text");

                    b.Property<DateTime>("FlightDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("PlaneNumber")
                        .HasColumnType("text");

                    b.Property<string>("RaceNumber")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Races");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DeparturePoint = "Warsaw",
                            DestinationPoint = "London",
                            FlightDate = new DateTime(2023, 1, 1, 17, 15, 0, 0, DateTimeKind.Unspecified),
                            PlaneNumber = "28f",
                            RaceNumber = "777A"
                        },
                        new
                        {
                            Id = 2,
                            DeparturePoint = "Warsaw",
                            DestinationPoint = "Bucharest",
                            FlightDate = new DateTime(2023, 1, 1, 8, 30, 0, 0, DateTimeKind.Unspecified),
                            PlaneNumber = "15b",
                            RaceNumber = "777B"
                        },
                        new
                        {
                            Id = 3,
                            DeparturePoint = "Warsaw",
                            DestinationPoint = "Bucharest",
                            FlightDate = new DateTime(2023, 1, 1, 20, 15, 0, 0, DateTimeKind.Unspecified),
                            PlaneNumber = "778a",
                            RaceNumber = "777C"
                        });
                });

            modelBuilder.Entity("AirPortWebAPI.Models.Ticket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("CartId")
                        .HasColumnType("integer");

                    b.Property<int>("RaceId")
                        .HasColumnType("integer");

                    b.Property<string>("SeatNumber")
                        .HasColumnType("text");

                    b.Property<string>("TicketNumber")
                        .HasColumnType("text");

                    b.Property<int?>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CartId");

                    b.HasIndex("RaceId");

                    b.HasIndex("UserId");

                    b.ToTable("Ticket");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            RaceId = 1,
                            SeatNumber = "15",
                            TicketNumber = "111"
                        },
                        new
                        {
                            Id = 2,
                            RaceId = 2,
                            SeatNumber = "28",
                            TicketNumber = "112"
                        },
                        new
                        {
                            Id = 3,
                            RaceId = 1,
                            SeatNumber = "9",
                            TicketNumber = "114"
                        },
                        new
                        {
                            Id = 4,
                            RaceId = 1,
                            SeatNumber = "18",
                            TicketNumber = "121"
                        });
                });

            modelBuilder.Entity("AirPortWebAPI.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<string>("UserName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 2,
                            Email = "bossofthisgym@gmail.com",
                            Password = "aniki",
                            UserName = "Billy Herringthon"
                        });
                });

            modelBuilder.Entity("AirPortWebAPI.Models.Ticket", b =>
                {
                    b.HasOne("AirPortWebAPI.Models.Cart", "Cart")
                        .WithMany("Tickets")
                        .HasForeignKey("CartId");

                    b.HasOne("AirPortWebAPI.Models.Race", "Race")
                        .WithMany("Tickets")
                        .HasForeignKey("RaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AirPortWebAPI.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("Cart");

                    b.Navigation("Race");

                    b.Navigation("User");
                });

            modelBuilder.Entity("AirPortWebAPI.Models.Cart", b =>
                {
                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("AirPortWebAPI.Models.Race", b =>
                {
                    b.Navigation("Tickets");
                });
#pragma warning restore 612, 618
        }
    }
}
