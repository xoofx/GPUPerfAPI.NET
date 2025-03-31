// Copyright (c) Alexandre Mutel. All rights reserved.
// Licensed under the BSD-Clause 2 license.
// See license.txt file in the project root for full license information.

using System.Runtime.InteropServices;

namespace GPUPerfAPI;

public static partial class GPUPerfAPI
{
    /// <summary>
    /// Supported backends for GPUPerfAPI. Must be set of GPUPerfAPI.GPUPerfAPIBackend
    /// </summary>
    public enum GPUPerfAPIBackendKind
    {
        /// <summary>
        /// Vulkan backend.
        /// </summary>
        Vulkan = 0,

        /// <summary>
        /// DirectX 11 backend.
        /// </summary>
        DirectX11 = 1,

        /// <summary>
        /// DirectX 12 backend.
        /// </summary>
        DirectX12 = 2,

        /// <summary>
        /// OpenGL backend.
        /// </summary>
        OpenGL = 3,
    }

    /// <summary>
    /// Gets or sets the default backend to use for GPUPerfAPI (when directly calling GPUPerfAPI methods).
    /// </summary>
    public static GPUPerfAPIBackendKind GPUPerfAPIBackend { get; set; } = GPUPerfAPIBackendKind.Vulkan;
}
