namespace EventAggregatorFreeze.Commands
{
    public interface IContextCommand<TContext, TParameter> : ICommand<TParameter>
    {
        /// <summary>
        /// Gets the context.
        /// </summary>
        /// <value>
        /// The context for the command.
        /// </value>
        TContext Context { get; }
        /// <summary>
        /// Sets the context.
        /// </summary>
        /// <param name="context">The context for the command.</param>
        /// <returns>MySelf.</returns>
        IContextCommand<TContext, TParameter> SetContext(TContext context);
    }
}
