
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
        private readonly string _url = "https://inthemiddleofthenight.github.io/FrontendIntegration/FrontendIntegration.Server/edge.html";
        private readonly WebView2 _webBrowser = new WebView2()
        {
            VerticalAlignment = VerticalAlignment.Stretch,
            HorizontalAlignment = HorizontalAlignment.Stretch
        };
        public MainWindow()
        {
            InitializeComponent();
            Container.Children.Add(_webBrowser);

            _webBrowser.Source = new System.Uri(_url);
         
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            string @params = new JavaScriptSerializer().Serialize(new
            {
                dt = DateTime.Now,
                str = "test",
                name = "edge frontend integration",
                type = "host-to-front"
            });
            await _webBrowser.ExecuteScriptAsync($"reverseCall({@params})");
        }
    }
}
