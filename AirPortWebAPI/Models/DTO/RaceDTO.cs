using System;
using System.ComponentModel.DataAnnotations;

namespace AirPortWebAPI.Models.DTO
{
    public class RaceDTO
    {
        public int Id { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime FlightDate { get; set; }
        public string DeparturePoint { get; set; }
        public string DestinationPoint { get; set; }
    }
}
