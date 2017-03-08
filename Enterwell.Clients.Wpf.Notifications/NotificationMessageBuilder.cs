using System;
using System.Windows.Media;

namespace Enterwell.Clients.Wpf.Notifications
{
    /// <summary>
    /// The notification message builder.
    /// </summary>
    public class NotificationMessageBuilder
    {
        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>
        /// The message.
        /// </value>
        public INotificationMessage Message { get; set; }

        /// <summary>
        /// Gets or sets the manager.
        /// </summary>
        /// <value>
        /// The manager.
        /// </value>
        public INotificationMessageManager Manager { get; set; }


        /// <summary>
        /// Creates the message.
        /// </summary>
        /// <returns>Returns new instance of notification message builder tha tis used to create notification message.</returns>
        public static NotificationMessageBuilder CreateMessage()
        {
            return new NotificationMessageBuilder();
        }

        /// <summary>
        /// Sets the header.
        /// </summary>
        /// <param name="header">The header.</param>
        public void SetHeader(string header)
        {
            this.Message.Header = header;
        }

        /// <summary>
        /// Sets the message.
        /// </summary>
        /// <param name="message">The message.</param>
        public void SetMessage(string message)
        {
            this.Message.Message = message;
        }

        /// <summary>
        /// Adds the button.
        /// </summary>
        /// <param name="button">The button.</param>
        public void AddButton(INotificationMessageButton button)
        {
            if (button == null)
                throw new ArgumentNullException(nameof(button));

            this.Message.Buttons.Add(button);
        }

        /// <summary>
        /// Sets the badge.
        /// </summary>
        /// <param name="badgeText">The badge text.</param>
        public void SetBadge(string badgeText)
        {
            this.Message.BadgeText = badgeText;
        }

        /// <summary>
        /// Sets the accent.
        /// </summary>
        /// <param name="accentBrush">The accent brush.</param>
        public void SetAccent(Brush accentBrush)
        {
            this.Message.AccentBrush = accentBrush;
        }

        /// <summary>
        /// Sets the background.
        /// </summary>
        /// <param name="backgroundBrush">The background brush.</param>
        public void SetBackground(Brush backgroundBrush)
        {
            this.Message.Background = backgroundBrush;
        }

        /// <summary>
        /// Sets the overlay.
        /// </summary>
        /// <param name="overlay">The overlay.</param>
        public void SetOverlay(object overlay)
        {
            this.Message.OverlayContent = overlay;
        }

        /// <summary>
        /// Queues the message to manager.
        /// </summary>
        /// <returns>Returns the queued message.</returns>
        public INotificationMessage Queue()
        {
            this.Manager.Queue(this.Message);

            return this.Message;
        }


        /// <summary>
        /// The notification message button that is required to dismiss the notification.
        /// </summary>
        public class DismissNotificationMessageButton
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="DismissNotificationMessageButton"/> class.
            /// </summary>
            /// <param name="builder">The builder.</param>
            /// <exception cref="ArgumentNullException">builder</exception>
            public DismissNotificationMessageButton(NotificationMessageBuilder builder)
            {
                this.Builder = builder ?? throw new ArgumentNullException(nameof(builder));
            }

            /// <summary>
            /// Gets or sets the builder.
            /// </summary>
            /// <value>
            /// The builder.
            /// </value>
            public NotificationMessageBuilder Builder { get; set; }
        }
    }
}