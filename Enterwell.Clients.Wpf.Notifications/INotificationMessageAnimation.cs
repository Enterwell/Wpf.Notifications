using System.Windows;

namespace Enterwell.Clients.Wpf.Notifications
{
    interface INotificationMessageAnimation : INotificationMessage
    {
        /// <summary>
        /// Gets or sets whether the message animates in and out.
        /// </summary>
        bool Animates { get; set; }

        /// <summary>
        /// Gets or sets the animation duration.
        /// </summary>
        double AnimationDuration { get; set; }

        /// <summary>
        /// Gets the animatable Message element for add/remove transitions.
        /// Typically this is the whole Control object so that the entire
        /// item can be animated.
        /// </summary>
        UIElement AnimatableElement { get; }
    }
}
