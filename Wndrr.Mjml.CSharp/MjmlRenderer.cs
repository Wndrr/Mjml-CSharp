using System;
using System.IO;
using System.Reflection;

namespace Wndrr.Mjml.CSharp
{
    public class MjmlRenderer : IMjmlRenderer
    {
        private readonly string nodePath;
        private readonly NodeProcess nodeProcess = new NodeProcess();

        public MjmlRenderer(string nodePath)
        {
            this.nodePath = nodePath;
        }

        public RenderResult Render(string mjmlSrc)
        {
            Console.WriteLine(@"Running following node command");
            Console.WriteLine($@"{MjmlPath} -c ""{mjmlSrc}""");
            return RenderResult.From(nodeProcess.Run(nodePath, $"{MjmlPath} -c \"{mjmlSrc}\""));
        }

        internal static string MjmlPath
        {
            get
            {
                string assemblyDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                return Path.Combine(assemblyDir, "Resources", "mjmlFromString.mjs");
            }
        }
    }
}