// Copyright (c) Alexandre Mutel. All rights reserved.
// Licensed under the BSD-Clause 2 license.
// See license.txt file in the project root for full license information.

using System.Runtime.InteropServices;

namespace GPUPerfAPI;

public static partial class GPUPerfAPI
{
    /// <summary>
    /// @brief Gets the device name of the GPU associated with the specified context.
    /// </summary>
    /// <param name="gpa_context_id">Unique identifier of the opened context.</param>
    /// <param name="device_name">The value that will be set to the device name upon successful execution.</param>
    /// <returns>@return The GPA result status of the operation.</returns>
    /// <remarks>
    ///  gpa_context_interrogation
    /// </remarks>
    /// <retval>
    /// @retval kGpaStatusOk If the operation is successful.
    /// </retval>
    /// <retval>
    /// @retval kGpaStatusErrorNullPointer If any of the parameters are NULL.
    /// </retval>
    /// <retval>
    /// @retval kGpaStatusErrorContextNotFound If the supplied context is invalid.
    /// </retval>
    /// <retval>
    /// @retval kGpaStatusErrorContextNotOpen If the supplied context has not been opened.
    /// </retval>
    /// <retval>
    /// @retval kGpaStatusErrorFailed If an internal error has occurred.
    /// </retval>
    /// <retval>
    /// @retval kGpaStatusErrorException If an unexpected error has occurred.
    /// </retval>
    public static unsafe GPUPerfAPI.GpaStatus GpaGetDeviceName(GPUPerfAPI.GpaContextId gpa_context_id, out string? device_name)
    {
        device_name = null;
        var result = GpaGetDeviceName(gpa_context_id, out byte* device_namePtr);
        if (result == GpaStatus.kGpaStatusOk)
        {
            device_name = Marshal.PtrToStringUTF8((nint)device_namePtr);
        }
        return result;
    }

    /// <summary>
    /// @brief Gets the name of the specified counter.
    /// </summary>
    /// <param name="gpa_session_id">Unique identifier of a session.</param>
    /// <param name="index">The index of the counter whose name is needed. Must lie between 0 and (GpaGetNumCounters result - 1).</param>
    /// <param name="counter_name">The address which will hold the name upon successful execution.</param>
    /// <returns>@return The GPA result status of the operation.</returns>
    /// <remarks>
    ///  gpa_counter_interrogation
    /// </remarks>
    /// <retval>
    /// @retval kGpaStatusOk If the operation is successful.
    /// </retval>
    /// <retval>
    /// @retval kGpaStatusErrorNullPointer If any of the parameters are NULL.
    /// </retval>
    /// <retval>
    /// @retval kGpaStatusErrorSessionNotFound If the supplied session is invalid.
    /// </retval>
    /// <retval>
    /// @retval kGpaStatusErrorIndexOutOfRange If the counter index is out of range.
    /// </retval>
    /// <retval>
    /// @retval kGpaStatusErrorFailed If an internal error has occurred.
    /// </retval>
    /// <retval>
    /// @retval kGpaStatusErrorException If an unexpected error has occurred.
    /// </retval>
    public static unsafe GPUPerfAPI.GpaStatus GpaGetCounterName(GPUPerfAPI.GpaSessionId gpa_session_id, uint index, out string? counter_name)
    {
        counter_name = null;
        var result = GpaGetCounterName(gpa_session_id, index, out byte* counter_namePtr);
        if (result == GpaStatus.kGpaStatusOk)
        {
            counter_name = Marshal.PtrToStringUTF8((nint)counter_namePtr);
        }
        return result;
    }

