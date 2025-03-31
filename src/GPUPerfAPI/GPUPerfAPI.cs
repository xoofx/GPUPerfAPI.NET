// Copyright (c) Alexandre Mutel. All rights reserved.
// Licensed under the BSD-Clause 2 license.
// See license.txt file in the project root for full license information.

using System.Runtime.InteropServices;

namespace GPUPerfAPI;

public static partial class GPUPerfAPI
{
    private const string LibraryName = "GPUPerfAPI";
    private const DllImportSearchPath DefaultDllImportSearchPath = DllImportSearchPath.ApplicationDirectory | DllImportSearchPath.UserDirectories | DllImportSearchPath.UseDllDirectoryForDependencies;

    /// <summary>
    /// Set the resolver for the vulkan native library. 
    /// </summary>
    static GPUPerfAPI()
    {
        NativeLibrary.SetDllImportResolver(typeof(GPUPerfAPI).Assembly, (libraryName, methodName, searchPath) =>
        {
            if (libraryName == LibraryName)
            {
                var ptr = IntPtr.Zero;
                var resolver = GPUPerfAPIDllImporterResolver;
                if (resolver != null)
                {
                    ptr = resolver(libraryName, methodName, searchPath);
                }

                if (ptr != IntPtr.Zero)
                {
                    return ptr;
                }

                var platformLibraryName = GetLibraryNameFromBackendKind(GPUPerfAPIBackend);
                if (platformLibraryName != null)
                {
                    if (NativeLibrary.TryLoad(platformLibraryName, typeof(GPUPerfAPI).Assembly, DefaultDllImportSearchPath, out ptr))
                    {
                        return ptr;
                    }
                }
            }
            return IntPtr.Zero;
        });
    }

    /// <summary>
    /// Gets the <see cref="GpaFunctionTable"/> from the specified library handle (loaded from a library via <see cref="NativeLibrary.Load(string)"/> and <see cref="GetLibraryNameFromBackendKind"/>)
    /// </summary>
    /// <param name="libraryHandle">The library handle.</param>
    /// <param name="gpaFunctionTable">Output function table</param>
    /// <returns>The status return. If `GpaGetFuncTable` was not found, this function will return <see cref="GpaStatus.kGpaStatusErrorLibLoadFailed"/>.</returns>
    public static unsafe GpaStatus GetGpaFunctionTableFromNativeLibrary(nint libraryHandle, ref GpaFunctionTable gpaFunctionTable)
    {
        if (NativeLibrary.TryGetExport(libraryHandle, nameof(GpaGetFuncTable), out var ptr))
        {
            var gpaGetFuncTable = (delegate* unmanaged[Cdecl]<void*, GPUPerfAPI.GpaStatus>)ptr;
            fixed (GpaFunctionTable* gpaFunctionTablePtr = &gpaFunctionTable)
            {
                var status = gpaGetFuncTable(gpaFunctionTablePtr);
                return status;
            }
        }

        gpaFunctionTable = default;
        return GpaStatus.kGpaStatusErrorLibLoadFailed;
    }
    
    /// <summary>
    /// Gets or sets the default backend to use for GPUPerfAPI (when directly calling GPUPerfAPI methods).
    /// </summary>
    /// <param name="kind">The backend kind.</param>
    /// <returns>The name of the library or null if it is not supported for the current operating system.</returns>
    public static string? GetLibraryNameFromBackendKind(GPUPerfAPIBackendKind kind)
    {
        return kind switch
        {
            GPUPerfAPIBackendKind.Vulkan => OperatingSystem.IsWindows() ? "GPUPerfAPIVK-x64.dll" : OperatingSystem.IsLinux() ? "libGPUPerfAPIVK.so" : null,
            GPUPerfAPIBackendKind.DirectX11 => OperatingSystem.IsWindows() ? "GPUPerfAPIDX12-x64.dll" : null,
            GPUPerfAPIBackendKind.DirectX12 => OperatingSystem.IsWindows() ? "GPUPerfAPIDX11-x64.dll" : null,
            GPUPerfAPIBackendKind.OpenGL => OperatingSystem.IsWindows() ? "GPUPerfAPIGL-x64.dll" : OperatingSystem.IsLinux() ? "libGPUPerfAPIGL.so" : null,
            _ => null
        };
    }

    public static System.Runtime.InteropServices.DllImportResolver? GPUPerfAPIDllImporterResolver { get; set; }
}
