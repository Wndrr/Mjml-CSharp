using System.IO;
using Wndrr.Mjml.CSharp.Properties;

namespace Wndrr.Mjml.CSharp
{
    internal static class Dependencies
    {
        internal static string Errors;
        internal static bool HasError => Errors != null;
        private static bool AreRessourcesInitialized { get; set; }

        internal static void Install()
        {
            // Only init the ressources once to avoid writing to the file system every time an object is instanciated
            if(AreRessourcesInitialized)
                return;

            Errors = null;
            Errors = InstallNpmPackages();
            ExtractRessources();

            AreRessourcesInitialized = true;
        }

        #region STATIC RESSOURCES

        private static void ExtractRessources()
        {
            CopyRessourceToTmp(Resources.mjmlFromString, Mjml.PathRepository.MjmlPath);
        }

        private static void CopyRessourceToTmp(byte[] ressource, string targetPath)
        {
            // Only write the file if it doesn't exist
            if(File.Exists(targetPath))
                return;

            Directory.CreateDirectory(Directory.GetParent(targetPath).FullName);

            using(var outputFile = new FileStream(targetPath, FileMode.CreateNew))
                outputFile.Write(ressource, 0, ressource.Length);
        }

        #endregion

        #region NPM

        private static string InstallNpmPackages()
        {
            var npm = new Npm();

            return npm.InstallPackageIfMissing("mjml");
        }

        #endregion
    }
}