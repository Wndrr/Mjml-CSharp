namespace Wndrr.Mjml.CSharp
{
    internal class Npm
    {
        #region INIT

        private readonly NodeProcess _nodeProcessProcess = new NodeProcess();

        private static bool IsDebug { get; } = false;

        #endregion

        #region PROCESS IMPLEMENTATION

        public string InstallPackageIfMissing(string packageName)
        {
            return !IsPackageInstalled(packageName) ? InstallPackage(packageName) : null;
        }

        private string InstallPackage(string packageToInstall, string targetPath = null)
        {
            if(targetPath == null)
                targetPath = Mjml.PathRepository.TmpPath;

            var param = $"\"{Mjml.PathRepository.NpmPath}\" install --prefix=\"{targetPath}\" {packageToInstall}";
            
            var install = _nodeProcessProcess.Run(param);

            return IsDebug ? install : null;
        }

        #endregion

        #region CHECKING

        private bool IsPackageInstalled(string packageName)
        {
            var list = List($"--prefix=\"{Mjml.PathRepository.TmpPath}\" --depth=0");
            var isPackageInstalled = list.Contains(packageName);
            return isPackageInstalled;
        }

        private string List(string command)
        {
            return _nodeProcessProcess.Run($"\"{Mjml.PathRepository.NpmPath}\" list {command}");
        }

        #endregion
    }
}