using EventAggregatorFreeze.Events;
using EventAggregatorFreeze.Menu;
using Microsoft.Practices.Unity;
using Prism.Events;
using Prism.Mvvm;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Controls;

namespace EventAggregatorFreeze
{
    public class MainWindowViewModel : BindableBase
    {
        private IUnityContainer _container;

        /// <summary>
        /// The event bus.
        /// </summary>
        public readonly IEventAggregator EventBus;

        /// <summary>
        /// The subscription token, makes it possible to unsubscribe to the event properly
        /// </summary>
        private SubscriptionToken _menuItemEventSubscriptionToken;

        /// <summary>
        /// Gets or sets the items.
        /// </summary>
        public ObservableCollection<MenuItem> Items { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindowViewModel"/> class.
        /// </summary>
        /// <param name="container">The container.</param>
        /// <param name="eventBus">The event bus.</param>
        public MainWindowViewModel(IUnityContainer container,
            IEventAggregator eventBus)
        {
            EventBus = eventBus;
            _container = container;
            SubscribeEvents(eventBus);
            Items = new ObservableCollection<MenuItem>();
        }

        /// <summary>
        /// Subscribes to the events.
        /// </summary>
        /// <param name="eventBus">The event bus.</param>
        protected void SubscribeEvents(IEventAggregator eventBus)
        {
            _menuItemEventSubscriptionToken = eventBus.GetEvent<MenuItemEvent>().Subscribe(ProcessMenuItemEvent);
        }

        /// <summary>
        /// Unsubscribes to the events.
        /// </summary>
        protected void UnsubscribeEvents()
        {
            EventBus.GetEvent<MenuItemEvent>().Unsubscribe(_menuItemEventSubscriptionToken);
        }

        /// <summary>
        /// Processes the menu item event.
        /// </summary>
        /// <param name="parameter">The parameter.</param>
        private void ProcessMenuItemEvent(BaseMenuItemDescriptor parameter)
        {
            AddMenuItem(parameter, Items);
        }

        /// <summary>
        /// Adds the menu item.
        /// </summary>
        /// <param name="parameter">The parameter.</param>
        /// <param name="items">The items.</param>
        private void AddMenuItem(BaseMenuItemDescriptor parameter, ObservableCollection<MenuItem> items)
        {
            ObservableCollection<MenuItem> tempList = new ObservableCollection<MenuItem>();

            MenuItemDescriptor menuItem = parameter as MenuItemDescriptor;

            if (menuItem != null)
            {
                if (menuItem.SubItems != null)
                {
                    foreach (BaseMenuItemDescriptor subItem in menuItem.SubItems)
                    {
                        AddMenuItem(subItem, tempList);
                    }
                }

                MenuItem radMenuItem = new MenuItem
                {
                    Command = menuItem.Command,
                    Header = menuItem.Label,
                    ToolTip = menuItem.ToolTip
                };
                ToolTipService.SetShowOnDisabled(radMenuItem, true);


                if (tempList.Any())
                {
                    tempList.Select(it => radMenuItem.Items.Add(it)).ToList();
                }

                items.Add(radMenuItem);
            }
        }
    }
}
