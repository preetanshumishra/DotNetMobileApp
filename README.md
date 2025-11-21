# DotNetMobileApp

A native .NET mobile application for iOS and Android platforms using .NET 8.0 without MAUI. This project demonstrates native development using Microsoft.iOS and Microsoft.Android SDKs.

## Project Structure

- **DotNetMobileApp.Core**: Shared core library containing common business logic and models
- **DotNetMobileApp.iOS**: Native iOS application targeting iOS 14.0+
- **DotNetMobileApp.Android**: Native Android application targeting Android 21+ (API 21)

## Features

- Native iOS development using UIKit
- Native Android development using Android Framework
- Shared code library for cross-platform logic
- Proper dependency management and project references

## Requirements

- .NET 8.0 SDK
- iOS Workload for .NET (`dotnet workload install ios`)
- Android Workload for .NET (`dotnet workload install android`)
- macOS (for iOS development)
- Xcode and Android SDK installed

## Building

```bash
# Build the entire solution
dotnet build DotNetMobileApp.sln

# Build Core project only
dotnet build DotNetMobileApp.Core/DotNetMobileApp.Core.csproj

# Build iOS project
dotnet build DotNetMobileApp.iOS/DotNetMobileApp.iOS.csproj

# Build Android project
dotnet build DotNetMobileApp.Android/DotNetMobileApp.Android.csproj
```

## App Identifier

- **Package/Bundle ID**: `com.preetanshumishra.dotnetmobileapp`

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Development

This project uses native SDKs rather than MAUI, providing direct access to platform-specific APIs and optimized performance for each platform.

### iOS
- Entry point: `Main.cs`
- Lifecycle: `AppDelegate.cs`
- UI: `ViewController.cs`
- Resources: `Info.plist`

### Android
- Entry point: `MainActivity.cs`
- Manifest: `AndroidManifest.xml`
- Resources: XML layouts and string definitions
