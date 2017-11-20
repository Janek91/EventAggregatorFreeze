using EventAggregatorFreeze.Modules;
using EventAggregatorFreeze.Services;
using Microsoft.Practices.Unity;
using Prism.Events;
using Prism.Modularity;
using Prism.Regions;
using Prism.Unity;
using System.Windows;

namespace EventAggregatorFreeze
{
    public class Bootstrapper : UnityBootstrapper
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Bootstrapper"/> class.
        /// </summary>
        public Bootstrapper()
        {
        }

        /// <summary>
        /// Creates the <see cref="T:Microsoft.Practices.Unity.IUnityContainer" /> that will be used as the default container.
        /// </summary>
        /// <returns>
        /// A new instance of <see cref="T:Microsoft.Practices.Unity.IUnityContainer" />.
        /// </returns>
        protected override IUnityContainer CreateContainer()
        {
            return UnityService.Get().Container;
        }

        /// <summary>
        /// Configures the <see cref="T:Microsoft.Practices.Unity.IUnityContainer" />. May be overwritten in a derived class to add specific
        /// type mappings required by the application.
        /// </summary>
        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();

            Container.RegisterType<IEventAggregator, EventAggregator>();
        }

        /// <summary>
        /// Configures the <see cref="T:Microsoft.Practices.Prism.Modularity.IModuleCatalog" /> used by Prism.
        /// </summary>
        protected override void ConfigureModuleCatalog()
        {
            base.ConfigureModuleCatalog();

            ModuleCatalog moduleCatalog = (ModuleCatalog)ModuleCatalog;
            moduleCatalog.AddModule(typeof(AppModule));
        }

        /// <summary>
        /// Creates the shell.
        /// </summary>
        /// <returns>Main window view.</returns>
        protected override DependencyObject CreateShell()
        {
            RegisterServices();
            RegisterRegions();
            return Container.Resolve<MainWindow>();
        }

        /// <summary>
        /// Registers the services.
        /// </summary>
        private void RegisterServices()
        {
            Container.RegisterType<IViewService, ViewService>(new ContainerControlledLifetimeManager());
        }

        /// <summary>
        /// Initializes the shell.
        /// </summary>
        protected override void InitializeShell()
        {
            base.InitializeShell();

            // Make sure we have an instance created of IViewService
            // since it will receive events
            Container.Resolve<IViewService>();

            Application.Current.MainWindow = (Window)Shell;
            Application.Current.MainWindow?.Show();
        }

        /// <summary>
        /// Registers the regions.
        /// </summary>
        private void RegisterRegions()
        {
            IRegionManager regionManager = Container.Resolve<IRegionManager>();
        }
    }
}
