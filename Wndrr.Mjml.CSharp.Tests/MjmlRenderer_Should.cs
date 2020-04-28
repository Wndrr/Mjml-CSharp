using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Wndrr.Mjml.CSharp.Tests
{
    [TestClass]
    public class MjmlRenderer_Should
    {
        private const string nodePath = @"C:\Program Files\nodejs\node.exe";

        [TestMethod, TestCategory("Integration")]
        public void Render_Mjml_To_Html()
        {
            var renderer = new MjmlRenderer(nodePath);

            var result = renderer.Render(@"
                <mjml>
                    <mj-body>
                        <mj-section>
                            <mj-column>
                                <mj-text>Hello World</mj-text>
                            </mj-column>
                        </mj-section>
                    </mj-body>
                </mjml>");

            Assert.IsTrue(result.Contains("Hello World"));
        }

        [TestMethod, TestCategory("Integration")]
        public void Error_On_Invalid_Mjml()
        {
            var renderer = new MjmlRenderer(nodePath);

            var result = renderer.Render("foo");

            //TODO: return an error?
            Assert.IsTrue(result.Contains("Parsing failed"));
        }
    }
}
