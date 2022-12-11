using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AirPortWebAPI.Models;
using AirPortWebAPI.Models.DTO;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using System;

namespace AirPortWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerActionsController : ControllerBase
    {
        private readonly AirportManagementSystemContext _db;
        public CustomerActionsController(AirportManagementSystemContext db)
        {
            _db = db;
        }

        [HttpGet("tickets")]
        public ActionResult<List<TicketDTO>> GetAllTickets()
        {
            var tickets = from t in _db.Ticket
                          join r in _db.Races on t.RaceId equals r.Id
                          select new TicketDTO()
                          {
                              Id = t.Id,
                              TicketNumber = t.TicketNumber,
                              SeatNumber = t.SeatNumber,
                              FlightDate = r.FlightDate,
                              DeparturePoint = r.DeparturePoint,
                              DestinationPoint = r.DestinationPoint,
                              PlaneNumber = r.PlaneNumber
                          };
            return tickets.ToList();
        }

        [HttpGet("races")]
        public ActionResult<List<RaceDTO>> GetAllRaces()
        {
            var races = from r in _db.Races
                        select new RaceDTO()
                        {
                            Id = r.Id,
                            FlightDate = r.FlightDate,
                            DeparturePoint = r.DeparturePoint,
                            DestinationPoint = r.DestinationPoint,
                        };
            return races.ToList();
        }
        [Authorize]
        [HttpGet("cart/additem/{ticketId}")]
        public ActionResult AddTicketToCart(int ticketId)
        {
            var currentUser = HttpContext.User;
            var userId = currentUser.FindFirst("UserID");
            var cartId = (from c in _db.Carts where c.UserId == Int32.Parse(userId.Value) select c.Id).First();
            var ticket = (from t in _db.Ticket where t.Id == ticketId select t).First();
            ticket.CartId = cartId;
            _db.SaveChanges();

            return Ok($"Ticket with number {ticket.TicketNumber} added to your cart");
        }

        [Authorize]
        [HttpDelete("cart/removeitem/{ticketId}")]
        public ActionResult RemoveTicketFromCart(int ticketId)
        {
            Ticket ticket = (from t in _db.Ticket where t.Id == ticketId select t).First();
            ticket.CartId = null;
            _db.SaveChanges();
            return Ok($"Ticket with number {ticket.TicketNumber} removed from your cart");
        }

        [Authorize]
        [HttpGet("cart/view")]
        public ActionResult GetAllTicketsInCart()
        {
            var currentUser = HttpContext.User;
            var userId = currentUser.FindFirst("UserID");
            var cartId = (from c in _db.Carts where c.UserId == Int32.Parse(userId.Value) select c.Id).First();
            var tickets = from t in _db.Ticket
                          join r in _db.Races on t.RaceId equals r.Id 
                          where t.CartId == cartId
                          select new TicketDTO()
                          {
                              Id = t.Id,
                              TicketNumber = t.TicketNumber,
                              SeatNumber = t.SeatNumber,
                              FlightDate = r.FlightDate,
                              DeparturePoint = r.DeparturePoint,
                              DestinationPoint = r.DestinationPoint,
                              PlaneNumber = r.PlaneNumber
                          };
            return Ok(tickets.ToList());
        }
    }
}
