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
    public class GuestRepository:IRepository<Guest>
    {
        HostelAppDbContext context;
        public GuestRepository(HostelAppDbContext context)
        {
            this.context = context;
        }
        public void Create(Guest t)
        {
            context.Guests.Add(t);
        }
        public void Delete(int id)
        {
            var entity = context.Guests.Find(id);
            if (entity != null)
                context.Guests.Remove(entity);
        }
        public IEnumerable<Guest> Find(Func<Guest, bool> predicate)
        {
            return context
            .Guests
            .Include("Reservations")
            .Where(predicate);
            //.ToList();
        }
        public Guest Get(int id)
        {
            return context.Guests.Find(id);
        }
        public IEnumerable<Guest> GetAll()
        {
            return context.Guests.Include("Reservations").AsNoTracking();
        }
        public void Update(Guest t)
        {
            context.Entry<Guest>(t).State = EntityState.Modified;
        }
    }
}