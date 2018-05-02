using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Enterwell.Clients.Wpf.Notifications.Controls
{
    /// <summary>
    /// The notification message control.
    /// </summary>
    /// <seealso cref="INotificationMessage" />
    /// <seealso cref="Control" />
    public class NotificationMessage : Control, INotificationMessageAnimation
    {
        /// <summary>
        /// Gets or sets the content of the overlay.
        /// </summary>
        /// <value>
        /// The content of the overlay.
        /// </value>
        public object OverlayContent
        {
            get => GetValue(OverlayContentProperty);
            set => SetValue(OverlayContentProperty, value);
        }

        /// <summary>
        /// Gets or sets the accent brush.
        /// </summary>
        /// <value>
        /// The accent brush.
        /// </value>
        public Brush AccentBrush
        {
            get => (Brush)GetValue(AccentBrushProperty);
            set => SetValue(AccentBrushProperty, value);
        }

        /// <summary>
        /// Gets or sets the button accent brush.
        /// </summary>
        /// <value>
        /// The button accent brush.
        /// </value>
        public Brush ButtonAccentBrush
        {
            get => (Brush)GetValue(ButtonAccentBrushProperty);
            set => SetValue(ButtonAccentBrushProperty, value);
        }

        /// <summary>
        /// Gets or sets the badge visibility.
        /// </summary>
        /// <value>
        /// The badge visibility.
        /// </value>
        public Visibility BadgeVisibility
        {
            get => (Visibility)GetValue(BadgeVisibilityProperty);
            set => SetValue(BadgeVisibilityProperty, value);
        }

        /// <summary>
        /// Gets or sets the badge accent brush.
        /// </summary>
        /// <value>
        /// The badge accent brush.
        /// </value>
        public Brush BadgeAccentBrush
        {
            get => (Brush)GetValue(BadgeAccentBrushProperty);
            set => SetValue(BadgeAccentBrushProperty, value);
        }

        /// <summary>
        /// Gets or sets the badge text.
        /// </summary>
        /// <value>
        /// The badge text.
        /// </value>
        public string BadgeText
        {
            get => (string)GetValue(BadgeTextProperty);
            set => SetValue(BadgeTextProperty, value);
        }

        /// <summary>
        /// Gets or sets the header visibility.
        /// </summary>
        /// <value>
        /// The header visibility.
        /// </value>
        public Visibility HeaderVisibility
        {
            get => (Visibility)GetValue(HeaderVisibilityProperty);
            set => SetValue(HeaderVisibilityProperty, value);
        }

        /// <summary>
        /// Gets or sets the header.
        /// </summary>
        /// <value>
        /// The header.
        /// </value>
        public string Header
        {
            get => (string)GetValue(HeaderProperty);
            set => SetValue(HeaderProperty, value);
        }

        /// <summary>
        /// Gets or sets the message visibility.
        /// </summary>
        /// <value>
        /// The message visibility.
        /// </value>
        public Visibility MessageVisibility
        {
            get => (Visibility)GetValue(MessageVisibilityProperty);
            set => SetValue(MessageVisibilityProperty, value);
        }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>
        /// The message.
        /// </value>
        public string Message
        {
            get => (string)GetValue(MessageProperty);
            set => SetValue(MessageProperty, value);
        }

        /// <summary>
        /// Gets or sets the buttons.
        /// </summary>
        /// <value>
        /// The buttons.
        /// </value>
        public ObservableCollection<object> Buttons
        {
            get => (ObservableCollection<object>)GetValue(ButtonsProperty);
            set => SetValue(ButtonsProperty, value);
        }

        /// <summary>
        /// Gets or sets whether the message animates.
        /// </summary>
        /// <value>
        /// Whether or not the message animates.
        /// </value>
        public bool Animates
        {
            get => (bool)GetValue(AnimatesProperty);
            set => SetValue(AnimatesProperty, value);
        }

        /// <summary>
        /// Gets or sets how long the message animates in seconds.
        /// </summary>
        /// <value>
        /// How long the message animates in seconds.
        /// </value>
        public double AnimationDuration
        {
            get => (double)GetValue(AnimationDurationProperty);
            set => SetValue(AnimationDurationProperty, value);
        }

        /// <summary>
        /// The animatable element (used for show/hide animations).
        /// </summary>
        public UIElement AnimatableElement
        {
            get => this;
        }

        /// <summary>
        /// The overlay content property.
        /// </summary>
        public static readonly DependencyProperty OverlayContentProperty =
            DependencyProperty.Register("OverlayContent", typeof(object), typeof(NotificationMessage), new PropertyMetadata(null));

        /// <summary>
        /// The accent brush property.
        /// </summary>
        public static readonly DependencyProperty AccentBrushProperty =
            DependencyProperty.Register("AccentBrush", typeof(Brush), typeof(NotificationMessage), new PropertyMetadata(null, AccentBrushPropertyChangedCallback));

        /// <summary>
        /// Accents the brush property changed callback.
        /// </summary>
        /// <param name="dependencyObject">The dependency object.</param>
        /// <param name="dependencyPropertyChangedEventArgs">The <see cref="DependencyPropertyChangedEventArgs" /> instance containing the event data.</param>
        private static void AccentBrushPropertyChangedCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
        {
            var @this = dependencyObject as NotificationMessage;
            if (@this == null)
                throw new NullReferenceException("Dependency object is not of valid type " + nameof(NotificationMessage));

            if (@this.BadgeAccentBrush == null)
            {
                @this.BadgeAccentBrush = dependencyPropertyChangedEventArgs.NewValue as Brush;
            }

            if (@this.ButtonAccentBrush == null)
            {
                @this.ButtonAccentBrush = dependencyPropertyChangedEventArgs.NewValue as Brush;
            }
        }

        /// <summary>
        /// The button accent brush property.
        /// </summary>
        public static readonly DependencyProperty ButtonAccentBrushProperty =
            DependencyProperty.Register("ButtonAccentBrush", typeof(Brush), typeof(NotificationMessage), new PropertyMetadata(null));

        /// <summary>
        /// The badge visibility property.
        /// </summary>
        public static readonly DependencyProperty BadgeVisibilityProperty =
            DependencyProperty.Register("BadgeVisibility", typeof(Visibility), typeof(NotificationMessage), new PropertyMetadata(Visibility.Collapsed));

        /// <summary>
        /// The badge accent brush property.
        /// </summary>
        public static readonly DependencyProperty BadgeAccentBrushProperty =
            DependencyProperty.Register("BadgeAccentBrush", typeof(Brush), typeof(NotificationMessage), new PropertyMetadata(null));

        /// <summary>
        /// The badge text property.
        /// </summary>
        public static readonly DependencyProperty BadgeTextProperty =
            DependencyProperty.Register("BadgeText", typeof(string), typeof(NotificationMessage), new PropertyMetadata(null, BadgeTextPropertyChangedCallback));

        /// <summary>
        /// Badges the text property changed callback.
        /// </summary>
        /// <param name="dependencyObject">The dependency object.</param>
        /// <param name="dependencyPropertyChangedEventArgs">The <see cref="DependencyPropertyChangedEventArgs" /> instance containing the event data.</param>
        private static void BadgeTextPropertyChangedCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
        {
            var @this = dependencyObject as NotificationMessage;
            if (@this == null)
                throw new NullReferenceException("Dependency object is not of valid type " + nameof(NotificationMessage));

            @this.BadgeVisibility = dependencyPropertyChangedEventArgs.NewValue == null
                ? Visibility.Collapsed
                : Visibility.Visible;
        }

        /// <summary>
        /// The header visibility property.
        /// </summary>
        public static readonly DependencyProperty HeaderVisibilityProperty =
            DependencyProperty.Register("HeaderVisibility", typeof(Visibility), typeof(NotificationMessage), new PropertyMetadata(Visibility.Collapsed));

        /// <summary>
        /// The header property.
        /// </summary>
        public static readonly DependencyProperty HeaderProperty =
            DependencyProperty.Register("Header", typeof(string), typeof(NotificationMessage), new PropertyMetadata(null, HeaderPropertyChangesCallback));

        /// <summary>
        /// Headers the property changes callback.
        /// </summary>
        /// <param name="dependencyObject">The dependency object.</param>
        /// <param name="dependencyPropertyChangedEventArgs">The <see cref="DependencyPropertyChangedEventArgs" /> instance containing the event data.</param>
        private static void HeaderPropertyChangesCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
        {
            var @this = dependencyObject as NotificationMessage;
            if (@this == null)
                throw new NullReferenceException("Dependency object is not of valid type " + nameof(NotificationMessage));

            @this.HeaderVisibility = dependencyPropertyChangedEventArgs.NewValue == null
                ? Visibility.Collapsed
                : Visibility.Visible;
        }

        /// <summary>
        /// The message visibility property.
        /// </summary>
        public static readonly DependencyProperty MessageVisibilityProperty =
            DependencyProperty.Register("MessageVisibility", typeof(Visibility), typeof(NotificationMessage), new PropertyMetadata(Visibility.Collapsed));

        /// <summary>
        /// The message property.
        /// </summary>
        public static readonly DependencyProperty MessageProperty =
            DependencyProperty.Register("Message", typeof(string), typeof(NotificationMessage), new PropertyMetadata(null, MessagePropertyChangesCallback));

        /// <summary>
        /// Messages the property changes callback.
        /// </summary>
        /// <param name="dependencyObject">The dependency object.</param>
        /// <param name="dependencyPropertyChangedEventArgs">The <see cref="DependencyPropertyChangedEventArgs" /> instance containing the event data.</param>
        private static void MessagePropertyChangesCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
        {
            var @this = dependencyObject as NotificationMessage;
            if (@this == null)
                throw new NullReferenceException("Dependency object is not of valid type " + nameof(NotificationMessage));

            @this.MessageVisibility = dependencyPropertyChangedEventArgs.NewValue == null
                ? Visibility.Collapsed
                : Visibility.Visible;
        }

        /// <summary>
        /// The buttons property.
        /// </summary>
        public static readonly DependencyProperty ButtonsProperty =
            DependencyProperty.Register("Buttons", typeof(ObservableCollection<object>), typeof(NotificationMessage), new PropertyMetadata(null));

        /// <summary>
        /// The animates property.
        /// </summary>
        public static readonly DependencyProperty AnimatesProperty =
            DependencyProperty.Register("Animates", typeof(bool), typeof(NotificationMessage), new PropertyMetadata(false));

        /// <summary>
        /// The animation duration property (in seconds).
        /// </summary>
        public static readonly DependencyProperty AnimationDurationProperty =
            DependencyProperty.Register("AnimationDuration", typeof(double), typeof(NotificationMessage), new PropertyMetadata(0.25));


        /// <summary>
        /// Initializes the <see cref="NotificationMessage" /> class.
        /// </summary>
        static NotificationMessage()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(NotificationMessage), new FrameworkPropertyMetadata(typeof(NotificationMessage)));
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="NotificationMessage" /> class.
        /// </summary>
        public NotificationMessage()
        {
            this.Buttons = new ObservableCollection<object>();

            //Setting the default text color, if not defined by user.
            this.Foreground = new BrushConverter().ConvertFromString("#DDDDDD") as Brush;
        }
    }
}
