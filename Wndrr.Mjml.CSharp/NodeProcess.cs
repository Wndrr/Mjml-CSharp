using System.Diagnostics;
using System.Text;

namespace Wndrr.Mjml.CSharp
{
    internal sealed class NodeProcess
    {
        #region INIT

        #region OUTPUT

        private readonly StringBuilder _standardOutput = new StringBuilder(string.Empty);
        private readonly StringBuilder _stringBuilder = new StringBuilder(string.Empty);

        #endregion

        #endregion

        #region PROCESS IMPLEMENTATION

        internal string Run(string command)
        {
            using (Process process = new Process())
            {
                process.StartInfo.FileName = @"C:\Program Files\nodejs\node.exe";
                process.StartInfo.Arguments = command;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardError = true;

                process.Start();

                while (!process.HasExited)
                {
                    _standardOutput.Append(process.StandardOutput.ReadToEnd());
                    _stringBuilder.Append(process.StandardError.ReadToEnd());
                }

                process.Start();

                process.WaitForExit();

                var errorStr = _stringBuilder.ToString();

                return errorStr != string.Empty ? errorStr : _standardOutput.ToString();
            }
        }

        #endregion
    }
}
