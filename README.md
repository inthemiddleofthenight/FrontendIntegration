### Frontend - Webview hoster app inetgration

- Example command from js object in web app to host desktop app
- Example command from host desktop app to  js object in web app

**Google Chrome** https://cefsharp.github.io/

Binding opbject .NET to js 
```csharp
 _webBrowser.JavascriptObjectRepository.Register("IntegrationObject", _intergrationInterface, false);
 ```
 Defined object in js. Invoke js object function transfer control to bindable object.
 ```javascript
(async function () {
    CefSharp.BindObjectAsync('IntegrationObject');
})();
 ```
 Invoke script from .NET in js
 ```csharp
 await _webBrowser.EvaluateScriptAsync("reverseCall", new JavaScriptSerializer().Serialize(new
{
         dt = DateTime.Now,
         str = "test",
         name = "chrome frontend integration",
         type = "host-to-front"
 }));
 ```
 reverseCall - function in window object
 
**Edge** https://docs.microsoft.com/en-us/windows/communitytoolkit/controls/wpf-winforms/webview

Add handler to webView to Notify event in .NET

```csharp
_webBrowser.ScriptNotify += _webBrowser_ScriptNotify;

private void _webBrowser_ScriptNotify(object sender, Microsoft.Toolkit.Win32.UI.Controls.Interop.WinRT.WebViewControlScriptNotifyEventArgs e)
{
       MessageBox.Show($"Invoke from Edge frontend {e.Value}");
}
```

Invoke in js
```javascript
window.external.notify(json);
```

 Invoke script from .NET in js
 ```csharp
_webBrowser.InvokeScript("reverseCall", new JavaScriptSerializer().Serialize(
new
{
         dt = DateTime.Now,
         str = "test",
         name = "edge frontend integration",
         type = "host-to-front"
}));
 ```
 reverseCall - function in window object
 
**Edge Chromium** https://docs.microsoft.com/ru-ru/microsoft-edge/webview2/

Bindable object
```csharp
    [ClassInterface(ClassInterfaceType.AutoDual)]
    [ComVisible(true)]
    public class IntegrationInterface
    {
        public void MethodInvoke(string json)
        {
            MessageBox.Show($"Invoke from Edge Chromium frontend {json}");
        }
    }
```

Set bindable object for webView
```csharp
_webBrowser.CoreWebView2.AddHostObjectToScript("integrationInterface", _integrationInterface);
```
or add event listener
```csharp
 _webBrowser.WebMessageReceived += _webBrowser_WebMessageReceived;
  
private void _webBrowser_WebMessageReceived(object sender, Microsoft.Web.WebView2.Core.CoreWebView2WebMessageReceivedEventArgs e)
{
            MessageBox.Show($"Invoke from Edge Chromium frontend {e.WebMessageAsJson}");
}
```
Invoke in js
```javascript
 window.chrome.webview.postMessage(json);
```
or through bindable object
```javascript
await chrome.webview.hostObjects.integrationInterface.MethodInvoke(json);
```

 Invoke script from .NET in js
 ```csharp
  string @params = new JavaScriptSerializer().Serialize(new
{
        dt = DateTime.Now,
        str = "test 1 - ExecuteScriptAsync",
        name = "edge chromium frontend integration",
        type = "host-to-front"
});
await _webBrowser.ExecuteScriptAsync($"reverseCall({@params})");
 ```

**Internet Explorer (11)** System.Windows.Controls.WebBrowser

Bindable object
```csharp
    [ComVisible(true)]
    public class IntegrationInterface
    {
        public void methodInvoke(string json)
        {
        }
    }
```

Set bindable object for webView
```csharp
_webBrowser.ObjectForScripting = _integrationInterface;
```

Invoke in js
```javascript
  window.external.methodInvoke(json);
```

 Invoke script from .NET in js
 ```csharp
 _webBrowser.InvokeScript("reverseCall", new JavaScriptSerializer().Serialize(
 new
 {
       dt = DateTime.Now,
       str = "test",
       name = "ie frontend integration",
       type = "host-to-front"
}));
 ```
 reverseCall - function in window object
