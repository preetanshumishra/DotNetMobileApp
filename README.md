# DotNetMobileApp

A production-ready native mobile application demonstrating professional .NET mobile development. This project shows how to build high-performance native iOS and Android apps while sharing business logic across platforms using .NET and MvvmCross.

## Overview

DotNetMobileApp demonstrates **enterprise-grade native mobile development** with .NET:
- **Native iOS UI** - UIKit with platform-specific implementations
- **Native Android UI** - Android Framework with native patterns
- **Shared Core Logic** - Common business logic and services
- **MvvmCross MVVM** - Enterprise MVVM framework
- **Platform-Specific Services** - Logging, Analytics, Navigation
- **Performance-Optimized** - Native platform capabilities

## Project Structure

```
DotNetMobileApp/
├── DotNetMobileApp.Core/               # Shared business logic
│   ├── App.cs                          # App initialization & IoC setup
│   ├── ViewModels/
│   │   ├── BaseViewModel.cs            # Base with IsBusy, Title
│   │   └── MainViewModel.cs            # Main screen logic
│   ├── Services/
│   │   ├── Contracts/
│   │   │   ├── ILoggerService.cs       # Logging interface
│   │   │   ├── IAnalyticsService.cs    # Analytics interface
│   │   │   └── IAppNavigationService.cs# Navigation interface
│   │   └── Implementations/
│   │       ├── LoggerService.cs        # Console logging
│   │       └── AnalyticsService.cs     # Event tracking
│   ├── Models/
│   │   └── [Domain models]
│   └── Repositories/
│       └── IBaseRepository<T>          # Generic CRUD interface
│
├── DotNetMobileApp.iOS/                # Native iOS UI (UIKit)
│   ├── AppDelegate.cs                  # iOS app lifecycle
│   ├── MainViewController.cs           # Main screen UI (UIKit)
│   ├── Setup.cs                        # iOS-specific MvvmCross setup
│   └── Resources/
│
├── DotNetMobileApp.Android/            # Native Android UI
│   ├── MainActivity.cs                 # Main activity
│   ├── MainApplication.cs              # App lifecycle
│   ├── Setup.cs                        # Android-specific setup
│   ├── Resources/
│   │   ├── layout/activity_main.xml
│   │   └── values/strings.xml
│   └── AndroidManifest.xml
│
└── DotNetMobileApp.sln                 # Solution file
```

## Tech Stack

| Component | Version | Purpose |
|-----------|---------|---------|
| **.NET** | 8.0 | Runtime framework |
| **MvvmCross** | 9.1.1 | Enterprise MVVM |
| **iOS** | UIKit (native) | Native iOS UI |
| **Android** | Android Framework | Native Android UI |
| **Target Platforms** | iOS 14+, Android API 21+ | Supported |

## Architecture

### Three-Layer Architecture

The project demonstrates **proper separation of concerns**:

**Layer 1: Shared Core** (DotNetMobileApp.Core)
- Business logic (ViewModels, Services, Models)
- Platform-agnostic code
- Interfaces for platform-specific features
- Unit testable components

**Layer 2: Platform-Specific UI** (iOS / Android)
- Native UI implementations (UIKit/Android Framework)
- Platform-specific service implementations
- Platform lifecycle management
- Performance optimizations

**Layer 3: Dependency Injection**
- MvvmCross IoC container
- Service registration per platform
- Automatic ViewModel resolution

### Service Architecture

**Service Interfaces** (defined in Core):
```csharp
public interface ILoggerService
{
    void Log(string message, LogLevel level);
}

public interface IAnalyticsService
{
    void TrackEvent(string eventName, Dictionary<string, string> properties);
    void TrackException(Exception exception);
}
```

**Service Implementations** (in Core, iOS, or Android):
```csharp
public class LoggerService : ILoggerService
{
    public void Log(string message, LogLevel level)
    {
        Debug.WriteLine($"[{level}] {message}");
    }
}
```

### MVVM Pattern

**BaseViewModel**:
- Inherits from `MvxViewModel` (MvvmCross)
- Provides `Title` and `IsLoading` properties
- Base for all ViewModels
- Async initialization support

**MainViewModel**:
- Constructor injection of services
- Observable properties with notifications
- Command handling for user interactions
- Service usage examples

### Navigation Flow

```
App Initialization (App.cs)
  ↓
Register Services (ILoggerService, IAnalyticsService)
  ↓
Register ViewModels (MainViewModel)
  ↓
Platform Setup (iOS/Android Setup.cs)
  ↓
Show Main ViewController/Activity
  ↓
ViewModel & Services Ready
```

## Key Features

