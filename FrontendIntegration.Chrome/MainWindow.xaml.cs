using CefSharp;
using CefSharp.Wpf;
using System;
using System.Web.Script.Serialization;
using System.Windows;

namespace FrontendIntegration.Chrome
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ChromiumWebBrowser _webBrowser = new ChromiumWebBrowser()
        {
            VerticalAlignment = VerticalAlignment.Stretch,
            HorizontalAlignment = HorizontalAlignment.Stretch
        };
        private readonly IntergrationInterface _intergrationInterface = new IntergrationInterface();
        public MainWindow()
        {
            InitializeComponent();


            Container.Children.Add(_webBrowser);

            _webBrowser.JavascriptObjectRepository.Register("IntegrationObject", _intergrationInterface, false);
            _webBrowser.IsBrowserInitializedChanged += _webBrowser_IsBrowserInitializedChanged; ;
            Closed += MainWindow_Closed;
        }

        private void _webBrowser_IsBrowserInitializedChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (_webBrowser.IsInitialized && !_webBrowser.IsDisposed)
            {
                _webBrowser.Load("https://localhost:44328/chrome.html");
                _webBrowser.ShowDevTools();
            }
        }

        private void MainWindow_Closed(object sender, System.EventArgs e)
        {
            Cef.Shutdown();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            await _webBrowser.EvaluateScriptAsync("reverseCall", new JavaScriptSerializer().Serialize(new
            {
                dt = DateTime.Now,
                str = "test",
                name = "chrome frontend integration",
                type = "host-to-front"
            }));
        }
    }
}
