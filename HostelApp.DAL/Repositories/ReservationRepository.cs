using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using HostelApp.DAL.Interfaces;
using HostelApp.DAL.Entities;
using HostelApp.DAL.EFContext;

namespace HostelApp.DAL.Repositories
{
    public class ReservationRepository:IRepository<Reservation>
    {
        HostelAppDbContext context;
        public ReservationRepository(HostelAppDbContext context)
        {
            this.context = context;
        }
        public void Create(Reservation t)
        {
            context.Reservations.Add(t);
        }
        public void Delete(int id)
        {
            var entity = context.Reservations.Find(id);
            if (entity != null)
                context.Reservations.Remove(entity);
        }
        public IEnumerable<Reservation> Find(Func<Reservation, bool> predicate)
        {
            return context
            .Reservations
            .Include("Guests")
            .Where(predicate);
            //.ToList();
        }
        public Reservation Get(int id)
        {
            return context.Reservations.Find(id);
        }
        public IEnumerable<Reservation> GetAll()
        {
            return context.Reservations.Include("Guests").AsNoTracking();
        }
        public void Update(Reservation t)
        {
            context.Entry<Reservation>(t).State = EntityState.Modified;
        }
    }
}