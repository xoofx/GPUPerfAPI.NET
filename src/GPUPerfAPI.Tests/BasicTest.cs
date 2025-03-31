// Copyright (c) Alexandre Mutel. All rights reserved.
// Licensed under the BSD-Clause 2 license.
// See license.txt file in the project root for full license information.

using System.IO.Compression;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using GPUPerfAPI.CodeGen;

namespace GPUPerfAPI.Tests;

using static GPUPerfAPI;

[TestClass]
public class BasicTest
{
    public TestContext? TestContext { get; set; }
    
    [TestMethod]
    [OSCondition(OperatingSystems.Windows)]
    public async Task TestSimple()
    {
        if (RuntimeInformation.OSArchitecture != Architecture.X64)
        {
            Assert.Inconclusive("This test only works on x64");
            return;
        }

        var libraryHandle = await ExtractAndLoadDlls();

        GpaInitialize(kGpaInitializeDefaultBit).GpaCheck("Failed to initialize");

        // Get the function table (to test it)
        GpaFunctionTable gpaFunctionTable = new();
        GetGpaFunctionTableFromNativeLibrary(libraryHandle, ref gpaFunctionTable).GpaCheck("Unable to locate GetGpaFunctionTable function");

        gpaFunctionTable.GpaGetVersion(out var majorVersion, out var minorVersion, out var buildVersion, out var updateVersion).GpaCheck("Failed to get version");
        Assert.AreEqual(GPA_FUNCTION_TABLE_MAJOR_VERSION_NUMBER, (int)majorVersion);

        TestContext?.WriteLine($"Version: {majorVersion}.{minorVersion}.{buildVersion}.{updateVersion}");
        
        GpaDestroy().GpaCheck("Failed to destroy");
    }

    private static async Task<nint> ExtractAndLoadDlls()
    {
        var dllToLoad = Path.Combine(AppContext.BaseDirectory, "GPUPerfAPIVK-x64.dll");

        if (!File.Exists(dllToLoad))
        {
            var downloader = new GPUPerfAPIZipDownloader();
            await downloader.DownloadAndExtractBinaries(AppContext.BaseDirectory);
        }

        return NativeLibrary.Load(dllToLoad);
    }
}
