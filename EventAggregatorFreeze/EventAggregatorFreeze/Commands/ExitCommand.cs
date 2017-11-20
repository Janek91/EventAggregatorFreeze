using System.Windows;

namespace EventAggregatorFreeze.Commands
{
    public class ExitCommand : CommandBase<object>
    {
        public ExitCommand()
            : base()
        {
        }

        public override bool CanExecute(object parameter)
        {
            return Application.Current != null && Application.Current.MainWindow != null;
        }

        public override void Execute(object parameter)
        {
            Application.Current.MainWindow?.Close();
        }
    }
}
