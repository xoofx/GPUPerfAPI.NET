// Copyright (c) Alexandre Mutel. All rights reserved.
// Licensed under the BSD-Clause 2 license.
// See license.txt file in the project root for full license information.

using System;
using System.IO.Compression;

namespace GPUPerfAPI.CodeGen;

public class GPUPerfAPIZipDownloader
{
    public GPUPerfAPIZipDownloader()
    {
        Url = $"https://github.com/GPUOpen-Tools/gpu_performance_api/releases/download/v4.0-tag/{NameAndVersion}.zip";
    }

    public const string NameAndVersion = "GPUPerfAPI-4.0.0.39";

    public string Url { get; set; }
    
    public async Task DownloadAndExtractZipToFolder(string folder)
    {
        if (string.IsNullOrEmpty(folder)) throw new ArgumentNullException(nameof(folder));

        if (!Directory.Exists(folder))
        {
            Directory.CreateDirectory(folder);
        }

        // Download the zip file all the files
        using var httpClient = new HttpClient();
        var response = await httpClient.GetAsync(Url);
        response.EnsureSuccessStatusCode();
        var buffer = await response.Content.ReadAsByteArrayAsync();
        var stream = new MemoryStream(buffer);
        using var archive = new ZipArchive(stream);

        archive.ExtractToDirectory(folder);
    }

    public async Task DownloadAndExtractBinaries(string folder)
    {
        if (string.IsNullOrEmpty(folder)) throw new ArgumentNullException(nameof(folder));
        if (!Directory.Exists(folder))
        {
            Directory.CreateDirectory(folder);
        }

        // Check if the file already exists
        if (File.Exists(Path.Combine(folder, "GPUPerfAPIVK-x64.dll"))) return;

        // Download the zip file and extract dll from the folder v4.0/bin/*.*
        using var httpClient = new HttpClient();
        var response = await httpClient.GetAsync(Url);
        response.EnsureSuccessStatusCode();
        var buffer = await response.Content.ReadAsByteArrayAsync();
        var stream = new MemoryStream(buffer);
        using var archive = new ZipArchive(stream);
        foreach (var entry in archive.Entries)
        {
            if (entry.FullName.StartsWith("4_0/bin/", StringComparison.OrdinalIgnoreCase) && !entry.FullName.EndsWith('/'))
            {
                var entryFileName = Path.GetFileName(entry.FullName);
                entry.ExtractToFile(Path.Combine(folder, entryFileName));
            }
        }
    }
}