﻿// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Diagnostics;

namespace Microsoft.AspNet.Tests.Performance.Utility.Helpers
{
    public class KpmHelper
    {
        public static bool RestorePackage(string workingDir, string framework, bool quiet = false)
        {
            var kpmPath = DnxHelper.GetKpmExecutable(alias: "default", framework: framework);

            var psi = new ProcessStartInfo(kpmPath)
            {
                Arguments = "restore" + (quiet ? " --quiet" : ""),
                WorkingDirectory = workingDir,
                UseShellExecute = false
            };

            var proc = Process.Start(psi);

            var exited = proc.WaitForExit(300 * 1000);

            return exited && proc.ExitCode == 0;
        }
    }
}