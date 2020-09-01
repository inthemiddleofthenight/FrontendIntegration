using System.Runtime.InteropServices;
using System.Windows;

namespace FrontendIntegration.EdgeChromium
{
    [ClassInterface(ClassInterfaceType.AutoDual)]
    [ComVisible(true)]
    public class IntegrationInterface
    {
        public void Call(string json)
        {
            MessageBox.Show($"Invoke from Edge Chromium frontend {json}");
        }
    }
}
