using System;

namespace AirPortWebAPI.Models.DTO
{
    public class TicketDTO
    {
        public int Id { get; set; }
        public string TicketNumber { get; set; }
        public string SeatNumber { get; set; }
        public DateTime FlightDate { get; set; }
        public string DeparturePoint { get; set; }
        public string DestinationPoint { get; set; }
        public string PlaneNumber { get; set; }

    }
}
