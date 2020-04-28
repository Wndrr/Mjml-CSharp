using System;
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
            var rendered = renderer.Render(mjmlTemplate);
            if (rendered.Success)
            {
                File.WriteAllText("output.html", rendered.Result);
                Process.Start(new ProcessStartInfo() { FileName = "output.html", UseShellExecute = true });
            }
            else
            {
                Console.Error.WriteLine(rendered.Result);
                Environment.Exit(1);
            }
        }
    }
}