using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClearVale
{
    public partial class CustomPanel : Panel
    {
        private Graphics g;
        private Pen p;

        //** プロパティ **//
        public int PenSize { get; set; }
        public Color LineColor { get; set; }

        public CustomPanel()
        {
            InitializeComponent();

            Set();
        }

        //** メソッド **//

        private void Set()
        {
            this.BackgroundImage = new Bitmap(this.Width, this.Height);
            g = Graphics.FromImage(this.BackgroundImage);

            g.SmoothingMode = SmoothingMode.AntiAlias;

            Drawing();
        }

        private void Drawing()
        {
            int yPos = this.Height - PenSize / 2 - 1;
            int margin = PenSize / 2 + 2;

            p = new Pen(LineColor, PenSize);
            p.StartCap = LineCap.Round;
            p.EndCap = LineCap.Round;
            g.DrawLine(p, margin, yPos, this.Width - margin, yPos);

            p.Dispose();
        }

        //** イベント **//
        private void CustomPanel_SizeChanged(object sender, EventArgs e)
        {
            Set();
        }
    }
}
