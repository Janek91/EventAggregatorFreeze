using EventAggregatorFreeze.Menu;
using Prism.Events;

namespace EventAggregatorFreeze.Events
{
    /// <summary>
    /// Menu item event.
    /// </summary>
    public class MenuItemEvent : PubSubEvent<BaseMenuItemDescriptor>
    {
    }
}
