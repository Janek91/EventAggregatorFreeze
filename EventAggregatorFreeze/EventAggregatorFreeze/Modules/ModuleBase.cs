using Microsoft.Practices.Unity;
using Prism.Events;
using Prism.Modularity;
using Prism.Regions;

namespace EventAggregatorFreeze.Modules
{
    public abstract class ModuleBase : IModule
    {
        protected IUnityContainer UnityContainer { get; private set; }
        protected IRegionManager RegionManager { get; private set; }
        protected IEventAggregator EventAggregator { get; private set; }

        protected ModuleBase(IUnityContainer container, IRegionManager manager, IEventAggregator bus)
        {
            UnityContainer = container;
            RegionManager = manager;
            EventAggregator = bus;
        }

        public virtual void Initialize()
        { }
    }
}
