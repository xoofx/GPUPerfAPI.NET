# GPUPerfAPI User Guide

This document is a quick start guide to get you started with GPUPerfAPI.NET.

The library is a simple wrapper around the native GPUPerfAPI library. C function are mapped to C# methods. The library is designed to be used in a similar way as the native library.

For a complete manual of the API, please visit the [official documentation](https://gpuopen.com/manuals/gpu_performance_api_manual/gpu_performance_api_manual-index/)

## Installation

This library does not ship the binaries required to access AMD GPU counters. You need to download the binaries from [here](https://github.com/GPUOpen-Tools/gpu_performance_api/releases/tag/v4.0-tag).

In the `bin` folder you will find the following binaries - depending on the Windows or Linux version.

| API | Library Name |
| --- | --- |
| `Vulkan` | 64-bit Windows: `GPUPerfAPIVK-x64.dll`<br>64-bit Linux: `libGPUPerfAPIVK.so`
| `DirectX 12` | 64-bit Windows: `GPUPerfAPIDX12-x64.dll`
| `DirectX 11` | 64-bit Windows: `GPUPerfAPIDX11-x64.dll`
| `OpenGL` | 64-bit Windows: `GPUPerfAPIGL-x64.dll`<br>64-bit Linux: `libGPUPerfAPIGL.so`

Refer to the official documentation for more details.

## Using the library

By default, GPUPerfAPI.NET binds to `Vulkan` library. You can change the library by setting the backend:

```csharp
// Notice that the API is accessible through the static class `GPUPerfAPI.GPUPerfAPI`
using static GPUPerfAPI.GPUPerfAPI;

// Load the backend DirectX12 (the `GPUPerfAPIDX12-x64.dll`)
GPUPerfAPIBackend = GPUPerfAPIBackend.DirectX12;

// Load the library (implicitly on first usage)
GpaGetVersion(out var majorVersion, 
              out var minorVersion, 
              out var buildVersion, 
              out var updateVersion);
``` 

You can also use the `GpaFunctionTable` to load the library and functions dynamically:

```csharp
using static GPUPerfAPI.GPUPerfAPI;

var libraryHandle = NativeLibrary.Load(GetLibraryNameFromBackendKind(GPUPerfAPIBackend.Vulkan));

// Get the function table (to test it)
// This is important to initialize the structure for the major/minor version
GpaFunctionTable gpaFunctionTable = new();
GetGpaFunctionTableFromNativeLibrary(libraryHandle, ref gpaFunctionTable)

// Get the version from the GpaFunctionTable
gpaFunctionTable.GpaGetVersion(out var majorVersion, 
                               out var minorVersion, 
                               out var buildVersion, 
                               out var updateVersion);
```

## Helpers

The library provides a helper to check the returned `GpaStatus` when calling functions via `GpaCheck` extension method. This extension method will throw a `GPUPerfAPIException` if the status is not `GpaStatus.Ok`.

```csharp
using static GPUPerfAPI.GPUPerfAPI;

// Load the library (implicitly on first usage)
GpaGetVersion(out var majorVersion, 
              out var minorVersion, 
              out var buildVersion, 
              out var updateVersion).GpaCheck("Unable to get version");
```

