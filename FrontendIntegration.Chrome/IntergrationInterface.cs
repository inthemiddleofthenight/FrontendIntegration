using System.Windows;

namespace FrontendIntegration.Chrome
{
    public class IntergrationInterface
    {
        public void Call(string json)
        {
            MessageBox.Show($"Invoke from Chrome frontend {json}");
        }
    }
}
