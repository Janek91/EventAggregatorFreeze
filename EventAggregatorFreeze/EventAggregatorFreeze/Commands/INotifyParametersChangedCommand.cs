﻿using System;

namespace EventAggregatorFreeze.Commands
{
    /// <summary>
    /// Interface for command parameter changed
    /// </summary>
    public interface INotifyParametersChangedCommand
    {
        /// <summary>
        /// Occurs when [parameters changed].
        /// </summary>
        event EventHandler ParametersChanged;
    }
}
