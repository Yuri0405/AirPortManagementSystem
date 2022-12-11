using System.ComponentModel.DataAnnotations.Schema;

namespace AirPortWebAPI.Models
{
    public class Ticket
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string TicketNumber { get; set; }
        public string SeatNumber { get; set; }
        public int RaceId { get; set; }
        public Race Race { get; set; }
        public int? UserId { get; set; }
        public User User { get; set; }
        public int? CartId { get; set; }
        public Cart Cart { get; set; }
    }
}
