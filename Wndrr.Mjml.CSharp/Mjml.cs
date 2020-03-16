using System;
using System.IO;

namespace Wndrr.Mjml.CSharp
{
    public class Mjml
    {
        #region INIT

        private static readonly NodeProcess NodeProcessProcess = new NodeProcess();
        
        #endregion

        #region RENDERING
        
        public static string Render(string mjmlSrc)
        {
            Console.WriteLine(@"Running following node command");
            Console.WriteLine($@"{PathRepository.MjmlPath} -c ""{mjmlSrc}""");
            return NodeProcessProcess.Run($"{PathRepository.MjmlPath} -c \"{mjmlSrc}\"");
        }

        #endregion

        public static class PathRepository
        {
            private static readonly string RootNamespace = typeof(Mjml).Namespace;
            
            private static string _tmpPath;

            public static string TmpPath
            {
                get { return Path.Combine(_tmpPath, RootNamespace); }
                set { _tmpPath = value; }
            }

            public static string NodePath { get; set; }
            public static string NpmPath { get; set; }
            internal static string MjmlPath => Path.Combine(Directory.GetCurrentDirectory(), Path.Combine("Resources", "mjmlFromString.mjs"));
        }
    }
}