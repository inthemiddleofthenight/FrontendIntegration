using CefSharp;
using CefSharp.Wpf;
using System.Windows;

namespace FrontendIntegration.Chrome
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            Cef.Initialize(new CefSettings());
        }
    }
}
