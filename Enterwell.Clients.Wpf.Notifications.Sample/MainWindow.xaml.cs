using System;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Enterwell.Clients.Wpf.Notifications.Controls;

namespace Enterwell.Clients.Wpf.Notifications.Sample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            this.DataContext = this;
        }


        private void ButtonBaseErrorOnClick(object sender, RoutedEventArgs e)
        {
            this.Manager
                .CreateMessage()
                .Accent("#F15B19")
                .Background("#F15B19")
                .HasHeader("Lost connection to server")
                .HasMessage("Reconnecting...")
                .WithOverlay(new ProgressBar
                {
                    VerticalAlignment = VerticalAlignment.Bottom,
                    HorizontalAlignment = HorizontalAlignment.Stretch,
                    Height = 3,
                    BorderThickness = new Thickness(0),
                    Foreground = new SolidColorBrush(Color.FromArgb(128, 255, 255, 255)),
                    Background = Brushes.Transparent,
                    IsIndeterminate = true,
                    IsHitTestVisible = false
                })
                .Queue();
        }

        private void ButtonBaseWarningOnClick(object sender, RoutedEventArgs e)
        {
            this.Manager
                .CreateMessage()
                .Accent("#E0A030")
                .Background("#333")
                .HasBadge("Warn")
                .HasMessage("Failed to retrieve data.")
                .WithButton("Try again", button => { })
                .Dismiss().WithButton("Ignore", button => { })
                .Queue();
        }

        private void ButtonBaseInfoOnClick(object sender, RoutedEventArgs e)
        {
            this.Manager
                .CreateMessage()
                .Accent("#1751C3")
                .Background("#333")
                .HasBadge("Info")
                .HasMessage("Update will be installed on next application restart.")
                .Dismiss().WithButton("Update now", button => { })
                .Dismiss().WithButton("Release notes", button => { })
                .Dismiss().WithButton("Later", button => { })
                .Queue();
        }

        public INotificationMessageManager Manager { get; } = new NotificationMessageManager();
    }
}
