using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HostelApp.DAL.Entities
{
    public class Reservation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(10)]
        public string ReservationCode { get; set; }
        [Required]
        public DateTime? DtInsert { get; set; }
        //[DataType(DataType.Currency)]
        //[Column(TypeName = "money")]
        //[DisplayFormat(DataFormatString = "{0:C0}", ApplyFormatInEditMode = true)]
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

        public List<Guest> Guests { get; set; }

        public Reservation()
        {
            Guests = new List<Guest>();
        }
    }
}