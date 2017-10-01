using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wndrr.Mjml;
using Wndrr.Mjml.CSharp;

namespace Testulum.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var mjml = new Mjml();

            var readAllText = System.IO.File.ReadAllText("C:\\Projects\\StackOverflow\\StackOverflow\\test.txt");
            var t = mjml.Render(readAllText);
            return Content(t);
        }
    }
}