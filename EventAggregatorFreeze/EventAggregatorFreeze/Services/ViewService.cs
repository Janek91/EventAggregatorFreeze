using EventAggregatorFreeze.Events;
using EventAggregatorFreeze.Infrastructure;
using EventAggregatorFreeze.Views;
using Prism.Events;
using Prism.Regions;
using System;
using System.Linq;

namespace EventAggregatorFreeze.Services
{
    /// <summary>
    /// View service.
    /// </summary>
    public class ViewService : IViewService
    {
        /// <summary>
        /// The subscription token, makes it possible to unsubscribe to the event properly
        /// </summary>
        private SubscriptionToken _subscriptionToken;

        /// <summary>
        /// Gets the region manager.
        /// </summary>
        protected IRegionManager RegionManager { get; private set; }

        /// <summary>
        /// Gets the event aggregator.
        /// </summary>
        protected IEventAggregator EventAggregator { get; private set; }

        /// <summary>
        /// Initializes a new instance of the ViewService class.
        /// </summary>
        /// <param name="manager">The manager.</param>
        /// <param name="eventBus">The event bus.</param>
        public ViewService(IRegionManager manager, IEventAggregator eventBus)
        {
            RegionManager = manager;
            EventAggregator = eventBus;
            SubscribeToEvent();
        }

        /// <summary>
        /// Removes the view.
        /// </summary>
        /// <param name="viewType">Type of the view.</param>
        public void RemoveView(Type viewType)
        {
            dynamic viewInstance = GetViewInstance(viewType);
            if (viewInstance != null)
            {
                RegionManager.Regions[RegionNames.MainContentRegion].Remove(viewInstance);
            }

            EventAggregator.GetEvent<LoadViewEvent>().Unsubscribe(_subscriptionToken);
        }

        /// <summary>
        /// Selects the view.
        /// </summary>
        /// <param name="viewType">Type of the view.</param>
        public void SelectView(Type viewType)
        {
            dynamic viewInstance = GetViewInstance(viewType);
            if (viewInstance != null)
            {
                RegionManager.Regions[RegionNames.MainContentRegion].Activate(viewInstance);
            }
        }

        /// <summary>
        /// Loads the view.
        /// </summary>
        /// <param name="specification">The specification.</param>
        public void LoadView(ViewSpecification specification)
        {
            RegionManager.RequestNavigate(RegionNames.MainContentRegion, specification.GetAddress(), NavigationCompleted, specification.Parameters);
        }

        /// <summary>
        /// Navigations the completed.
        /// </summary>
        /// <param name="result">The result.</param>
        private void NavigationCompleted(NavigationResult result)
        {
            if (result.Result != null && !result.Result.Value && result.Error != null)
            {
                throw new InvalidOperationException(result.Error.Message);
            }
        }

        /// <summary>
        /// Subscribes to event.
        /// </summary>
        private void SubscribeToEvent()
        {
            _subscriptionToken = EventAggregator.GetEvent<LoadViewEvent>().Subscribe(LoadView, ThreadOption.PublisherThread, false, vs => vs.ForRegionManager);
        }

        /// <summary>
        /// Gets the view instance.
        /// </summary>
        /// <param name="viewType">Type of the view.</param>
        /// <returns></returns>
        private dynamic GetViewInstance(Type viewType)
        {
            return RegionManager.Regions[RegionNames.MainContentRegion].Views.Where(x => x.GetType().Equals(viewType)).FirstOrDefault();
        }
    }
}
