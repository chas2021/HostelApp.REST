using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HostelApp.DAL.Entities;

namespace HostelApp.DAL.Interfaces
{
    public interface IUoW : IDisposable
    {
        IRepository<Guest> Guests { get; }
        IRepository<Reservation> Reservations { get; }
        void Save();
    }
}
