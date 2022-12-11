using System.Collections.Generic;

namespace AirPortWebAPI.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public List<Ticket> Tickets { get; set; }
    }
}
