using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace KolupulaBrowser
{
    public class RoundedTextBox : TextBox
    {
        private int _cornerRadius = 10;

        public int CornerRadius
        {
            get => _cornerRadius;
            set
            {
                _cornerRadius = value;
                UpdateRegion();
            }
        }

        public RoundedTextBox()
        {
            this.BorderStyle = BorderStyle.None; // Remove default border
            this.Padding = new Padding(5);      // Add padding for better appearance
            this.BackColor = Color.White;       // Default background color
            this.ForeColor = Color.Black;       // Default text color
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            UpdateRegion();
        }

        private void UpdateRegion()
        {
            var path = new GraphicsPath();
            int radius = _cornerRadius;
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(Width - radius, 0, radius, radius, 270, 90);
            path.AddArc(Width - radius, Height - radius, radius, radius, 0, 90);
            path.AddArc(0, Height - radius, radius, radius, 90, 90);
            path.CloseFigure();

            this.Region = new Region(path);
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);
            using (var brush = new SolidBrush(this.BackColor))
            {
                e.Graphics.FillRegion(brush, this.Region);
            }
        }
    }
}
