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
    public partial class DataBar : UserControl
    {
        private const int barSize = 25;

        private int _Numerator = 40;
        private int _Denominator = 100;

        [Category("Custom properties")]
        public string Label { get { return label1.Text; } set { label1.Text = value; } }
        [Category("Custom properties")]
        public int Numerator { get { return _Numerator; } set { _Numerator = Math.Min(Math.Max(value, 0), _Denominator); ShowBar(); } }
        [Category("Custom properties")]
        public int Denominator { get { return _Denominator; } set { _Denominator = value; ShowBar(); } }

        public DataBar()
        {
            InitializeComponent();
        }

        /// <summary>
        /// データバーを表示
        /// </summary>
        private void ShowBar()
        {
            int width = pictureBox1.Width;
            int height = pictureBox1.Height;
            int yPos = height / 2;

            Bitmap canvas = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(canvas);

            double percent = (double)_Numerator / _Denominator;
            int barWidth = (int)((width - barSize * 2) * percent);
            label2.Text = String.Format("{0:f0}%", percent * 100);


            pictureBox1.Image = null;

            //(アンチエイリアス処理されたレタリング)を指定する
            g.SmoothingMode = SmoothingMode.AntiAlias;

            //Penの作成
            Pen mainPen = new Pen(Color.FromArgb(203, 203, 203), barSize);
            Pen subPen = new Pen(Color.FromArgb(143, 143, 143), barSize);

            //始点と終点を丸める
            mainPen.StartCap = LineCap.Round;
            mainPen.EndCap = LineCap.Round;
            subPen.StartCap = LineCap.Round;
            subPen.EndCap = LineCap.Round;

            //線を書く
            g.DrawLine(mainPen, barSize, yPos, width - barSize, yPos);
            g.DrawLine(subPen, barSize, yPos, barSize + barWidth, yPos);

            //リソースを解放する
            mainPen.Dispose();
            subPen.Dispose();
            g.Dispose();

            //PictureBox1に表示する
            pictureBox1.Image = canvas;
        }

        private void DataBar_SizeChanged(object sender, EventArgs e)
        {
            ShowBar();
        }
    }
}
