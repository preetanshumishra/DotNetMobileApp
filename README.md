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

### MVVM Pattern with Dependency Injection
This project uses **MvvmCross 9.1.1** for implementing the MVVM (Model-View-ViewModel) pattern with a sophisticated IoC (Inversion of Control) container:

#### Core Components
- **ViewModels**: Located in `DotNetMobileApp.Core/ViewModels/`
  - `BaseViewModel`: Abstract base class that all ViewModels inherit from
  - `MainViewModel`: Example implementation demonstrating dependency injection, property binding, and commands

- **Services**: Located in `DotNetMobileApp.Core/Services/`
  - **Contracts**: Interface definitions
    - `ILoggerService`: Logging interface for debug output
    - `IAnalyticsService`: Analytics tracking interface for event monitoring
    - `IAppNavigationService`: Navigation interface for cross-view-model navigation
  - **Implementations**: Concrete service implementations
    - `LoggerService`: Debug output logging with multiple log levels
    - `AnalyticsService`: Event tracking with properties and exception reporting
  - Extensible architecture for adding more services

- **Repositories**: Located in `DotNetMobileApp.Core/Repositories/`
  - `IBaseRepository<T>`: Generic repository interface for data access patterns
  - Easily extensible for domain-specific repositories

#### App Initialization (App.cs)
The `App.cs` class handles complex initialization in multiple stages:
1. **RegisterCoreServices()**: Registers essential services with proper dependency ordering
   - Logger service is registered first (other services depend on it)
   - Analytics service depends on logger service
2. **RegisterAutoServices()**: Auto-discovers and registers remaining services and repositories
3. **RegisterViewModels()**: Prepares ViewModels with logging
4. **App Start**: Sets MainViewModel as the entry point

#### Dependency Injection
All services and repositories are automatically injected into ViewModels via the MvvmCross IoC container:
```csharp
public MainViewModel(ILoggerService loggerService, IAnalyticsService analyticsService)
{
    // Services are automatically resolved and injected
}
```

### Core Project
Contains all shared logic, ViewModels, Services, Repositories, and business models that are referenced by both iOS and Android projects.

### Platform-Specific Implementation
Each platform (iOS and Android) has its own `Setup.cs` that:
- Inherits from platform-specific MvxSetup<App>
- Configures platform-specific logging providers
- Initializes platform-specific services

## Development

This project uses native SDKs rather than MAUI, providing direct access to platform-specific APIs and optimized performance for each platform.

### iOS
- Entry point: `Main.cs`
- Lifecycle: `AppDelegate.cs`
- UI: `MainViewController.cs`
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
