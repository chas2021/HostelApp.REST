using Ninject.Modules;
using HostelApp.REST.Services;
using HostelApp.REST.Interfaces;

namespace HostelApp.REST.Util
{
    public class ReservationModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IReservationService>().To<ReservationService>();
        }
    }
}