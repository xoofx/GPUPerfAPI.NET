// Copyright (c) Alexandre Mutel. All rights reserved.
// Licensed under the BSD-Clause 2 license.
// See license.txt file in the project root for full license information.

namespace GPUPerfAPI;

partial class GPUPerfAPI
{
    /// <summary>
    /// Checks the status and throws an exception if the status is not successful.
    /// </summary>
    /// <param name="status">The status to check</param>
    /// <param name="message">An optional message</param>
    /// <exception cref="GPUPerfAPIException">An exception if the status is not successful</exception>
    public static void GpaCheck(this GpaStatus status, string? message = null)
    {
        if ((int)status < 0)
        {
            throw new GPUPerfAPIException(status, message);
        }
    }

    /// <summary>
    /// Exception thrown by GPUPerfAPI.
    /// </summary>
    public class GPUPerfAPIException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GPUPerfAPIException"/> class.
        /// </summary>
        /// <param name="status">The status</param>
        /// <param name="message">An optional contextual message</param>
        public GPUPerfAPIException(GPUPerfAPI.GpaStatus status, string? message = null) : base(FormatMessage(status, message))
        {
            Status = status;
        }

        public GPUPerfAPI.GpaStatus Status { get; }

        private static string FormatMessage(GPUPerfAPI.GpaStatus status, string? message)
        {
            message ??= "An error occurred";
            return $"{message} ({status})";
        }
    }
}