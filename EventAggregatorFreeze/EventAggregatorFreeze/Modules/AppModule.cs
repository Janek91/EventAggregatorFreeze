using EventAggregatorFreeze.Commands;
using EventAggregatorFreeze.Constants;
using EventAggregatorFreeze.Enums;
using EventAggregatorFreeze.Events;
using EventAggregatorFreeze.Infrastructure;
using EventAggregatorFreeze.Menu;
using EventAggregatorFreeze.Providers;
using EventAggregatorFreeze.UserControls;
using EventAggregatorFreeze.Views;
using Microsoft.Practices.Unity;
using Prism.Events;
using Prism.Regions;
using System.Collections.Generic;
using System.Windows.Controls;

namespace EventAggregatorFreeze.Modules
{
    public class AppModule : ModuleBase
    {

        /// <summary>
        /// Initializes a new instance of the HIPModule class.
        /// </summary>
        /// <param name="container">The container.</param>
        /// <param name="regionManager">The region manager.</param>
        /// <param name="eventBus">The event bus.</param>
        public AppModule(IUnityContainer container,
            IRegionManager regionManager,
            IEventAggregator eventBus)
            : base(container, regionManager, eventBus)
        {
        }

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        public override void Initialize()
        {
            RegisterViews();
            RegisterRegions();
            EventAggregator.GetEvent<LoadTabEvent>().Publish(new TabModelInformation(ViewNames.ProductsView));
            LoadMenuItems();
        }

        /// <summary>
        /// Loads the menu items.
        /// </summary>
        private void LoadMenuItems()
        {
            IList<BaseMenuItemDescriptor> fileSubItems = new List<BaseMenuItemDescriptor>
            {
                new MenuItemDescriptor(MenuHeaders.ExitHeader, new DelegateCommandProvider<object>().CreateCommand<ExitCommand>())
            };

            MenuItemDescriptor file = new MenuItemDescriptor(MenuHeaders.FileHeader, null, fileSubItems);
            EventAggregator.GetEvent<MenuItemEvent>().Publish(file);
        }

        /// <summary>
        /// Registers the views.
        /// </summary>
        private void RegisterViews()
        {
            UnityContainer.RegisterType<UserControl, UcMenus>(ViewNames.MenuControl.ToString());
            UnityContainer.RegisterType<UserControl, UcStatusBar>(ViewNames.StatusBarControl.ToString());
            UnityContainer.RegisterType<UserControl, EmptyView>(ViewNames.EmptyView.ToString());
            UnityContainer.RegisterType<UserControl, MainTabView>(ViewNames.MainTabView.ToString());
        }

        /// <summary>
        /// Registers the regions.
        /// </summary>
        private void RegisterRegions()
        {
            RegionManager.RegisterViewWithRegion(RegionNames.MainMenuRegion, () => UnityContainer.Resolve<UcMenus>());
            RegionManager.RegisterViewWithRegion(RegionNames.MainContentRegion, () => UnityContainer.Resolve<MainTabView>());
            RegionManager.RegisterViewWithRegion(RegionNames.MainStatusBarRegion, () => UnityContainer.Resolve<UcStatusBar>());
        }
    }
}
