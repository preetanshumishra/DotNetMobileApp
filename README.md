# DotNetMobileApp

A production-ready native mobile application for iOS and Android built with .NET, featuring native platform implementations with shared business logic.

## Overview

This project demonstrates a professional .NET approach to native mobile development:
- **Native iOS** - UIKit implementation with platform-specific APIs
- **Native Android** - Android Framework with native UI patterns
- **Shared Core** - Common business logic and services in .NET Core
- **MvvmCross** - Enterprise MVVM framework for cross-platform coordination
- **Platform-Specific Services** - Analytics, logging, and navigation services

## Tech Stack

- .NET 8.0
- MvvmCross 9.1.1
- iOS: UIKit, native Swift interop
- Android: Android Framework, Java interop
- Shared: Core business logic and services

## Project Structure

```
DotNetMobileApp.Core/      # Shared business logic and ViewModels
DotNetMobileApp.iOS/       # Native iOS UI (UIKit)
DotNetMobileApp.Android/   # Native Android UI (Android Framework)
```

## Quick Start

```bash
# Build iOS
dotnet build -f net8.0-ios

# Build Android
dotnet build -f net8.0-android

# Run on simulator/emulator
dotnet run -f net8.0-ios
```

## Key Features

- Native platform UI implementations
- Shared view model and service layer
- MvvmCross navigation framework
- Cross-platform analytics and logging
- Platform-specific dependency injection
- Separation of concerns between platforms

## License

MIT License - See LICENSE file for details.
