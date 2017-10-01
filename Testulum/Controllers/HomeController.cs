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

            var t = mjml.Render("<mjml><mj-body><mj-container><mj-section><mj-column><mj-image width=\"100\" src=\"/assets/img/logo-small.png\"></mj-image><mj-divider border-color=\"#F45E43\"></mj-divider><mj-text font-size=\"20px\" color=\"#F45E43\" font-family=\"helvetica\">Hello World</mj-text></mj-column></mj-section></mj-container></mj-body></mjml>");
            return Content(t);
        }
    }
}