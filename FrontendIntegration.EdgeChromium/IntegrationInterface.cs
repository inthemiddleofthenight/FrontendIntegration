using System.Windows;

namespace FrontendIntegration.EdgeChromium
{
    public class IntegrationInterface
    {
        public void Call(string json)
        {
            MessageBox.Show($"Invoke from Edge Chromium frontend {json}");
        }
    }
}
