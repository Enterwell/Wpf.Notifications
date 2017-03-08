# Enterwell Client WPF - Notifications
_WPF notifications UI controls_

## Features
- Flexible styling 
- MVVM friendly
- LINQ like syntax

### Basics

Control `NotificationMessage` is the notification. There are 3 main part to it - a badge, located on the most left, a message in center and buttons on the right for user interaction.

The custom button control that is used with notification messages is `NotificaitonMessageButton`. 

You can instantiate these control by yourself or use `NotificationMessageFactory` that will do the instantiation for you.

This factory is used by notification message manager. The `NotificationMessageManager` is responsible for queueing and dismissing multiple notification.

The control that provides support for multiple notification is `NotificationMessageContainer`. You can place this control in your main window, assign the manager and it will handle all notification queue/dismiss operations for you. 

## Basic usage

In your window XAML, place the `NotificationMessageContainer` control. You can bind the manager to your view model and obtain the manager via DI or some other mechanism; or you can just assign the manager instance from the backend.

```c#
this.Manager = new NotificationMessageManager();
```

```xml
<controls:NotificationMessageContainer Manager="{Binding Manager}" />
```

### Simple "info" notification

![Info notification message](docs/images/CaptureNotificationMessageInfo.PNG)

```c#
manager.CreateMessage()
       .Accent("#1751C3")
       .Background("#333")
       .HasBadge("Info")
       .HasMessage("Update will be installed on next application restart.")
       .Dismiss().WithButton("Update now", button => { })
       .Dismiss().WithButton("Release notes", button => { })
       .Dismiss().WithButton("Later", button => { })
       .Queue(); 
```

`CreateMessage` on manager creates an empty notification message. We then set the accent and background brushes. `HasBadge` and `HasMessage` will populate the notification badge and message content.

`WithButton` will create an button with specified content (content doesn't have to be string) and specified action callback when clicked. If you place `Dismiss` before `WithButton`, your button callback will be intercepted by dismiss notification action first - the notification will be dismissed on user input.

`Queue` will enqueue the message. This will propagate the message to notification message container control which will then show the message (when multiple messages are displayed, new messages are queued to bottom of the stack)

### Simple "warning" notification

![Warning notification message](docs/images/CaptureNotificationMessageWarning.PNG)

```c#
manager.CreateMessage()
       .Accent("#E0A030")
       .Background("#333")
       .HasBadge("Warn")
       .HasMessage("Failed to retrieve data.")
       .WithButton("Try again", button => { })
       .Dismiss().WithButton("Ignore", button => { })
       .Queue();
```

## Advanced usage

### Custom control overlay notification

![Error notificaiton message with progress bar overlay](docs/images/CaptureNotificationMessageError.PNG)

```c#
manager.CreateMessage()
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
```

The `WithOverlay` allows you to set custom overlay content. In this example progress bar is placed on the bottom of notification control. Notice the `IsHitTextVisible` is set to `false` so that notification message buttons don't lose focus due to overlay control being over the bottom part of the buttons.

### Multiple notification

The `NotificaitonMessageContainer` has build-in support for showing multiple notificaitons at the same time. New notificaiton show at the bottom of the message stack.

![Multiple notificaitons example](docs/images/CaptureNotificationMessageMultiple.PNG)

### Don't like extension methods?

Extension methods don't hold any complex logic for instantiating notificaitons so you can still build the notification message using just `NotificationMessageBuilder` class directly, without extension methods.

```c#
var builder = NotificationMessageBuilder.CreateMessage();
builder.Manager = this.Manager;
builder.Message = this.Manager.Factory.GetMessage();
builder.SetAccent(Brushes.DodgerBlue);
builder.SetBackground(Brushes.DimGray);
builder.SetBadge("Info");
builder.HasMessage("This notification is built without extension methods.");

var notificationButton = this.Manager.Factory.GetButton();
notificationButton.Content = "This is much longer";
notificationButton.Callback = (button) =>
{
    this.Manager.Dismiss(builder.Message);
    // ... Do the rest
};

builder.AddButton(notificationButton);
builder.Manager.Queue(builder.Message);
```     

### Don't like the builder?

Standard control instantiation is supported too. 

```c#
this.Manager.Queue(new NotificationMessage
{
    Message = "Works event without message builder",
    BadgeText = "Info",
    AccentBrush = Brushes.Orange,
    Background = Brushes.Black,
    Buttons = new ObservableCollection<object>
    {
        new NotificationMessageButton()
        {
            Content = "Great!",
            Callback = button => { }
        }
    }
});
```

### XAML only? Supported too. You get the idea.
