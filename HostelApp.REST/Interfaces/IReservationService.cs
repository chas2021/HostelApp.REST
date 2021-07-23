using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HostelApp.REST.Models;

namespace HostelApp.REST.Interfaces
{
    public interface IReservationService
    {
        List<ReservationDTO> GetAll();
        List<GuestDTO> FilterGuests(string Name, string City);
        void SaveReservation(ReservationDTO reservation);
    }
}
