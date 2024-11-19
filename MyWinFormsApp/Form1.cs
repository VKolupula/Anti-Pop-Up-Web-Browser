using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace KolupulaBrowser
{
    public partial class MainForm : Form
    {
        private string defaultUrl;

        public MainForm(string defaultUrl = "https://aniwatchtv.to")
        {
            InitializeComponent();
            this.defaultUrl = defaultUrl; // Set the default URL
            this.WindowState = FormWindowState.Normal; // Set initial window state to normal
            this.FormBorderStyle = FormBorderStyle.Sizable; // Allow resizing and standard window controls
            this.KeyPreview = true; // Enable form to receive key events
            this.KeyDown += new KeyEventHandler(MainForm_KeyDown); // Add key down event handler
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            await webView21.EnsureCoreWebView2Async(null);
            webView21.CoreWebView2.NewWindowRequested += CoreWebView2_NewWindowRequested;

            // Inject JavaScript to detect fullscreen mode
            string script = @"
                document.addEventListener('fullscreenchange', function () {
                    window.chrome.webview.postMessage(document.fullscreenElement ? 'enter-fullscreen' : 'exit-fullscreen');
                });
            ";
            await webView21.CoreWebView2.AddScriptToExecuteOnDocumentCreatedAsync(script);

            // Load the default or specified URL
            txtUrl.Text = defaultUrl;
            webView21.Source = new Uri(defaultUrl);

            // Enable or disable navigation buttons based on browser history
            webView21.CoreWebView2.HistoryChanged += (s, ev) => 
            {
                btnBack.Enabled = webView21.CoreWebView2.CanGoBack;
                btnForward.Enabled = webView21.CoreWebView2.CanGoForward;
            };

            // Listen for messages from JavaScript
            webView21.CoreWebView2.WebMessageReceived += CoreWebView2_WebMessageReceived;
        }

        private void CoreWebView2_WebMessageReceived(object? sender, Microsoft.Web.WebView2.Core.CoreWebView2WebMessageReceivedEventArgs e)
        {
            string message = e.TryGetWebMessageAsString();
            if (message == "enter-fullscreen")
            {
                HideFormBorder();
            }
            else if (message == "exit-fullscreen")
            {
                ShowFormBorder();
            }
        }

        // Hide the form border
        private void HideFormBorder()
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            toolbarPanel.Visible = false;
        }

        // Show the form border
        private void ShowFormBorder()
        {
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.WindowState = FormWindowState.Normal;
            toolbarPanel.Visible = true;
        }

        // Automatically handle new window events (pop-ups)
        private void CoreWebView2_NewWindowRequested(object? sender, Microsoft.Web.WebView2.Core.CoreWebView2NewWindowRequestedEventArgs e)
        {
            e.Handled = true; // Automatically cancel the opening of the new window without user interaction
            Console.WriteLine("Blocked a pop-up!");
        }

        // Button to navigate back
        private void btnBack_Click(object sender, EventArgs e)
        {
            if (webView21.CoreWebView2.CanGoBack)
            {
                webView21.CoreWebView2.GoBack();
            }
        }

        // Button to navigate forward
        private void btnForward_Click(object sender, EventArgs e)
        {
            if (webView21.CoreWebView2.CanGoForward)
            {
                webView21.CoreWebView2.GoForward();
            }
        }

        // Button to refresh the page
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            webView21.Reload();
        }

        // Button to navigate to the URL entered by the user
        private void btnGo_Click(object sender, EventArgs e)
        {
            NavigateToUrl();
        }

        // Method to navigate to the URL entered by the user
        private void NavigateToUrl()
        {
            if (Uri.TryCreate(txtUrl.Text, UriKind.Absolute, out Uri? uriResult) &&
                (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps))
            {
                webView21.Source = uriResult;
            }
            else
            {
                MessageBox.Show("Please enter a valid URL.");
            }
        }

        // Key event handler to toggle full-screen mode
        private void MainForm_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F11)
            {
                ToggleFullScreen();
            }
        }

        // Method to toggle full-screen mode
        private void ToggleFullScreen()
        {
            if (this.FormBorderStyle == FormBorderStyle.None)
            {
                this.FormBorderStyle = FormBorderStyle.Sizable;
                this.WindowState = FormWindowState.Normal;
            }
            else
            {
                this.FormBorderStyle = FormBorderStyle.None;
                this.WindowState = FormWindowState.Maximized;
            }
        }
    }
}
