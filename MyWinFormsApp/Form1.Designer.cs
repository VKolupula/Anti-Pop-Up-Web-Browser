using System.Windows.Forms;

namespace KolupulaBrowser
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private Microsoft.Web.WebView2.WinForms.WebView2 webView21;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnForward;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.Panel toolbarPanel;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.webView21 = new Microsoft.Web.WebView2.WinForms.WebView2();
            this.btnGo = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnForward = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.toolbarPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            
            // toolbarPanel
            this.toolbarPanel.BackColor = System.Drawing.Color.LightSteelBlue;
            this.toolbarPanel.Dock = DockStyle.Top;
            this.toolbarPanel.Height = 40;
            this.toolbarPanel.Controls.Add(this.btnBack);
            this.toolbarPanel.Controls.Add(this.btnForward);
            this.toolbarPanel.Controls.Add(this.btnRefresh);
            this.toolbarPanel.Controls.Add(this.txtUrl);
            this.toolbarPanel.Controls.Add(this.btnGo);

            // btnBack
            this.btnBack.Location = new System.Drawing.Point(10, 10);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(40, 23);
            this.btnBack.TabIndex = 0;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);

            // btnForward
            this.btnForward.Location = new System.Drawing.Point(60, 10);
            this.btnForward.Name = "btnForward";
            this.btnForward.Size = new System.Drawing.Size(60, 23);
            this.btnForward.TabIndex = 1;
            this.btnForward.Text = "Forward";
            this.btnForward.UseVisualStyleBackColor = true;
            this.btnForward.Click += new System.EventHandler(this.btnForward_Click);

            // btnRefresh
            this.btnRefresh.Location = new System.Drawing.Point(130, 10);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(60, 23);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);

            // txtUrl
            this.txtUrl.Location = new System.Drawing.Point(200, 10);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(300, 20);
            this.txtUrl.TabIndex = 3;

            // btnGo
            this.btnGo.Location = new System.Drawing.Point(510, 10);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(40, 23);
            this.btnGo.TabIndex = 4;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);

            // webView21
            this.webView21.CreationProperties = null;
            this.webView21.Dock = DockStyle.Fill;
            this.webView21.Location = new System.Drawing.Point(0, 40);
            this.webView21.Name = "webView21";
            this.webView21.Size = new System.Drawing.Size(800, 410);
            this.webView21.TabIndex = 5;
            this.webView21.ZoomFactor = 1D;

            // MainForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.webView21);
            this.Controls.Add(this.toolbarPanel);
            this.Name = "MainForm";
            this.Text = "Kolupula Browser";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}