    /// <summary>
    /// @brief Gets the group of the specified counter.
    /// </summary>
    /// <param name="gpa_session_id">Unique identifier of a session.</param>
    /// <param name="index">The index of the counter whose group is needed. Must lie between 0 and (GpaGetNumCounters result - 1).</param>
    /// <param name="counter_group">The address which will hold the group string upon successful execution.</param>
    /// <returns>@return The GPA result status of the operation.</returns>
    /// <remarks>
    ///  gpa_counter_interrogation
    /// </remarks>
    /// <retval>
    /// @retval kGpaStatusOk If the operation is successful.
    /// </retval>
    /// <retval>
    /// @retval kGpaStatusErrorNullPointer If any of the parameters are NULL.
    /// </retval>
    /// <retval>
    /// @retval kGpaStatusErrorSessionNotFound If the supplied session is invalid.
    /// </retval>
    /// <retval>
    /// @retval kGpaStatusErrorIndexOutOfRange If the counter index is out of range.
    /// </retval>
    /// <retval>
    /// @retval kGpaStatusErrorFailed If an internal error has occurred.
    /// </retval>
    /// <retval>
    /// @retval kGpaStatusErrorException If an unexpected error has occurred.
    /// </retval>
    public static unsafe GPUPerfAPI.GpaStatus GpaGetCounterGroup(GPUPerfAPI.GpaSessionId gpa_session_id, uint index, out string? counter_group)
    {
        counter_group = null;
        var result = GpaGetCounterGroup(gpa_session_id, index, out byte* counter_groupPtr);
        if (result == GpaStatus.kGpaStatusOk)
        {
            counter_group = Marshal.PtrToStringUTF8((nint)counter_groupPtr);
        }
        return result;
    }

    /// <summary>
    /// @brief Gets the description of the specified counter.
    /// </summary>
    /// <param name="gpa_session_id">Unique identifier of a session.</param>
    /// <param name="index">The index of the counter whose description is needed. Must lie between 0 and (GpaGetNumCounters result - 1).</param>
    /// <param name="counter_description">The address which will hold the description upon successful execution.</param>
    /// <returns>@return The GPA result status of the operation.</returns>
    /// <remarks>
    ///  gpa_counter_interrogation
    /// </remarks>
    /// <retval>
    /// @retval kGpaStatusOk If the operation is successful.
    /// </retval>
    /// <retval>
    /// @retval kGpaStatusErrorNullPointer If any of the parameters are NULL.
    /// </retval>
    /// <retval>
    /// @retval kGpaStatusErrorSessionNotFound If the supplied session is invalid.
    /// </retval>
    /// <retval>
    /// @retval kGpaStatusErrorIndexOutOfRange If the counter index is out of range.
    /// </retval>
    /// <retval>
    /// @retval kGpaStatusErrorFailed If an internal error has occurred.
    /// </retval>
    /// <retval>
    /// @retval kGpaStatusErrorException If an unexpected error has occurred.
    /// </retval>
    public static unsafe GPUPerfAPI.GpaStatus GpaGetCounterDescription(GPUPerfAPI.GpaSessionId gpa_session_id, uint index, out string? counter_description)
    {
        counter_description = null;
        var result = GpaGetCounterDescription(gpa_session_id, index, out byte* counter_descriptionPtr);
        if (result == GpaStatus.kGpaStatusOk)
        {
            counter_description = Marshal.PtrToStringUTF8((nint)counter_descriptionPtr);
        }
        return result;
    }

    /// <summary>
    /// @brief Gets a string representation of the specified counter data type.
    /// </summary>
    /// <param name="counter_data_type">The data type whose string representation is needed.</param>
    /// <param name="type_as_str">The address which will hold the string representation upon successful execution.</param>
    /// <returns>@return The GPA result status of the operation.</returns>
    /// <remarks>
    /// This could be used to display counter types along with their name or value.
    /// For example, the kGpaDataTypeUint64 counter_data_type would return "gpa_uint64". gpa_counter_interrogation
    /// </remarks>
    /// <retval>
    /// @retval kGpaStatusOk If the operation is successful.
    /// </retval>
    /// <retval>
    /// @retval kGpaStatusErrorNullPointer If any of the parameters are NULL.
    /// </retval>
    /// <retval>
    /// @retval kGpaStatusErrorInvalidParameter An invalid data type was supplied.
    /// </retval>
    /// <retval>
    /// @retval kGpaStatusErrorException If an unexpected error has occurred.
    /// </retval>
    public static unsafe GPUPerfAPI.GpaStatus GpaGetDataTypeAsStr(GPUPerfAPI.GpaDataType counter_data_type, out string? type_as_str)
    {
        type_as_str = null;
        var result = GpaGetDataTypeAsStr(counter_data_type, out byte* type_as_strPtr);
        if (result == GpaStatus.kGpaStatusOk)
        {
            type_as_str = Marshal.PtrToStringUTF8((nint)type_as_strPtr);
        }
        return result;
    }

