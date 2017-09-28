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

        private static string RootNamespace => typeof(Mjml).Namespace;
        private static readonly string NodePath = Path.Combine(Path.GetTempPath(), $"{RootNamespace}.Node.exe");
        private static readonly string MjmlPath = Path.Combine(Path.GetTempPath(), $"{RootNamespace}.mjmlFromString");

        private static bool _areRessourcesInitialized;
        
        public Mjml()
        {
            // Only init the ressources once to avoid writing to the file system every time an object is instanciated
            if(!_areRessourcesInitialized)
            {
                InitRessources();
                _areRessourcesInitialized = true;
            }
        }

        #region RESSOURCES

        private static void InitRessources()
        {
            CopyRessourceToTmp(Properties.Resources.node, NodePath);
            CopyRessourceToTmp(Properties.Resources.mjmlFromString, MjmlPath);
        }

        private static void CopyRessourceToTmp(byte[] ressource, string targetName)
        {
            using(var exeFile = new FileStream(targetName, FileMode.Create))
                exeFile.Write(ressource, 0, ressource.Length);
        }

        #endregion

        #endregion

        #region RENDERING

        public string Render(string mjmlSrc)
        {

            var command = $"$htmlOutput = {NodePath} {MjmlPath} -c \"{mjmlSrc}\"";

            return RunPowershellCmd(command);
        }

        public string[] Render(params string[] mjmlSrcs)
        {
            return mjmlSrcs.Select(RunPowershellCmd).ToArray();
        }

        private static string RunPowershellCmd(string command)
        {
            var powerShell = PowerShell.Create();

            powerShell.AddScript(command).Invoke();

            var htmlOutput = powerShell.Runspace.SessionStateProxy.GetVariable("htmlOutput") as object[];

            var output = string.Empty;

            if(htmlOutput != null)
                output = htmlOutput.Cast<PSObject>().Aggregate(output, (current, item) => current + item.BaseObject.ToString());
            
            if(powerShell.Streams.Error.Count > 0)
                output = powerShell.Streams.Error.Aggregate(output, (current, err) => current + (err + "<br />"));
            
            return output;
        }

        #endregion
    }
}