using System;
using System.IO;

namespace Wndrr.Mjml.CSharp
{
    public class Mjml
    {
        #region INIT

        private static readonly NodeProcess NodeProcessProcess = new NodeProcess();
        
        static Mjml()
        {
            Dependencies.Install();
            
            if(Dependencies.HasError)
                throw new Exception($"<b>Dependency error</b>: {Dependencies.Errors}");
        }

        #endregion

        #region RENDERING
        
        public static string Render(string mjmlSrc)
        {
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
            internal static string MjmlPath => Path.Combine(TmpPath, "mjmlFromString");
        }
    }
}