using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using HostelApp.DAL.Entities;

namespace HostelApp.DAL.EFContext
{
    public class HostelAppDbContext:DbContext
    {
        static HostelAppDbContext()
        {
            Database.SetInitializer<HostelAppDbContext>(new HostelAppDbInitializer());
        }
        public HostelAppDbContext(string connectionString)
            : base(connectionString)
        {
        }
        public HostelAppDbContext() : base("SqlConn") { }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
    }
}