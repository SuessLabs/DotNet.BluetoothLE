# Cross-Platform Bluetooth LE Plugin

> WARNING: Work in progress!

Cross.BluetoothLE is a cross-platform plugin for accessing Bluetooth LE in your Android, Linux, Mac, Windows (UWP, .NET Core) applications. This allows developers to maintain the same base code which can be deployed across multiple platforms.

As developers, some of us want bare-bones, down to the metal code without the need of boiler-plate stuff that doesn't align with our architectures. That is the goal of Cross.BluetoothLE.

## Support

| Platform | Version | Status |
|-|-|-|
| Android | 4.3 | TBA
| Linux   | Ubuntu 20.04, RPi 4 | TBA
| UWP     | 1709 - 10.0.16299    | TBA
| iOS     |     | TBA
| Mac     | 10.9 (Maverics) | TBA
| Tizen   |  | TBA

## Setup

### Android

```xml
<uses-permission android:name="android.permission.ACCESS_COARSE_LOCATION" />
<uses-permission android:name="android.permission.ACCESS_FINE_LOCATION" />
<uses-permission android:name="android.permission.BLUETOOTH"/>
<uses-permission android:name="android.permission.BLUETOOTH_ADMIN"/>
```

### Linux

### Windows

### iOS

## Usage

## References

* [Plugin.Ble](https://github.com/xabre/xamarin-bluetooth-le)
* [Shiny](https://github.com/shinyorg/shiny)
  * [ACR BluetoothLE](https://github.com/aritchie/bluetoothle) - _(Archived: 2020)_

Invalid References:

* [ble.net](https://github.com/nexussays/ble.net) - _(Last update: Aug, 2019)_
  * Does not appear to provide full functionality
