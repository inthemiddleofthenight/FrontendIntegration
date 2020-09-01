using System.Runtime.InteropServices;
using System.Windows;

namespace FrontendIntegration.InternetExplorer
{
    [ComVisible(true)]
    public class IntegrationInterface
    {
        public void call(string json)
        {
            MessageBox.Show($"Invoke from IE frontend {json}");
        }
    }
}
