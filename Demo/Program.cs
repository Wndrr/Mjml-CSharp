using System;
using System.IO;
using Wndrr.Mjml.CSharp;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            var nodeBasePath = @"C:\Program Files\nodejs";
            Mjml.PathRepository.NodePath = $@"{nodeBasePath}\node.exe";
            Mjml.PathRepository.NpmPath = $@"{nodeBasePath}\node_modules\npm\bin\npm-cli.js";
            Mjml.PathRepository.TmpPath = Path.GetTempPath();
            
            var mjmlTemplate = "<mjml><mj-body><mj-section><mj-column><mj-image width=\"100px\" src=\"/assets/img/logo-small.png\"></mj-image><mj-divider border-color=\"#F45E43\"></mj-divider><mj-text font-size=\"20px\" color=\"#F45E43\" font-family=\"helvetica\">Hello World</mj-text></mj-column></mj-section></mj-body></mjml>";
            var outputHtml = Mjml.Render(mjmlTemplate);
            
            Console.Write(outputHtml);

            Console.ReadKey();
        }
    }
}