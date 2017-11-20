using Prism.Commands;
using System;
using System.Collections.Generic;

namespace EventAggregatorFreeze.Menu
{
    /// <summary>
    /// Descriptor for menu item
    /// </summary>
    public class MenuItemDescriptor : BaseMenuItemDescriptor
    {
        /// <summary>
        /// Gets or sets the label.
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// Gets or sets the command.
        /// </summary>
        public DelegateCommandBase Command { get; set; }

        /// <summary>
        /// Gets or sets the sub items.
        /// </summary>
        public IEnumerable<BaseMenuItemDescriptor> SubItems { get; set; }

        /// <summary>
        /// Gets or sets the icon.
        /// </summary>
        public Enum Icon { get; set; }

        /// <summary>
        /// Gets or sets the tooltip.
        /// </summary>
        public string ToolTip { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MenuItemDescriptor" /> class.
        /// </summary>
        /// <param name="label">The label.</param>
        /// <param name="command">The command.</param>
        /// <param name="subItems">The sub items.</param>
        /// <param name="icon">The icon.</param>
        /// <param name="toolTip">The tooltip.</param>
        public MenuItemDescriptor(string label,
            DelegateCommandBase command = null,
            IEnumerable<BaseMenuItemDescriptor> subItems = null,
            Enum icon = null,
            string toolTip = null)
        {
            Label = label;
            Command = command;
            SubItems = subItems;
            Icon = icon;
            ToolTip = toolTip;
        }
    }
}
