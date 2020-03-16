using System;
using System.Diagnostics;
using System.Text;
using System.Threading;

namespace Wndrr.Mjml.CSharp
{
    internal sealed class NodeProcess
    {
        #region INIT

        #region OUTPUT

        private readonly StringBuilder _standardOutput = new StringBuilder(string.Empty);
        private readonly StringBuilder _standardError = new StringBuilder(string.Empty);

        #endregion

        #endregion

        #region PROCESS IMPLEMENTATION

        internal string Run(string command)
        {
            
            using (var process = new Process())
            {
                process.StartInfo.FileName = Mjml.PathRepository.NodePath;
                process.StartInfo.Arguments = command;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardError = true;

                var output = new StringBuilder();
                var error = new StringBuilder();

                using var outputWaitHandle = new AutoResetEvent(false);
                using var errorWaitHandle = new AutoResetEvent(false);
                process.OutputDataReceived += (sender, e) => {
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

                const int timeout = 15 * 1000;
                if (!process.WaitForExit(timeout) || !outputWaitHandle.WaitOne(timeout) || !errorWaitHandle.WaitOne(timeout)) 
                    throw new TimeoutException($"The process did not finish before the timeout of {timeout} milliseconds");
                    
                    
                // Process completed. Check process.ExitCode here.
                if (process.ExitCode != 0)
                    return error.ToString();

                return output.ToString();
            }
        }

        #endregion
    }
}
