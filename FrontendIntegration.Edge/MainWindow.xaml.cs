using Microsoft.Toolkit.Wpf.UI.Controls;
using System;
using System.Web.Script.Serialization;
using System.Windows;

namespace FrontendIntegration.Edge
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
   
    public partial class MainWindow : Window
    {
        private readonly WebView _webBrowser = new WebView()
        {
            VerticalAlignment = VerticalAlignment.Stretch,
            HorizontalAlignment = HorizontalAlignment.Stretch
        };
        public MainWindow()
        {
            InitializeComponent();
            Container.Children.Add(_webBrowser);

            _webBrowser.IsJavaScriptEnabled = true;
            _webBrowser.IsScriptNotifyAllowed = true;
            _webBrowser.IsPrivateNetworkClientServerCapabilityEnabled = true;
            _webBrowser.ScriptNotify += _webBrowser_ScriptNotify;
            _webBrowser.Loaded += _webBrowser_Loaded;
      
        }

        private void _webBrowser_Loaded(object sender, RoutedEventArgs e)
        {
            _webBrowser.Navigate("https://localhost:44328/edge.html");
        }

        private void _webBrowser_ScriptNotify(object sender, Microsoft.Toolkit.Win32.UI.Controls.Interop.WinRT.WebViewControlScriptNotifyEventArgs e)
        {
            MessageBox.Show($"Invoke from frontend {e.Uri} {e.Value}");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _webBrowser.InvokeScript("reverseCall", new JavaScriptSerializer().Serialize(new
            {
                dt = DateTime.Now,
                str = "test",
                name = "edge frontend integration",
                type = "host-to-front"
            }));
        }
    }
}
