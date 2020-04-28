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

            var rendered = renderer.Render(@"
                <mjml>
                    <mj-body>
                        <mj-section>
                            <mj-column>
                                <mj-text>Hello World</mj-text>
                            </mj-column>
                        </mj-section>
                    </mj-body>
                </mjml>");

            Assert.IsTrue(rendered.Success, "This markup should render successfully.");
            Assert.IsTrue(rendered.Result.Contains("Hello World"), "Result should contain rendered text.");
        }

        [TestMethod, TestCategory("Integration")]
        public void Error_On_Invalid_Mjml()
        {
            var renderer = new MjmlRenderer(nodePath);

            var rendered = renderer.Render("foo");

            System.Console.WriteLine(rendered.Result);
            Assert.IsFalse(rendered.Success, "Rendering invalid MJML should fail.");
            Assert.IsFalse(string.IsNullOrWhiteSpace(rendered.Result), "Result should explain the cause of the failure.");
        }
    }
}
