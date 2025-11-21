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
- MvvmCross framework for MVVM pattern implementation
- BaseViewModel for consistent ViewModel structure across platforms

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

## Architecture

### MVVM Pattern
This project uses **MvvmCross 9.1.1** for implementing the MVVM (Model-View-ViewModel) pattern:

- **ViewModels**: Located in `DotNetMobileApp.Core/ViewModels/`
  - `BaseViewModel`: Abstract base class that all ViewModels inherit from
  - `MainViewModel`: Example implementation demonstrating property binding and commands
- **Models**: Business logic and data models in the Core project
- **Views**: Platform-specific UI implementations in iOS and Android projects

### Core Project
Contains all shared logic, ViewModels, and business models that are referenced by both iOS and Android projects.

### Platform-Specific Implementation
Each platform (iOS and Android) has its own `Setup.cs` that initializes MvvmCross for that specific platform.

## Development

This project uses native SDKs rather than MAUI, providing direct access to platform-specific APIs and optimized performance for each platform.

### iOS
- Entry point: `Main.cs`
- Lifecycle: `AppDelegate.cs`
- UI: `ViewController.cs`
- Resources: `Info.plist`
- Setup: `Setup.cs` (MvvmCross initialization)

### Android
- Entry point: `MainActivity.cs`
- Manifest: `AndroidManifest.xml`
- Resources: XML layouts and string definitions
- Setup: `Setup.cs` (MvvmCross initialization)

## ViewModels

### BaseViewModel
All ViewModels should inherit from `BaseViewModel` which provides:
- `Title` property for view title binding
- `IsLoading` property for loading state management
- `InitializeAsync()` method for async initialization
- Built-in property change notification via `SetProperty()`

### Creating a New ViewModel
```csharp
public class MyViewModel : BaseViewModel
{
    private string _myProperty = string.Empty;

    public string MyProperty
    {
        get => _myProperty;
        set => SetProperty(ref _myProperty, value);
    }

    public IMvxCommand MyCommand { get; }

    public MyViewModel()
    {
        Title = "My View";
        MyCommand = new MvxCommand(ExecuteMyCommand);
    }

    private void ExecuteMyCommand()
    {
        // Command implementation
    }
}
```

## Dependencies

- **MvvmCross 9.1.1**: MVVM framework for cross-platform development
- **Microsoft.iOS**: Native iOS framework
- **Microsoft.Android**: Native Android framework
