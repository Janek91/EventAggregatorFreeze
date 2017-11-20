namespace EventAggregatorFreeze.Commands
{
    public interface ICommand<T>
    {
        /// <summary>
        /// Defines the method that determines whether the command can execute in its current state.
        /// </summary>
        /// <param name="parameter">The parameter for the command.</param>
        bool CanExecute(T parameter);
        /// <summary>
        /// Defines the method to be called when the command is invoked.
        /// </summary>
        /// <param name="parameter">The parameter for the command.</param>
        void Execute(T parameter);
    }
}
