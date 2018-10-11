# Changelog
All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](http://keepachangelog.com/en/1.0.0/)
and this project adheres to [Semantic Versioning](http://semver.org/spec/v2.0.0.html).

## [1.4.1] - 2018-10-11
### Fixed
- Fixed problem where message with animation would trigger dismiss event before disapearing 

## [1.4.0] - 2018-06-09
### Added
- Added `WithAdditionalContent` feature

### Changed
- `NotificationHeaderTextStyle` and `NotificationMessageTextStyle` are now aligned left horizontally (instead of stretched)

### Fixed
- `INotificationAnimation` interface is now marked as public

## [1.3.1] - 2018-05-30
### Fixed
- Fixed message header foreground not set by `SetForeground` method call.

## [1.3.0] - 2018-05-03
### Added
- Added notification fade-out and fade-in animations.

## [1.2.0] - 2018-04-30
### Added
- Implemented support for setting custom text color with `Foreground` method.

## [1.1.0] - 2018-04-03
### Added
- Support for delayed dismiss `WithDelay` extension method for LINQ builder.

## [1.0.0] - 2017-03-08
### Added
- Initial release.