    /// <summary>
    /// @brief Gets a string representation of the specified counter usage type.
    /// </summary>
    /// <param name="counter_usage_type">The usage type whose string representation is needed.</param>
    /// <param name="usage_type_as_str">The address which will hold the string representation upon successful execution.</param>
    /// <returns>@return The GPA result status of the operation.</returns>
    /// <remarks>
    /// This could be used to display counter units along with their name or value.
    /// For example, the GPA_USAGE_TYPE_PERCENTAGE counterUsageType would return "percentage". gpa_counter_interrogation
    /// </remarks>
    /// <retval>
    /// @retval kGpaStatusOk If the operation is successful.
    /// </retval>
    /// <retval>
    /// @retval kGpaStatusErrorNullPointer If any of the parameters are NULL.
    /// </retval>
    /// <retval>
    /// @retval kGpaStatusErrorInvalidParameter An invalid usage type was supplied.
    /// </retval>
    /// <retval>
    /// @retval kGpaStatusErrorException If an unexpected error has occurred.
    /// </retval>
    public static unsafe GPUPerfAPI.GpaStatus GpaGetUsageTypeAsStr(GPUPerfAPI.GpaUsageType counter_usage_type, out string? usage_type_as_str)
    {
        usage_type_as_str = null;
        var result = GpaGetUsageTypeAsStr(counter_usage_type, out byte* usage_type_as_strPtr);
        if (result == GpaStatus.kGpaStatusOk)
        {
            usage_type_as_str = Marshal.PtrToStringUTF8((nint)usage_type_as_strPtr);
        }
        return result;
    }

    /// <summary>
    /// Gets the SQTT sample results
    /// </summary>
    /// <param name="gpa_session_id">Unique identifier of the GPA Session Object.</param>
    /// <param name="sqtt_results">buffer to return results in</param>
    /// <returns>@return The GPA result status of the operation. kGpaStatusOk is returned if the operation is successful.</returns>
    /// <remarks>
    ///  gpa_session_interrogation
    /// </remarks>
    public static unsafe GPUPerfAPI.GpaStatus GpaSqttGetSampleResult(GPUPerfAPI.GpaSessionId gpa_session_id, Span<byte> sqtt_results)
    {
        fixed (byte* sqtt_resultsPtr = sqtt_results)
        {
            return GpaSqttGetSampleResult(gpa_session_id, (nuint)sqtt_results.Length, sqtt_resultsPtr);
        }
    }

    /// <summary>
    /// Gets the SPM sample results
    /// </summary>
    /// <param name="gpa_session_id">Unique identifier of the GPA Session Object.</param>
    /// <param name="spm_results">buffer of returned results.</param>
    /// <returns>@return The GPA result status of the operation. kGpaStatusOk is returned if the operation is successful.</returns>
    /// <remarks>
    ///  gpa_session_interrogation
    /// </remarks>
    public static unsafe GPUPerfAPI.GpaStatus GpaSpmGetSampleResult(GPUPerfAPI.GpaSessionId gpa_session_id, Span<byte> spm_results)
    {
        fixed (byte* spm_resultsPtr = spm_results)
        {
            return GpaSpmGetSampleResult(gpa_session_id, (nuint)spm_results.Length, spm_resultsPtr);
        }
    }

    /// <summary>
    /// Calculate derived counters from collected SPM data
    /// </summary>
    /// <param name="gpa_session_id">Unique identifier of the GPA Session Object.</param>
    /// <param name="spm_data">Collected SPM data.</param>
    /// <param name="derived_counter_results">Counter results of num_derived_counters * timestamps entries.</param>
    /// <returns>@return The GPA result status of the operation. kGpaStatusOk is returned if the operation is successful.</returns>
    /// <remarks>
    ///  gpa_session_interrogation
    /// </remarks>
    public static unsafe GPUPerfAPI.GpaStatus GpaSpmCalculateDerivedCounters(GPUPerfAPI.GpaSessionId gpa_session_id, ref GPUPerfAPI.GpaSpmData spm_data, Span<ulong> derived_counter_results)
    {
        fixed (ulong* derived_counter_resultsPtr = derived_counter_results)
        {
            return GpaSpmCalculateDerivedCounters(gpa_session_id, ref spm_data, (uint)derived_counter_results.Length, derived_counter_resultsPtr);
        }
    }
    
