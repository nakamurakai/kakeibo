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
    public partial class CustomSwitch : Button
    {
        private bool _Selected;
        private Color _MainColor;
        private Color _SubColor;

        //プロパティ
        public Color MainColor { get { return _MainColor; } set { _MainColor = value; Switch(); } }
        public Color SubColor { get { return _SubColor; } set { _SubColor = value; Switch(); } }
        public bool Selected { get { return _Selected; } set { _Selected = value; Switch(); } }
        public string IorE  { get { return _Selected ? "収入" : "支出"; } }

        //オーバーライド
        //public override Color BackColor { get { return _BackColor; } set { _BackColor = value; Switch(); } }
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public override string Text { get => base.Text; set => base.Text = value; }

        public CustomSwitch()
        {
            InitializeComponent();
        }

        //メソッド
        private void Switch()
        {
            int width = this.Width - 2;
            int height = this.Height - 2;
            int xPos = width / 2;
            int yPos = height / 2;
            int center = width / 2;

            Bitmap canvas = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(canvas);

            this.Image = null;

            //(アンチエイリアス処理されたレタリング)を指定する
            g.SmoothingMode = SmoothingMode.AntiAlias;

            //Penの作成
            Pen backPen = new Pen(_SubColor, height);
            Pen frontPen = new Pen(_MainColor, height - 10);

            //始点と終点を丸める
            backPen.StartCap = LineCap.Round;
            backPen.EndCap = LineCap.Round;
            frontPen.StartCap = LineCap.Round;
            frontPen.EndCap = LineCap.Round;

            //線を書く
            g.DrawLine(backPen, yPos, yPos, width - yPos, yPos);

            if (_Selected)
            {
                g.DrawLine(frontPen, yPos, yPos, xPos - yPos, yPos);
            }
            else
            {
                g.DrawLine(frontPen, xPos + yPos, yPos, width - yPos, yPos);
            }

            // フォントオブジェクトの生成.
            StringFormat strFmt = new StringFormat();
            strFmt.Alignment = StringAlignment.Center; // X軸中央揃え.
            strFmt.LineAlignment = StringAlignment.Center; // Y軸中央揃え.

            Font font = new Font("メイリオ", 12);

            ////文字列を表示
            g.DrawString("収入", font, Brushes.Black, xPos / 2, yPos + 3, strFmt);
            g.DrawString("支出", font, Brushes.Black, xPos * 1.5f, yPos + 3, strFmt);

            //リソースを解放する
            backPen.Dispose();
            font.Dispose();
            g.Dispose();

            //PictureBox1に表示する
            this.Image = canvas;
        }

        private void CustomSwitch_SizeChanged(object sender, EventArgs e)
        {
            Switch();
        }

        private void CustomSwitch_Click(object sender, EventArgs e)
        {
            Selected = !Selected;
        }
    }
}
