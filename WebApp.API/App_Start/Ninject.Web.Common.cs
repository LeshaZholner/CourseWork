using WebApp.BLL.Infrastructure;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(WebApp.API.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(WebApp.API.App_Start.NinjectWebCommon), "Stop")]

namespace WebApp.API.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using WebApp.BLL.Services.AppointmentService;
    using WebApp.BLL.Services.DoctorAvailabilityService;
    using WebApp.BLL.Services.DoctorService;
    using WebApp.BLL.Services.SpecializationService;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            //DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            //DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
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
            var serviceModule = new ServiceModule("DefaultConnection");

            var kernel = new StandardKernel(serviceModule);
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
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
            kernel.Bind<IAppointmentService>().To<AppointmentService>();
            kernel.Bind<IDoctorService>().To<DoctorService>();
            kernel.Bind<ISpecializationService>().To<SpecializationService>();
            kernel.Bind<IDoctorAvailabilityService>().To<DoctorAvailabilityService>();
        }        
    }
}