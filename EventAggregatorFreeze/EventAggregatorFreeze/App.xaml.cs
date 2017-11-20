using System;
using System.Windows;
using System.Windows.Threading;

namespace EventAggregatorFreeze
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// The bootstrapper.
        /// </summary>
        private Bootstrapper _bootstrapper;

        /// <summary>
        /// Initializes a new instance of <see cref="App"/> class.
        /// </summary>
        public App()
        {
        }

        /// <summary>
        /// Handles the Startup event.
        /// </summary>
        /// <param name="e">A StartupEventArgs that contains the event data.</param>
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            DispatcherUnhandledException += OnAppDispatcherUnhandledException;
            AppDomain.CurrentDomain.UnhandledException += OnAppDomainUnhandledException;

            _bootstrapper = new Bootstrapper();
            _bootstrapper.Run();
        }

        /// <summary>
        /// Handles app domain unhandled exception.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="UnhandledExceptionEventArgs"/> instance containing the event data.</param>
        private void OnAppDomainUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception exception = e.ExceptionObject as Exception;
            if (exception != null)
            {
                throw exception;
            }
        }

        /// <summary>
        /// Handles dispatcher unhandled exception.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">Event args.</param>
        private void OnAppDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            if (e.Exception != null)
            {
                throw e.Exception;
            }
            e.Handled = true;
        }
    }
}
