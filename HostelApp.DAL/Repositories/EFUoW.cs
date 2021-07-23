using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HostelApp.DAL.Interfaces;
using HostelApp.DAL.EFContext;
using HostelApp.DAL.Entities;

namespace HostelApp.DAL.Repositories
{
    public class EFUoW : IUoW
    {
        private HostelAppDbContext db;
        private GuestRepository guestRepository;
        private ReservationRepository reservationRepository;

        public EFUoW(string connectionString)
        {
            db = new HostelAppDbContext(connectionString);
        }
        public IRepository<Guest> Guests
        {
            get
            {
                if (guestRepository == null)
                    guestRepository = new GuestRepository(db);
                return guestRepository;
            }
        }

        public IRepository<Reservation> Reservations
        {
            get
            {
                if (reservationRepository == null)
                    reservationRepository = new ReservationRepository(db);
                return reservationRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}