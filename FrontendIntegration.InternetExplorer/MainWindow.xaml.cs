using System;
using System.Web.Script.Serialization;
using System.Windows;
using System.Windows.Controls;

namespace FrontendIntegration.InternetExplorer
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly string _url = "https://inthemiddleofthenight.github.io/FrontendIntegration/FrontendIntegration.Server/ie.html";
        private readonly WebBrowser _webBrowser = new WebBrowser()
        {
            VerticalAlignment = VerticalAlignment.Stretch,
            HorizontalAlignment = HorizontalAlignment.Stretch
        };
        private readonly IntegrationInterface _integrationInterface = new IntegrationInterface();
        
        public MainWindow()
        {
            InitializeComponent();
            Container.Children.Add(_webBrowser);

            _webBrowser.ObjectForScripting = _integrationInterface;
            _webBrowser.Navigate(_url);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _webBrowser.InvokeScript("reverseCall", new JavaScriptSerializer().Serialize(new
            {
                dt = DateTime.Now,
                str = "test",
                name = "ie frontend integration",
                type = "host-to-front"
            }));
        }
    }
}
