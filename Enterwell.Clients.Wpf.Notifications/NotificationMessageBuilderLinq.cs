using System;
using System.Windows.Media;

namespace Enterwell.Clients.Wpf.Notifications
{
    /// <summary>
    /// The notification message builder LINQ helper.
    /// </summary>
    public static class NotificationMessageBuilderLinq
    {
        /// <summary>
        /// Sets the notification mesage background.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <param name="backgroundBrush">The background brush.</param>
        /// <returns>Returns the noitificaiton message builder.</returns>
        public static NotificationMessageBuilder Background(
            this NotificationMessageBuilder builder,
            Brush backgroundBrush)
        {
            builder.SetBackground(backgroundBrush);

            return builder;
        }

        /// <summary>
        /// Sets the notification mesage background.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <param name="backgroundBrush">The background brush.</param>
        /// <returns>Returns the noitificaiton message builder.</returns>
        public static NotificationMessageBuilder Background(
            this NotificationMessageBuilder builder,
            string backgroundBrush)
        {
            var brush = new BrushConverter().ConvertFrom(backgroundBrush) as Brush;
            builder.SetBackground(brush);

            return builder;
        }

        /// <summary>
        /// Sets the notification mesage accent.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <param name="accentBrush">The accent brush.</param>
        /// <returns>Returns the noitificaiton message builder.</returns>
        public static NotificationMessageBuilder Accent(
            this NotificationMessageBuilder builder,
            Brush accentBrush)
        {
            builder.SetAccent(accentBrush);

            return builder;
        }

        /// <summary>
        /// Sets the notification mesage accent.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <param name="accentBrush">The accent brush.</param>
        /// <returns>Returns the noitificaiton message builder.</returns>
        public static NotificationMessageBuilder Accent(
            this NotificationMessageBuilder builder,
            string accentBrush)
        {
            var brush = new BrushConverter().ConvertFrom(accentBrush) as Brush;
            builder.SetAccent(brush);

            return builder;
        }

        /// <summary>
        /// Sets the badge text.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <param name="badgeText">The badge text.</param>
        /// <returns>Returns the notification message builder.</returns>
        public static NotificationMessageBuilder HasBadge(
            this NotificationMessageBuilder builder,
            string badgeText)
        {
            builder.SetBadge(badgeText);

            return builder;
        }

        /// <summary>
        /// Sets the message header text.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <param name="header">The header text.</param>
        /// <returns>Returns the notification message builder.</returns>
        public static NotificationMessageBuilder HasHeader(
            this NotificationMessageBuilder builder,
            string header)
        {
            builder.SetHeader(header);

            return builder;
        }

        /// <summary>
        /// Sets the message text.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <param name="message">The message text.</param>
        /// <returns>Returns the notification message builder.</returns>
        public static NotificationMessageBuilder HasMessage(
            this NotificationMessageBuilder builder,
            string message)
        {
            builder.SetMessage(message);

            return builder;
        }

        /// <summary>
        /// Creates the message.
        /// </summary>
        /// <param name="manager">The manager.</param>
        /// <returns>Returns the notification message builder.</returns>
        public static NotificationMessageBuilder CreateMessage(
            this INotificationMessageManager manager)
        {
            var builder = NotificationMessageBuilder.CreateMessage();
            builder.Manager = manager;
            builder.Message = manager.Factory.GetMessage();

            return builder;
        }

        /// <summary>
        /// Marks next button to be dismiss button.
        /// This button will dismiss the noitification message when clicked.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <returns>Returns the notiification message builder.</returns>
        public static NotificationMessageBuilder.DismissNotificationMessageButton Dismiss(
            this NotificationMessageBuilder builder)
        {
            return new NotificationMessageBuilder.DismissNotificationMessageButton(builder);
        }

        /// <summary>
        /// Adds the button to the notification message.
        /// </summary>
        /// <param name="dismissButton">The dismiss button.</param>
        /// <param name="content">The content.</param>
        /// <param name="callback">The callback.</param>
        /// <returns>Returns the notification message builder.</returns>
        public static NotificationMessageBuilder WithButton(
            this NotificationMessageBuilder.DismissNotificationMessageButton dismissButton,
            object content,
            Action<INotificationMessageButton> callback)
        {
            return dismissButton.Builder.WithButton(content, dismissButton.Builder.DismissBefore(callback));
        }

        /// <summary>
        /// Adds the button to the notification message.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <param name="content">The content.</param>
        /// <param name="callback">The callback.</param>
        /// <returns>Returns the notification message builder.</returns>
        public static NotificationMessageBuilder WithButton(
            this NotificationMessageBuilder builder,
            object content,
            Action<INotificationMessageButton> callback)
        {
            var button = builder.Manager.Factory.GetButton();
            button.Callback = callback;
            button.Content = content;

            builder.AddButton(button);

            return builder;
        }

        /// <summary>
        /// Attached the dismiss action before callback action.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <param name="callback">The callback.</param>
        /// <returns>
        /// Returns the action that will call manager dismiss for noitification 
        /// message in builder when button is clicked and then call the callback action.
        /// </returns>
        private static Action<INotificationMessageButton> DismissBefore(
            this NotificationMessageBuilder builder,
            Action<INotificationMessageButton> callback)
        {
            return button =>
            {
                builder.Manager.Dismiss(builder.Message);
                callback?.Invoke(button);
            };
        }

        /// <summary>
        /// Sets the noitification message overlay.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <param name="overlay">The overlay.</param>
        /// <returns>Returns the notification message builder.</returns>
        public static NotificationMessageBuilder WithOverlay(
            this NotificationMessageBuilder builder,
            object overlay)
        {
            builder.SetOverlay(overlay);

            return builder;
        }
    }
}