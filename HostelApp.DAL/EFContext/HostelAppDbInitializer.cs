using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using HostelApp.DAL.Entities;

namespace HostelApp.DAL.EFContext
{
    public class HostelAppDbInitializer : CreateDatabaseIfNotExists<HostelAppDbContext>//CreateDatabaseIfNotExists  DropCreateDatabaseAlways
    {
        protected override void Seed(HostelAppDbContext db)
        {
            try
            {
                Guest Peter = new Guest { Name = "Peter", Email = "peter@gmail.com", Surname = "Petrov", ZipCode = "220116" };
                Guest Greta = new Guest { Name = "Greta", Email = "greta@gmail.com", Surname = "Petrova", ZipCode = "220117" };
                Guest Nicole = new Guest { Name = "Nicole", Email = "nicole@gmail.com", Surname = "McDuck", ZipCode = "220118" };
                db.Guests.AddRange(new List<Guest> { Peter, Nicole, Greta });
                db.Reservations.Add(new Reservation { ReservationCode = "1234567", DtCheckIn = DateTime.Now.AddDays(5), DtDeparture = DateTime.Now.AddDays(7), DtInsert = DateTime.Now, Amount = 50, Сurrency = "USD", Guests = new List<Guest> { Peter, Nicole } });
                db.Reservations.Add(new Reservation { ReservationCode = "1234568", DtCheckIn = DateTime.Now.AddDays(7), DtDeparture = DateTime.Now.AddDays(10), DtInsert = DateTime.Now, Amount = 100, Сurrency = "USD", Guests = new List<Guest> { Greta } });
                db.Reservations.Add(new Reservation { ReservationCode = "1234569", DtCheckIn = DateTime.Now.AddDays(10), DtDeparture = DateTime.Now.AddDays(15), DtInsert = DateTime.Now, Amount = 150, Сurrency = "USD", Guests = new List<Guest> { Greta, Peter } });
                db.SaveChanges();
            }
            catch { }
        }
    }
}