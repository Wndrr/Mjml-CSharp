using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Reflection;

namespace Wndrr.Mjml.CSharp
{
    public class Mjml
    {
        #region INIT
        
        private readonly string _nodePath = Path.Combine(AssemblyDirectory, ".bin", "Node.exe");
        private readonly string _mjmlPath = Path.Combine(AssemblyDirectory, ".bin", "mjmlFromString");

        public static string AssemblyDirectory
        {
            get
            {
                var codeBase = Assembly.GetExecutingAssembly().CodeBase;
                var uri = new UriBuilder(codeBase);
                var path = Uri.UnescapeDataString(uri.Path);
                return Path.GetDirectoryName(path);
            }
        }

        #endregion

        #region RENDERING

        public string Render(string mjmlSrc)
        {
            var command = $"$htmlOutput = {_nodePath} {_mjmlPath} -c \"{mjmlSrc}\"";

            return RunPowershellCmd(command);
        }

        public string[] Render(params string[] mjmlSrcs)
        {
            return mjmlSrcs.Select(RunPowershellCmd).ToArray();
        }

        private static string RunPowershellCmd(string command)
        {
            var powerShell = PowerShell.Create();

            powerShell.AddScript(command);
            powerShell.Invoke();
            var t = powerShell.Runspace.SessionStateProxy.GetVariable("htmlOutput") as object[];

            var output = string.Empty;

            if(t != null)
            {
                output = t.Cast<PSObject>().Aggregate(output, (current, item) => current + item.BaseObject.ToString());
            }

            if(powerShell.Streams.Error.Count > 0)
            {
                output = powerShell.Streams.Error.Aggregate(output, (current, err) => current + (err + "<br />"));
            }

            return output;
        }

        #endregion
    }
}