using EventAggregatorFreeze.Enums;
using Prism.Regions;
using System.Linq;

namespace EventAggregatorFreeze
{
    /// <summary>
    /// Describer for managing tabs.
    /// </summary>
    public class TabModelInformation
    {
        /// <summary>
        /// Gets a value indicating whether the tab has parameters.
        /// </summary>
        /// <value>True if this instance has parameters; otherwise, false.</value>
        public bool HasParameters { get { return Parameters?.Any() == true; } }

        /// <summary>
        /// Gets the parameters.
        /// </summary>
        public NavigationParameters Parameters { get; private set; }

        /// <summary>
        /// Gets the tab header.
        /// </summary>
        public string TabHeader { get; private set; }

        /// <summary>
        /// Gets the name of the related view.
        /// </summary>
        public ViewNames ViewName { get; private set; }

        /// <summary>
        /// Initializes a new instance of the TabModelInformation class.
        /// </summary>
        /// <param name="tabHeader">The tab header.</param>
        /// <param name="viewName">Name of the view.</param>
        public TabModelInformation(string tabHeader, ViewNames viewName)
            : this(tabHeader, viewName, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the TabModelInformation class.
        /// </summary>
        /// <param name="viewName">Name of the view.</param>
        /// <param name="parameters">The parameters.</param>
        public TabModelInformation(ViewNames viewName, NavigationParameters parameters = null)
            : this(viewName.ToString(), viewName, parameters)
        {
        }

        /// <summary>
        /// Initializes a new instance of the TabModelInformation class.
        /// </summary>
        /// <param name="tabHeader">The tab header.</param>
        /// <param name="viewName">Name of the view.</param>
        /// <param name="parameters">The parameters.</param>
        public TabModelInformation(string tabHeader, ViewNames viewName, NavigationParameters parameters)
        {
            TabHeader = tabHeader;
            ViewName = viewName;
            Parameters = parameters;
        }
    }
}