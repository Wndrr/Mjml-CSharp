using Microsoft.AspNetCore.Mvc;
using Wndrr.Mjml.CSharp;

namespace Demo.MvcApp.Controllers
{
    [Route("")]
    public class DefaultController : Controller
    {
        private readonly IMjmlRenderer renderer;

        public DefaultController(IMjmlRenderer renderer)
        {
            this.renderer = renderer;
        }

        public IActionResult Index()
        {
            const string mjml = @"
            <mjml>
              <mj-body>
                <mj-section>
                  <mj-column>
                    <mj-image width='100px' src='https://mjml.io/assets/img/logo-small.png'></mj-image>
                    <mj-divider border-color='#F45E43'></mj-divider>
                    <mj-text font-size='20px' color='#F45E43' font-family='helvetica'>Hello World</mj-text>
                  </mj-column>
                </mj-section>
              </mj-body>
            </mjml>";
            return Content(renderer.Render(mjml.Trim()), "text/html");
        }
    }
}