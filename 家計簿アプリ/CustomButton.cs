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
    public partial class CustomButton : Button
    {
        private Color _color = Color.FromArgb(203, 203, 203);
        private Color _PushColor = Color.FromArgb(203, 203, 203);

        //プロパティ
        public Color Color { get { return _color; } set { _color = value; Draw(); } }

        public CustomButton()
        {
            InitializeComponent();
            Draw();
        }

        private void Draw()
        {
            int width = this.Width - 2;
            int height = this.Height - 2;
            int yPos = height / 2;
            Bitmap canvas = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(canvas);

            this.Image = null;

            //(アンチエイリアス処理されたレタリング)を指定する
            g.SmoothingMode = SmoothingMode.AntiAlias;

            //Penの作成
            Pen backPen = new Pen(_color, height);

            //始点と終点を丸める
            backPen.StartCap = LineCap.Round;
            backPen.EndCap = LineCap.Round;

            //線を書く
            g.DrawLine(backPen, yPos, yPos, width - yPos - 2, yPos);

            //リソースを解放する
            backPen.Dispose();
            g.Dispose();

            //PictureBox1に表示する
            this.Image = canvas;
        }

        private void CustomButton_SizeChanged(object sender, EventArgs e)
        {
            Draw();
        }

        private void CustomButton_KeyDown(object sender, KeyEventArgs e)
        {

        }
    }
}
