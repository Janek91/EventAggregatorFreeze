using EventAggregatorFreeze.Views;
using Prism.Events;

namespace EventAggregatorFreeze.Events
{
    public class LoadViewEvent : PubSubEvent<ViewSpecification>
    {
    }
}
