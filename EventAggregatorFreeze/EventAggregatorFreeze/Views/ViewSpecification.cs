using Prism.Regions;
using System;

namespace EventAggregatorFreeze.Views
{
    /// <summary>
    /// View specification.
    /// </summary>
    public class ViewSpecification
    {
        /// <summary>
        /// Gets the target.
        /// </summary>
        public Uri Target { get; private set; }

        /// <summary>
        /// Gets the parameters.
        /// </summary>
        public NavigationParameters Parameters { get; private set; }

        /// <summary>
        /// Gets a value indicating whether Region Manager should handle it.
        /// </summary>
        public bool ForRegionManager { get; private set; }

        /// <summary>
        /// Initializes a new instance of the ViewSpecification class.
        /// </summary>
        /// <param name="target">The target.</param>
        /// <param name="parameters">The parameters.</param>
        /// <param name="forRegionManager">If set to true: for region manager should handle it.</param>
        public ViewSpecification(Uri target, NavigationParameters parameters = null, bool forRegionManager = false)
        {
            Target = target;
            Parameters = parameters;
            ForRegionManager = forRegionManager;
        }

        public Uri GetAddress()
        {
            return new Uri(Target.OriginalString + (Parameters?.ToString() ?? string.Empty), Target.IsAbsoluteUri ? UriKind.Absolute : UriKind.Relative);
        }
    }
}