- **Shared Business Logic** - Single source of truth for app logic
- **Native Performance** - Leverage platform-specific APIs
- **Platform Separation** - UI code never mixes with business logic
- **Testable Services** - Interface-based service architecture
- **Dependency Injection** - MvvmCross IoC for service resolution
- **Logging Service** - Built-in console logging with levels
- **Analytics Service** - Event tracking and crash reporting
- **Repository Pattern** - Generic CRUD interface for data access
- **Async/Await Support** - Modern async patterns throughout
- **Cross-Platform Consistency** - Shared ViewModels across platforms

## Quick Start

### Prerequisites
- .NET 8.0 SDK
- Xcode 15+ (iOS)
- Android SDK API 21+ (Android)
- Visual Studio 2022 or VS Code

### Build & Run

```bash
# Install dependencies
dotnet restore

# Build Core library
dotnet build DotNetMobileApp.Core

# Build and run iOS
dotnet build -f net8.0-ios
dotnet run -f net8.0-ios

# Build and run Android
dotnet build -f net8.0-android
dotnet run -f net8.0-android

# Publish for production
dotnet publish -f net8.0-ios -c Release
dotnet publish -f net8.0-android -c Release
```

## Service Examples

### Using Logger Service

```csharp
public class MainViewModel : MvxViewModel
{
    private readonly ILoggerService _logger;

    public MainViewModel(ILoggerService logger)
    {
        _logger = logger;
        _logger.Log("MainViewModel initialized", LogLevel.Info);
    }
}
```

### Using Analytics Service

```csharp
[RelayCommand]
private void TrackUserAction()
{
    _analytics.TrackEvent("ButtonClicked", new Dictionary<string, string>
    {
        { "screen", "MainScreen" },
        { "action", "increment" }
    });
}
```

## iOS Implementation (UIKit)

**MainViewController.cs** - Native UIKit UI:
```swift
// Manual UILabel positioning
let label = UILabel()
label.text = "Welcome"
label.textAlignment = .center
label.frame = CGRect(x: 0, y: 100, width: view.bounds.width, height: 50)
view.addSubview(label)
```

**Platform-Specific**:
- Direct UIKit API access
- Native Swift interop
- iOS lifecycle management
- App Store optimization

## Android Implementation

**MainActivity.cs** - Android Framework:
```kotlin
// XML layout inflation
override fun onCreate(savedInstanceState: Bundle?)
{
    setContentView(R.layout.activity_main)
    val textView = findViewById(R.id.welcome_text)
    textView.text = "Welcome"
}
```

**Platform-Specific**:
- Direct Android API access
- Java interop
- Android lifecycle management
- Google Play optimization

## Dependency Injection Setup

**Core Registration** (App.cs):
```csharp
public void RegisterAppStart<TViewModel>() where TViewModel : IMvxViewModel
{
    RegisterCoreServices();
    RegisterAutoServices();
    RegisterViewModels();
}
```

**Platform Registration** (iOS/Android Setup.cs):
```csharp
protected override void RegisterFirstChanceConverter()
{
    // Platform-specific converters
}
```

## Best Practices Demonstrated

1. ✅ Interface-based service architecture (testable)
2. ✅ Dependency injection for all services
3. ✅ Separation of business logic from UI
4. ✅ Platform-agnostic core (90% code sharing)
5. ✅ Native UI for optimal performance
6. ✅ Lazy service initialization
7. ✅ Singleton services for app-wide state
8. ✅ Async/await for operations
9. ✅ Proper error handling
10. ✅ Logging at service level

## Testing Strategy

Services are designed for unit testing:

```csharp
[TestClass]
public class MainViewModelTests
{
    [TestMethod]
    public void MainViewModel_ShouldInitialize()
    {
        var mockLogger = new Mock<ILoggerService>();
        var viewModel = new MainViewModel(mockLogger.Object);
        Assert.IsNotNull(viewModel.Title);
    }
}
```

## Performance Considerations

- Native UI = best performance and platform compliance
- Shared business logic = reduced code duplication
- Service singletons = efficient resource usage
- Lazy initialization = fast startup
- Async operations = responsive UI

## Extending the Project

### Adding a New Service

1. Define interface in Core
2. Implement in each platform or Core
3. Register in Setup.cs
4. Inject in ViewModels

### Adding a New ViewModel

1. Create in Core inheriting from `MvxViewModel`
2. Implement UI in each platform
3. Register in App.cs
4. MvvmCross auto-resolves

## Resources

- [MvvmCross Documentation](https://www.mvvmcross.com/)
- [.NET Mobile Documentation](https://learn.microsoft.com/en-us/dotnet/maui/)
- [UIKit Development](https://developer.apple.com/documentation/uikit)
- [Android Development](https://developer.android.com/)

## License

MIT License - See LICENSE file for details.
