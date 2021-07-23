using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HostelApp.REST.Models;
using HostelApp.REST.Interfaces;

namespace HostelApp.REST.Controllers
{
    public class ReservationController : ApiController
    {
        IReservationService reservationService;
        /// <summary>
        /// Class Constructor
        /// </summary>
        /// <param name="ReservationService">Create reservation service</param>
        public ReservationController(IReservationService ReservationService)
        {
            this.reservationService = ReservationService;
        }

        /// <summary>
        /// Displays all reservations with guests
        /// </summary>
        /// <param name="">without params</param>
        /// <returns></returns>

        [HttpGet]
        [Route("~/api/Reservation/GetReservations")]
        public IHttpActionResult GetReservations()
        {
            List<ReservationDTO> reservations = reservationService.GetAll();
            if(reservations == null)
            {
                return NotFound();
            }
            return Ok(reservations);
        }
        /// <summary>
        /// Displays filtered guests by name and city
        /// </summary>
        /// <param name="Name">Guests name</param>
        /// <param name="City">Guests city</param>
        /// <returns></returns>

        [HttpGet]
        [Route("~/api/Reservation/GetFilteredGuests/{Name}/{City}")]
        public IHttpActionResult GetFilteredGuests(string Name, string City)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(reservationService.FilterGuests(Name, City));
        }

        // <summary>
        /// Create reservation and save in db
        /// </summary>
        /// <param name="reservation">reservation model with guests as parameter</param>
        /// <returns></returns>

        [HttpPost]
        [Route("~/api/Reservation/SaveReservation")]
        public IHttpActionResult CreateReservation(ReservationDTO reservation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                reservationService.SaveReservation(reservation);
            }
            catch
            {
                return StatusCode(HttpStatusCode.InternalServerError);
            }
            return Ok();
        }
    }
}