    /// <summary>
    /// @brief Copies a set of samples from a secondary command list back to the primary command list that executed the secondary command list.
    /// </summary>
    /// <param name="secondary_gpa_command_list_id">Secondary command list where the secondary samples were created.</param>
    /// <param name="primary_gpa_command_list_id">Primary command list to which the samples results should be copied. This should be the command list that executed the secondary command list.</param>
    /// <param name="new_sample_ids">New sample ids on a primary command list.</param>
    /// <returns>@return The GPA result status of the operation.</returns>
    /// <remarks>
    /// This function is only supported for DirectX 12 and Vulkan.
    /// GPA doesn't collect data for the samples created on secondary command lists unless they are copied to a new set of samples for the primary command list. gpa_sample_handling
    /// </remarks>
    /// <retval>
    /// @retval kGpaStatusOk If the operation is successful.
    /// </retval>
    /// <retval>
    /// @retval kGpaStatusErrorApiNotSupported This entrypoint is being called in a graphics API that does not support it.
    /// </retval>
    /// <retval>
    /// @retval kGpaStatusErrorNullPointer One of the supplied command list IDs is NULL.
    /// </retval>
    /// <retval>
    /// @retval kGpaStatusErrorCommandListNotFound One of the supplied command list IDs cannot be found.
    /// </retval>
    /// <retval>
    /// @retval kGpaStatusErrorFailed If an internal error has occurred.
    /// </retval>
    /// <retval>
    /// @retval kGpaStatusErrorException If an unexpected error has occurred.
    /// </retval>
    public static unsafe GPUPerfAPI.GpaStatus GpaCopySecondarySamples(GPUPerfAPI.GpaCommandListId secondary_gpa_command_list_id, GPUPerfAPI.GpaCommandListId primary_gpa_command_list_id, Span<uint> new_sample_ids)
    {
        fixed (uint* new_sample_idsPtr = new_sample_ids)
        {
            return GpaCopySecondarySamples(secondary_gpa_command_list_id, primary_gpa_command_list_id, (uint)new_sample_ids.Length, new_sample_idsPtr);
        }
    }
    
    /// <summary>
    /// @brief Gets the result data for a given sample.
    /// </summary>
    /// <param name="gpa_session_id">The session identifier with the sample you wish to retrieve the result of.</param>
    /// <param name="sample_id">The identifier of the sample to get the result for.</param>
    /// <param name="counter_sample_results">Address to which the counter data for the sample will be copied to.</param>
    /// <returns>@return The GPA result status of the operation.</returns>
    /// <remarks>
    /// This function will block until results are ready. Use GpaIsSessionComplete to check if results are ready. gpa_query_results
    /// </remarks>
    /// <retval>
    /// @retval kGpaStatusOk If the operation is successful.
    /// </retval>
    /// <retval>
    /// @retval kGpaStatusErrorNullPointer An invalid or NULL parameter was supplied.
    /// </retval>
    /// <retval>
    /// @retval kGpaStatusErrorSessionNotFound The supplied session could not be found.
    /// </retval>
    /// <retval>
    /// @retval kGpaStatusErrorSampleNotFound The supplied sample id could not be found.
    /// </retval>
    /// <retval>
    /// @retval kGpaStatusErrorReadingSampleResult The supplied buffer is too small for the sample results.
    /// </retval>
    /// <retval>
    /// @retval kGpaStatusErrorFailed If an internal error has occurred.
    /// </retval>
    /// <retval>
    /// @retval kGpaStatusErrorException If an unexpected error has occurred.
    /// </retval>
    public static unsafe GPUPerfAPI.GpaStatus GpaGetSampleResult(GPUPerfAPI.GpaSessionId gpa_session_id, uint sample_id, Span<byte> counter_sample_results)
    {
        fixed (byte* counter_sample_resultsPtr = counter_sample_results)
        {
            return GpaGetSampleResult(gpa_session_id, sample_id, (nuint)counter_sample_results.Length, counter_sample_resultsPtr);
        }
    }
}
