using System.Text.RegularExpressions;

namespace Wndrr.Mjml.CSharp
{
    internal static class MjmlTools
    {
        internal static string Minify(string inputMjml)
        {
            return Regex.Replace(inputMjml, @"(\n|\r|\r\n|  )", "");
        }
    }
}