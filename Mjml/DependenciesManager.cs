using System;
using System.IO;
using System.IO.Compression;
using System.Management.Automation.Runspaces;
using Ionic.Zip;

namespace Wndrr.Mjml.CSharp
{
    internal static class DependenciesManager
    {


        private static readonly string RootNamespace = typeof(Mjml).Namespace;
        private static readonly string BaseFolder = Path.Combine(Path.GetTempPath(), RootNamespace);
        internal static string NodePath => Path.Combine(BaseFolder, "Node.exe");
        internal static string MjmlPath => Path.Combine(BaseFolder, "mjmlFromString");
        internal static string NodeArchivePath => Path.Combine(BaseFolder, $"{NodeArchiveName}.zip");
        private static readonly byte[] NodePackageBytes = Properties.Resources.node_x86;
        private static readonly string NodeArchiveName = Utils.GetNameOf(() => Properties.Resources.node_x86);
        private static readonly string NpmPath = Path.Combine(BaseFolder, "node_modules/npm/bin/npm-cli.js");

        private static bool _areRessourcesInitialized;

        internal static void InitRessourcesOnce()
        {
            // Only init the ressources once to avoid writing to the file system every time an object is instanciated
            if (_areRessourcesInitialized)
                return;

            ExtractRessources();

            _areRessourcesInitialized = true;
        }

        private static void ExtractRessources()
        {

            if (CopyRessourceToTmp(NodePackageBytes, NodeArchivePath))
                ExtractFromZip(NodeArchivePath);

            InstallMjmlPackage();

            CopyRessourceToTmp(Properties.Resources.mjmlFromString, MjmlPath);
        }

        private static void InstallMjmlPackage()
        {
            Utils.RunPowershellCmd($"cd {BaseFolder}", $"{NodePath} {NpmPath} install mjml");
        }

        private static void ExtractFromZip(string archivePath)
        {
            using (var zip = ZipFile.Read(archivePath))
            {
                foreach (var file in zip)
                {
                    try
                    {
                        file.Extract(BaseFolder);
                    }

                    catch (Exception)
                    {
                        // ignored
                    }
                }
            }
        }

        private static bool CopyRessourceToTmp(byte[] ressource, string targetPath)
        {
            // Only write the file if it doesn't exist
            if (File.Exists(targetPath))
                return false;

            Directory.CreateDirectory(BaseFolder);

            using (var outputFile = new FileStream(targetPath, FileMode.CreateNew))
                outputFile.Write(ressource, 0, ressource.Length);

            return true;
        }
    }
}