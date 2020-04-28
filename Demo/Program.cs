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

            var mjmlTemplate = File.ReadAllText("example.mjml");
            var outputHtml = Mjml.Render(mjmlTemplate);

            File.WriteAllText("output.html", outputHtml);
            Process.Start(new ProcessStartInfo() { FileName = "output.html", UseShellExecute = true });
        }
    }
}