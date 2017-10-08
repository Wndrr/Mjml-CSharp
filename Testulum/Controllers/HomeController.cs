using System.IO;
using System.Web.Mvc;
using Wndrr.Mjml.CSharp;

namespace Testulum.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var readAllText = System.IO.File.ReadAllText(@"C:\Projects\Mjml\test.mjml");

            Mjml.PathRepository.NodePath = @"C:\Program Files\nodejs\node.exe";
            Mjml.PathRepository.NpmPath = @"C:\Program Files\nodejs\node_modules\npm\bin\npm-cli.js";
            Mjml.PathRepository.TmpPath = Path.GetTempPath();
            
            return Content(Mjml.Render(readAllText));
        }
    }
}