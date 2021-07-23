[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(HostelApp.REST.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(HostelApp.REST.App_Start.NinjectWebCommon), "Stop")]

namespace HostelApp.REST.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Ninject.Web.Common.WebHost;
    using HostelApp.DAL.Interfaces;
    using HostelApp.DAL.Repositories;
    using HostelApp.REST.Interfaces;
    using HostelApp.REST.Services;
    using HostelApp.REST.Util;
    using Ninject.Modules;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application.
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            //NinjectModule resModule = new ReservationModule();
            //var kernel = new StandardKernel(resModule);
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
                kernel.Bind<IReservationService>().To<ReservationService>();
                kernel.Bind<IUoW>().To<EFUoW>().WithConstructorArgument("SqlConn");
                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            //kernel.Bind<IUoW>().To<EFUoW>().WithConstructorArgument("SqlConn");
            //kernel.Bind<IReservationService>().To<ReservationService>();
        }
    }
}