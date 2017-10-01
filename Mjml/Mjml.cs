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
        
        public Mjml()
        {
            DependenciesManager.InitRessourcesOnce();
        }
        
        #endregion

        #region RENDERING

        public string Render(string mjmlSrc)
        {
            // the backtick character (`)  before the double quotes are used to remove the need to escape the source string
            var command = $"$htmlOutput = {DependenciesManager.NodePath} {DependenciesManager.MjmlPath} -c `\"{MjmlTools.Minify(mjmlSrc)}`\"";

            return Utils.RunPowershellCmd(command);
        }

        public string[] Render(params string[] mjmlSrcs)
        {
            return mjmlSrcs.Select(Render).ToArray();
        }

        #endregion
    }
}