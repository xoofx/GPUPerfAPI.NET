// Copyright (c) Alexandre Mutel. All rights reserved.
// Licensed under the BSD-Clause 2 license.
// See license.txt file in the project root for full license information.

namespace GPUPerfAPI;

public static partial class GPUPerfAPI
{
    /// <summary>
    /// The AMD GPA extension name.
    /// </summary>
    public static ReadOnlySpan<byte> VK_AMD_GPA_INTERFACE_EXTENSION_NAME => "VK_AMD_gpa_interface"u8;

    /// <summary>
    /// Define the AMD shader core properties extension name.
    /// </summary>
    public static ReadOnlySpan<byte> VK_AMD_SHADER_CORE_PROPERTIES_EXTENSION_NAME => "VK_AMD_shader_core_properties"u8;

    /// <summary>
    /// Define the AMD shader core properties 2 extension name.
    /// </summary>
    public static ReadOnlySpan<byte> VK_AMD_SHADER_CORE_PROPERTIES_EXTENSION_NAME2 => "VK_AMD_shader_core_properties2"u8;
    
    private static ReadOnlySpan<byte> VK_KHR_GET_PHYSICAL_DEVICE_PROPERTIES_2_EXTENSION_NAME => "VK_KHR_get_physical_device_properties2"u8;
    
    /// <summary>
    /// Gets the number of instance-level extensions required to support the AMD GPA Interface.
    /// </summary>
    /// <returns>The number of instance-level extensions required to support the AMD GPA Interface.</returns>
    public static int AMD_GPA_REQUIRED_INSTANCE_EXTENSION_NAME_LIST_Count => 1;

    /// <summary>
    /// Gets the instance-level extensions required to support the AMD GPA Interface.
    /// </summary>
    /// <param name="index">The index of the extension.</param>
    /// <param name="value">The extension name.</param>
    /// <exception cref="IndexOutOfRangeException"></exception>
    public static void Get_AMD_GPA_REQUIRED_INSTANCE_EXTENSION_NAME_LIST(int index, out ReadOnlySpan<byte> value)
    {
        switch (index)
        {
            case 0:
                value = VK_KHR_GET_PHYSICAL_DEVICE_PROPERTIES_2_EXTENSION_NAME;
                break;
            default:
                throw new IndexOutOfRangeException($"{index} must be == 0");
        }
    }

    /// <summary>
    /// Gets the number of device-level extensions required to support the AMD GPA Interface.
    /// </summary>
    /// <returns></returns>
    public static int AMD_GPA_REQUIRED_DEVICE_EXTENSION_NAME_LIST_Count => 2;

    /// <summary>
    /// Gets the device-level extensions required to support the AMD GPA Interface.
    /// </summary>
    /// <param name="index">The index of the extension.</param>
    /// <param name="value">The extension name.</param>
    /// <exception cref="IndexOutOfRangeException"></exception>
    public static void Get_AMD_GPA_REQUIRED_DEVICE_EXTENSION_NAME_LIST(int index, out ReadOnlySpan<byte> value)
    {
        switch (index)
        {
            case 0:
                value = VK_AMD_GPA_INTERFACE_EXTENSION_NAME;
                break;
            case 1:
                value = VK_AMD_SHADER_CORE_PROPERTIES_EXTENSION_NAME;
                break;
            default:
                throw new IndexOutOfRangeException($"{index} must be >= 0 && < 2");
        }
    }

    /// <summary>
    /// Gets the number of optional device-level extensions to support the AMD GPA Interface.
    /// </summary>
    public static int AMD_GPA_OPTIONAL_DEVICE_EXTENSION_NAME_LIST_Count => 1;

    /// <summary>
    /// Gets the optional device-level extensions to support the AMD GPA Interface.
    /// </summary>
    /// <param name="index">The index of the extension.</param>
    /// <param name="value">The extension name.</param>
    /// <exception cref="IndexOutOfRangeException"></exception>
    public static void Get_AMD_GPA_OPTIONAL_DEVICE_EXTENSION_NAME_LIST(int index, out ReadOnlySpan<byte> value)
    {
        switch (index)
        {
            case 0:
                value = VK_AMD_SHADER_CORE_PROPERTIES_EXTENSION_NAME2;
                break;
            default:
                throw new IndexOutOfRangeException($"{index} must be == 0");
        }
    }

    /// <summary>
    /// The struct that should be supplied to GpaOpenContext().
    /// </summary>
    public struct GpaVkContextOpenInfoType
    {
        /// <summary>
        /// The instance on which to profile. (VkInstance)
        /// </summary>
        public nint instance;

        /// <summary>
        /// The physical device on which to profile. (VkPhysicalDevice)
        /// </summary>
        public nint physical_device;

        /// <summary>
        /// The device on which to profile. (VkDevice)
        /// </summary>
        public nint device;

    }
}
