﻿using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;

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
        /// <returns>Returns new instance of notification message builder that is used to create notification message.</returns>
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
            Message.Header = header;
        }

        /// <summary>
        /// Sets the message.
        /// </summary>
        /// <param name="message">The message.</param>
        public void SetMessage(string message)
        {
            Message.Message = message;
        }

        /// <summary>
        /// Adds the button.
        /// </summary>
        /// <param name="button">The button.</param>
        public void AddButton(INotificationMessageButton button)
        {
            if (button == null)
                throw new ArgumentNullException(nameof(button));

            Message.Buttons.Add(button);
        }

        /// <summary>
        /// Sets the badge.
        /// </summary>
        /// <param name="badgeText">The badge text.</param>
        public void SetBadge(string badgeText)
        {
            Message.BadgeText = badgeText;
        }

        /// <summary>
        /// Sets the accent.
        /// </summary>
        /// <param name="accentBrush">The accent brush.</param>
        public void SetAccent(Brush accentBrush)
        {
            Message.AccentBrush = accentBrush;
        }

        /// <summary>
        /// Sets the background.
        /// </summary>
        /// <param name="backgroundBrush">The background brush.</param>
        public void SetBackground(Brush backgroundBrush)
        {
            Message.Background = backgroundBrush;
        }

        /// <summary>
        /// Sets the overlay.
        /// </summary>
        /// <param name="overlay">The overlay.</param>
        public void SetOverlay(object overlay)
        {
            Message.OverlayContent = overlay;
        }

        /// <summary>
        /// Sets the top additional content.
        /// </summary>
        /// <param name="additionalContentTop">The additional content.</param>
        public void SetAdditionalContentTop(object additionalContentTop)
        {
            Message.AdditionalContentTop = additionalContentTop;
        }

        /// <summary>
        /// Sets the bottom additional content.
        /// </summary>
        /// <param name="additionalContentBottom">The additional content.</param>
        public void SetAdditionalContentBottom(object additionalContentBottom)
        {
            Message.AdditionalContentBottom = additionalContentBottom;
        }

        /// <summary>
        /// Sets the left additional content.
        /// </summary>
        /// <param name="additionalContentLeft">The additional content.</param>
        public void SetAdditionalContentLeft(object additionalContentLeft)
        {
            Message.AdditionalContentLeft = additionalContentLeft;
        }

        /// <summary>
        /// Sets the right additional content.
        /// </summary>
        /// <param name="additionalContentRight">The additional content.</param>
        public void SetAdditionalContentRight(object additionalContentRight)
        {
            Message.AdditionalContentRight = additionalContentRight;
        }

        /// <summary>
        /// Sets the center additional content.
        /// </summary>
        /// <param name="additionalContentMain">The additional content.</param>
        public void SetAdditionalContentMain(object additionalContentMain)
        {
            Message.AdditionalContentMain = additionalContentMain;
        }

        /// <summary>
        /// Sets the additional content over the badge.
        /// </summary>
        /// <param name="additionalContentOverBadge">The additional content.</param>
        public void SetAdditionalContentOverBadge(object additionalContentOverBadge)
        {
            Message.AdditionalContentOverBadge = additionalContentOverBadge;
        }

        /// <summary>
        /// Sets the text brush.
        /// </summary>
        public void SetForeground(Brush brush)
        {
            Message.Foreground = brush;
        }

        /// <summary>
        /// Sets whether or not the message animates.
        /// </summary>
        /// <param name="animates"></param>
        public void SetAnimates(bool animates)
        {
            if (Message is INotificationAnimation animation)
            {
                animation.Animates = animates;
            }
        }

        /// <summary>
        /// Sets the duration for the animation in (in seconds).
        /// </summary>
        /// <param name="duration">The in animation duration (in seconds).</param>
        public void SetAnimationInDuration(double duration)
        {
            if (Message is INotificationAnimation animation)
            {
                animation.AnimationInDuration = duration;
            }
        }

        /// <summary>
        /// Sets the duration for the animation out (in seconds).
        /// </summary>
        /// <param name="duration">The out animation duration (in seconds).</param>
        public void SetAnimationOutDuration(double duration)
        {
            if (Message is INotificationAnimation animation)
            {
                animation.AnimationOutDuration = duration;
            }
        }

        /// <summary>
        /// Sets the animation in for the message.
        /// </summary>
        /// <param name="animation"></param>
        public void SetAnimationIn(AnimationTimeline animation)
        {
            if (Message is INotificationAnimation notificationAnimation)
            {
                notificationAnimation.AnimationIn = animation;
            }
        }

        /// <summary>
        /// Sets the animation out for the message.
        /// </summary>
        /// <param name="animation"></param>
        public void SetAnimationOut(AnimationTimeline animation)
        {
            if (Message is INotificationAnimation notificationAnimation)
            {
                notificationAnimation.AnimationOut = animation;
            }
        }

        /// <summary>
        /// Sets the animation in dependency property.
        /// </summary>
        /// <param name="property"></param>
        public void SetAnimationInDependencyProperty(DependencyProperty property)
        {
            if (Message is INotificationAnimation animation)
            {
                animation.AnimationInDependencyProperty = property;
            }
        }

        /// <summary>
        /// Sets the animation out dependency property.
        /// </summary>
        /// <param name="property"></param>
        public void SetAnimationOutDependencyProperty(DependencyProperty property)
        {
            if (Message is INotificationAnimation animation)
            {
                animation.AnimationOutDependencyProperty = property;
            }
        }

        /// <summary>
        /// Queues the message to manager.
        /// </summary>
        /// <returns>Returns the queued message.</returns>
        public INotificationMessage Queue()
        {
            Manager.Queue(Message);

            return Message;
        }

        /// <summary>
        /// Executes the action after specified delay time.
        /// </summary>
        /// <param name="delayMilliseconds">The delay in milliseconds.</param>
        /// <param name="action">The action.</param>
        public void Delay(int delayMilliseconds, Action<INotificationMessage> action)
        {
            Delay(TimeSpan.FromMilliseconds(delayMilliseconds), action);
        }

        /// <summary>
        /// Executes the action after specified delay time.
        /// </summary>
        /// <param name="delay">The delay.</param>
        /// <param name="action">The action.</param>
        public void Delay(TimeSpan delay, Action<INotificationMessage> action)
        {
            Task.Delay(delay).ContinueWith(
                context => action(Message),
                TaskScheduler.FromCurrentSynchronizationContext());
        }

        /// <summary>
        /// The notification message button that is required to dismiss the notification.
        /// </summary>
        public class DismissNotificationMessage
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="DismissNotificationMessage"/> class.
            /// </summary>
            /// <param name="builder">The builder.</param>
            /// <exception cref="ArgumentNullException">builder</exception>
            public DismissNotificationMessage(NotificationMessageBuilder builder)
            {
                Builder = builder ?? throw new ArgumentNullException(nameof(builder));
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