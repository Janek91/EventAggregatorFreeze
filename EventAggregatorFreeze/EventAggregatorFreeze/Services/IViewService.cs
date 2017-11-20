using EventAggregatorFreeze.Views;
using System;

namespace EventAggregatorFreeze.Services
{
    public interface IViewService
    {
        void LoadView(ViewSpecification specification);
        void RemoveView(Type viewType);
        void SelectView(Type viewType);
    }
}
