using System.Diagnostics;
using System.IO;
using Wndrr.Mjml.CSharp;

namespace Demo
{
    class Program
    {
        static void Main()
        {
            var renderer = new MjmlRenderer(@"C:\Program Files\nodejs\node.exe");
            var mjmlTemplate = File.ReadAllText("example.mjml");
            var outputHtml = renderer.Render(mjmlTemplate);

            File.WriteAllText("output.html", outputHtml);
            Process.Start(new ProcessStartInfo() { FileName = "output.html", UseShellExecute = true });
        }
    }
}