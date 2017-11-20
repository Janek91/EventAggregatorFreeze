using EventAggregatorFreeze.Commands;
using Prism.Commands;
using System;
using System.Windows;

namespace EventAggregatorFreeze.Providers
{
    public class DelegateCommandProvider<TParameter> : ICommandProvider<DelegateCommand<TParameter>, TParameter>, IDelegateCommandProvider<TParameter>
    {
        public DelegateCommandProvider()
            : base()
        {
        }

        public DelegateCommand<TParameter> CreateCommand<TCommandType>()
            where TCommandType : class, ICommand<TParameter>
        {
            TCommandType cmd = Activator.CreateInstance(typeof(TCommandType)) as TCommandType;
            return new DelegateCommand<TParameter>(p => cmd.Execute(p), p => cmd.CanExecute(p));
        }

        public DelegateCommand<TParameter> CreateCommand<TCommandType>(params object[] args) where TCommandType : class, ICommand<TParameter>
        {
            TCommandType cmd = Activator.CreateInstance(typeof(TCommandType), args) as TCommandType;

            DelegateCommand<TParameter> delegateCommand = new DelegateCommand<TParameter>(p => cmd.Execute(p), p => cmd.CanExecute(p));
            INotifyParametersChangedCommand notifyParametersChangedCommand = cmd as INotifyParametersChangedCommand;

            if (notifyParametersChangedCommand != null)
            {
                WeakEventManager<INotifyParametersChangedCommand, EventArgs>.AddHandler(notifyParametersChangedCommand, nameof(notifyParametersChangedCommand.ParametersChanged), (sender, eventArgs) => delegateCommand.RaiseCanExecuteChanged());
            }

            return delegateCommand;
        }
    }

    public class DelegateCommandProvider<TContext, TParameter> : ICommandProvider<TContext, DelegateCommand<TParameter>, TParameter>
    {
        public DelegateCommandProvider()
            : base()
        {
        }

        public DelegateCommand<TParameter> CreateCommand<TCommandType>(TContext context, params dynamic[] args)
            where TCommandType : class, IContextCommand<TContext, TParameter>
        {
            TCommandType cmd = Activator.CreateInstance(typeof(TCommandType), args) as TCommandType;
            cmd.SetContext(context);
            return new DelegateCommand<TParameter>(p => cmd.Execute(p), p => cmd.CanExecute(p));
        }
    }
}
