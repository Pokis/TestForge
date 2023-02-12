using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestForge.MutatorRunner.Runner
{
    internal class DotNetToolRunner
    {
        /// <summary>
        /// Runs local dotnet tool, returns console output as return.
        /// </summary>
        /// <param name="toolName"></param>
        /// <param name="arguments"></param>
        /// <returns>Output from console</returns>
        public static string RunTool(string toolName, string arguments, string? workingDir)
        {
            //TODO[DJ]: Redirect output to console
            var processInfo = new ProcessStartInfo
            {
                FileName = toolName,
                Arguments = arguments,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                CreateNoWindow = true
            };

            if (workingDir is not null)
            {
                processInfo.WorkingDirectory = workingDir;
            }

            var process = new Process
            {
                StartInfo = processInfo
            };

            process.Start();
            string output = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            return output;
        }
    }
}
