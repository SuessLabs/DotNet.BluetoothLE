# .NET Cross-Platform Bluetooth LE Plugin

> STATUS: This project is in the Beta-2 phase.

DotNet.BluetoothLE is a cross-platform plugin for accessing Bluetooth LE in your Android, Linux, Mac, Windows (UWP, .NET Core) applications. This allows developers to maintain the same base code which can be deployed across multiple platforms.

As developers, some of us want bare-bones, down to the metal code without the need of boiler-plate stuff that doesn't align with our architectures. That is the goal of DotNet.BluetoothLE.

## Support

| Platform | Version | Status |
|-|-|-|
| Android | 10.0            | _Beta_
| UWP     | 19041           | _Beta_
| iOS     |                 | _Beta_
| Mac     | 10.9 (Maverics) | _Beta_
| Linux   |                 | TBA
| Tizen   |                 | TBA

## Setup

### Android

```xml
<uses-permission android:name="android.permission.ACCESS_COARSE_LOCATION" />
<uses-permission android:name="android.permission.ACCESS_FINE_LOCATION" />
<uses-permission android:name="android.permission.BLUETOOTH"/>
<uses-permission android:name="android.permission.BLUETOOTH_ADMIN"/>
```

Android 12 and above

```xml
<uses-permission android:name="android.permission.BLUETOOTH_SCAN" />
<uses-permission android:name="android.permission.BLUETOOTH_CONNECT" />
<uses-permission android:name="android.permission.BLUETOOTH_ADVERTISE" />
```

### Windows

Set in your `.appxmanifest` file

```xml
<DeviceCapability Name="bluetooth" />
```

### iOS

```xml
<key>UIBackgroundModes</key>
<array>
    <!-- for connecting to devices (client) -->
    <string>bluetooth-central</string>

    <!-- for server configurations if needed -->
    <string>bluetooth-peripheral</string>
</array>

<!-- Description of the Bluetooth request message (required on iOS 10, deprecated) -->
<key>NSBluetoothPeripheralUsageDescription</key>
<string>YOUR CUSTOM MESSAGE</string>

<!-- Description of the Bluetooth request message (required on iOS 13) -->
<key>NSBluetoothAlwaysUsageDescription</key>
<string>YOUR CUSTOM MESSAGE</string>
```

### Linux

_Coming soon._
