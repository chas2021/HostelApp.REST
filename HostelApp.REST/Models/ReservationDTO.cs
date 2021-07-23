using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HostelApp.REST.Models
{
    public class ReservationDTO
    {
        [Required]
        [StringLength(10)]
        public string ReservationCode { get; set; }
        [Required]
        public DateTime? DtInsert { get; set; }
        [Required]
        public decimal Amount { get; set; }
        [Required]
        public DateTime? DtCheckIn { get; set; }
        [Required]
        public DateTime? DtDeparture { get; set; }
        [Required]
        public string Сurrency { get; set; }

        public decimal? Commission { get; set; }
        public string Source { get; set; }

        public List<GuestDTO> Guests { get; set; }

        public ReservationDTO()
        {
            Guests = new List<GuestDTO>();
        }
    }
}