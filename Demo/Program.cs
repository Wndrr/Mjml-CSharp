using System.Diagnostics;
using System.IO;
using Wndrr.Mjml.CSharp;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            Mjml.PathRepository.NodePath = @"C:\Program Files\nodejs\node.exe";
            Mjml.PathRepository.TmpPath = Path.GetTempPath();
            
            var mjmlTemplate = "<mjml><mj-body><mj-section><mj-column><mj-image width=\"100px\" src=\"/assets/img/logo-small.png\"></mj-image><mj-divider border-color=\"#F45E43\"></mj-divider><mj-text font-size=\"20px\" color=\"#F45E43\" font-family=\"helvetica\">Hello World</mj-text></mj-column></mj-section></mj-body></mjml>";
            var outputHtml = Mjml.Render(mjmlTemplate);

            File.WriteAllText("output.html", outputHtml);
            Process.Start(new ProcessStartInfo() { FileName = "output.html", UseShellExecute = true });
        }
    }
}