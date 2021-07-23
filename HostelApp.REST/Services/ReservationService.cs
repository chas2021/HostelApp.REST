using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HostelApp.REST.Interfaces;
using HostelApp.REST.Models;
using HostelApp.DAL.Interfaces;
using HostelApp.DAL.Entities;
using AutoMapper;

namespace HostelApp.REST.Services
{
    public class ReservationService : IReservationService
    {

        IUoW Database;
        /// <summary>
        /// Class constructor
        /// </summary>
        /// <param name="unitOfWork">Pattern unit of work used to connect to the db</param>
        public ReservationService(IUoW unitOfWork)
        {
            Database = unitOfWork;
        }

        public List<ReservationDTO> GetAll()
        {

            IMapper mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Reservation, ReservationDTO>();
                cfg.CreateMap<Guest, GuestDTO>();
            }).CreateMapper();
            
            return mapper.Map<IEnumerable<Reservation>, List<ReservationDTO>>(Database.Reservations.GetAll());
        }

        public List<GuestDTO> FilterGuests(string Name, string City)
        {

            IMapper mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Guest, GuestDTO>();
                cfg.CreateMap<Reservation, ReservationDTO>();
            }).CreateMapper();

            return mapper.Map<IEnumerable<Guest>, List<GuestDTO>>(Database.Guests.Find(item => item.Name == Name && (item.City == City || String.IsNullOrEmpty(item.City))));
        }

        public void SaveReservation(ReservationDTO reservation)
        {

            IMapper mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ReservationDTO, Reservation>();
                cfg.CreateMap<GuestDTO, Guest>();
            }).CreateMapper();

            Database.Reservations.Create(mapper.Map<Reservation>(reservation));
            Database.Save();
        }
    }
}