namespace Wndrr.Mjml.CSharp
{
    public class RenderResult
    {
        public bool Success { get; set; }
        public string Result { get; set; }

        internal static RenderResult From(NodeProcessResult nodeResult)
        {
            bool success = nodeResult.ExitCode == 0;
            return new RenderResult()
            {
                Success = success,
                Result = success ? nodeResult.StandardOutput : nodeResult.StandardError
            };
        }
    }
}