using System;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Reflection;

namespace Wndrr.Mjml
{
    public static class Mjml
    {
        private static string _nodePath;
        private static string _mjmlPath;
        private static string _mjmlContent;

        public static string AssemblyDirectory
        {
            get
            {
                string codeBase = Assembly.GetExecutingAssembly().CodeBase;
                UriBuilder uri = new UriBuilder(codeBase);
                string path = Uri.UnescapeDataString(uri.Path);
                return Path.GetDirectoryName(path);
            }
        }

        public static void Init(string mjmlContent, string mjmlPath = null, string nodePath = null)
        {
            _mjmlContent = mjmlContent;
            _mjmlPath = mjmlPath ?? Path.Combine(AssemblyDirectory, ".bin", "mjmlFromString");
            _nodePath = nodePath ?? Path.Combine(AssemblyDirectory, ".bin", "Node.exe");
        }

        public static string Render()
        {
            var output = string.Empty;
            
            var command = $"$htmlOutput = {_nodePath} {_mjmlPath} -c \"{_mjmlContent}\"";

            var powerShell = PowerShell.Create();

            powerShell.AddScript(command);
            powerShell.Invoke();
            var t = powerShell.Runspace.SessionStateProxy.GetVariable("htmlOutput") as object[];

            if (t != null)
            {
                output = t.Cast<PSObject>().Aggregate(output, (current, item) => current + item.BaseObject.ToString());
            }

            if (powerShell.Streams.Error.Count > 0)
            {
                output = powerShell.Streams.Error.Aggregate(output, (current, err) => current + (err + "<br />"));
            }
            return output;

        }
    }
}