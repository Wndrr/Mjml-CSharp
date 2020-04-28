using System;
using System.Diagnostics;
using System.Text;
using System.Threading;

namespace Wndrr.Mjml.CSharp
{
    internal sealed class NodeProcess
    {
        internal NodeProcessResult Run(string nodePath, string args, int timeoutMs = 15 * 1000)
        {
            using var process = new Process();
            process.StartInfo.FileName = nodePath;
            process.StartInfo.Arguments = args;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;

            var output = new StringBuilder();
            var error = new StringBuilder();

            using var outputWaitHandle = new AutoResetEvent(false);
            using var errorWaitHandle = new AutoResetEvent(false);
            process.OutputDataReceived += (sender, e) =>
            {
                if (e.Data == null)
                {
                    outputWaitHandle.Set();
                }
                else
                {
                    output.AppendLine(e.Data);
                }
            };
            process.ErrorDataReceived += (sender, e) =>
            {
                if (e.Data == null)
                {
                    errorWaitHandle.Set();
                }
                else
                {
                    error.AppendLine(e.Data);
                }
            };

            process.Start();

            process.BeginOutputReadLine();
            process.BeginErrorReadLine();

            if (!process.WaitForExit(timeoutMs) || !outputWaitHandle.WaitOne(timeoutMs) || !errorWaitHandle.WaitOne(timeoutMs))
                throw new TimeoutException($"The process did not finish before the timeout of {timeoutMs} milliseconds");

            return new NodeProcessResult()
            {
                ExitCode = process.ExitCode,
                StandardOutput = output.ToString(),
                StandardError = error.ToString()
            };
        }
    }
}
