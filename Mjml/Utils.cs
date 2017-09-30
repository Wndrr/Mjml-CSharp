using System;
using System.Linq;
using System.Linq.Expressions;
using System.Management.Automation;

namespace Wndrr.Mjml.CSharp
{
    internal static class Utils
    {
        internal static string GetNameOf<T>(Expression<Func<T>> property)
        {
            return (property.Body as MemberExpression)?.Member.Name;
        }

        internal static string RunPowershellCmd(params string[] command)
        {
            using (var powerShell = PowerShell.Create())
            {
                foreach(var s in command)
                {
                    powerShell.AddScript(s);
                }

                powerShell.Invoke();

                var htmlOutput = powerShell.Runspace.SessionStateProxy.GetVariable("htmlOutput") as object[];

                var output = String.Empty;

                if (htmlOutput != null)
                    output = htmlOutput.Cast<PSObject>().Aggregate(output, (current, item) => current + item.BaseObject.ToString());

                if (powerShell.Streams.Error.Count > 0)
                    output = powerShell.Streams.Error.Aggregate(output, (current, err) => current + (err + "<br />"));

                return output;
            }
        }
    }
}