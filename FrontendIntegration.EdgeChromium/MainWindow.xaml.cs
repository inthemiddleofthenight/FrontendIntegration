
using Microsoft.Web.WebView2.Wpf;
using System;
using System.Web.Script.Serialization;
using System.Windows;


namespace FrontendIntegration.EdgeChromium
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly string _url = "https://inthemiddleofthenight.github.io/FrontendIntegration/FrontendIntegration.Server/edgechromium.html";
        private readonly IntegrationInterface _integrationInterface = new IntegrationInterface();
        private readonly WebView2 _webBrowser = new WebView2()
        {
            VerticalAlignment = VerticalAlignment.Stretch,
            HorizontalAlignment = HorizontalAlignment.Stretch
        };
        public MainWindow()
        {
            InitializeComponent();
            Container.Children.Add(_webBrowser);

            _webBrowser.WebMessageReceived += _webBrowser_WebMessageReceived;
            _webBrowser.CoreWebView2Ready += _webBrowser_CoreWebView2Ready;
            _webBrowser.Source = new System.Uri(_url);
        }

        private void _webBrowser_CoreWebView2Ready(object sender, EventArgs e)
        {
            _webBrowser.CoreWebView2.AddHostObjectToScript("integrationInterface", _integrationInterface);
        }

        private void _webBrowser_WebMessageReceived(object sender, Microsoft.Web.WebView2.Core.CoreWebView2WebMessageReceivedEventArgs e)
        {
            MessageBox.Show($"Invoke from Edge Chromium frontend {e.WebMessageAsJson}");
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            string @params = new JavaScriptSerializer().Serialize(new
            {
                dt = DateTime.Now,
                str = "test 1 - ExecuteScriptAsync",
                name = "edge chromium frontend integration",
                type = "host-to-front"
            });
            await _webBrowser.ExecuteScriptAsync($"reverseCall({@params})");
        }
    }
}
