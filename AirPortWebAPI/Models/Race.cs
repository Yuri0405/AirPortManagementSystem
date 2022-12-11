using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirPortWebAPI.Models
{
    public class Race
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime FlightDate { get; set; }
        public string DeparturePoint { get; set; }
        public string DestinationPoint { get; set; }
        public string RaceNumber { get; set; }
        public string PlaneNumber { get; set; }
        public List<Ticket> Tickets { get; set; }

    }
}
