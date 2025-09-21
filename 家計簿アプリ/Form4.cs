using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ClearVale
{
    public partial class Form4 : Form
    {
        private MainFrame mainFrame;
        double hokenryou = 0;
        double syotokuzei = 0;
        double tedori = 0;
        double incomeRate = 0; // 所得税率

        List<(string name, string data)> configData = new List<(string name, string data)>();

        public Form4(MainFrame mainFrame)
        {
            InitializeComponent();
            this.mainFrame = mainFrame;

            configData = mainFrame.CONFIGDATA;
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            label13.Text = configData[5].data + "歳"; // 年齢
            label14.Text = configData[7].data;        // 居住地

        }

        //** メソッド **//

        private void hoken(double money, int age, int k)
        {
            int[] hhg = new int[] { 58000, 68000, 78000, 88000, 98000, 104000, 110000, 118000, 126000, 134000, 142000, 150000, 160000, 170000, 180000, 190000, 200000, 220000, 240000, 260000, 280000, 300000, 320000, 340000, 360000, 380000, 410000, 440000, 470000, 500000, 530000, 560000, 590000, 620000, 650000, 680000, 710000, 750000, 790000, 830000, 880000, 930000, 980000, 1030000, 1090000, 1150000, 1210000, 1270000, 1330000, 1390000 };
            int[] hg = new int[] { 63000, 73000, 83000, 93000, 101000, 107000, 114000, 122000, 130000, 138000, 146000, 155000, 165000, 175000, 185000, 195000, 210000, 230000, 250000, 270000, 290000, 310000, 330000, 350000, 370000, 395000, 425000, 455000, 485000, 515000, 545000, 575000, 605000, 635000, 665000, 695000, 730000, 770000, 810000, 855000, 905000, 955000, 1005000, 1055000, 1115000, 1175000, 1235000, 1295000, 1355000 };
            double[] ken = new double[47] { 10.39, 10.03, 9.91, 10.18, 10.27, 9.99, 9.65, 9.77, 9.90, 9.73, 9.71, 9.76, 9.81, 9.85, 9.51, 9.61, 9.89, 9.96, 9.66, 9.67, 9.82, 9.75, 9.93, 9.91, 9.83, 9.95, 10.22, 10.13, 9.96, 10.18, 9.94, 10.35, 10.25, 10.09, 10.15, 10.43, 10.34, 10.26, 10.30, 10.21, 11, 10.47, 10.45, 10.52, 10.14, 10.65, 10.09 };
            double kaigo = 0.0164;
            double kouseinenkin = 0.183;
            double koyouhoken = 0.005;
            int i;
            double a = 0; // 健康保険料
            double b = 0; // 厚生年金
            double c = 0; // 介護保険
            double d = 0; // 雇用保険

            for (i = 0; i < hg.Length; i++)
            {
                if (money < hg[i]) break;
            }

            a = Math.Floor((hhg[i] * (ken[k] / 100) / 2) / 10) * 10;

            if (i < 3) i = 3;
            b = hhg[i] * kouseinenkin / 2;

            if (money >= 635000) b = 59475;

            if (age == 1)
            {
                c = hhg[i] * kaigo / 2;
            }
            d = money * koyouhoken;
            hokenryou = a + b + c + d;
            label2.Text = string.Format("{0:#,0}円", a);
            label3.Text = string.Format("{0:#,0}円", b);
            label4.Text = string.Format("{0:#,0}円", c);
            label5.Text = string.Format("{0:#,0}円", d);

            tedori -= hokenryou;
        }

        private void syotoku(double money)
        {
            string[] data = new string[9];
            double n = (money - hokenryou) * 12;


            if (n < 1000)
            {
                syotokuzei = 0;
            }
            else if (n >= 1000 && n < 1950000)
            {
                incomeRate = 0.05;
                syotokuzei = n * incomeRate;
            }
            else if (n < 3300000)
            {
                incomeRate = 0.1;
                syotokuzei = n * incomeRate - 97500;
            }
            else if (n < 6950000)
            {
                incomeRate = 0.2;
                syotokuzei = n * incomeRate - 427500;
            }
            else if (n < 9000000)
            {
                incomeRate = 0.23;
                syotokuzei = n * incomeRate - 636000;
            }
            else if (n < 18000000)
            {
                incomeRate = 0.33;
                syotokuzei = n * incomeRate - 1536000;
            }
            else if (n < 40000000)
            {
                incomeRate = 0.4;
                syotokuzei = n * incomeRate - 2796000;
            }
            else
            {
                incomeRate = 0.45;
                syotokuzei = n * incomeRate - 4796000;
            }
            syotokuzei /= 24;
            label8.Text = string.Format("{0:#,0}円", syotokuzei);
            tedori -= syotokuzei;
        }

        private void zyuuminzei(double money)
        {
            double Kkouzyo, Skouzyo, n;

            money = money * 12;
            if (money < 550000) Kkouzyo = money;
            else if (money < 1625000) Kkouzyo = 550000;
            else if (money < 1800000) Kkouzyo = money * 0.4 - 100000;
            else if (money < 3600000) Kkouzyo = money * 0.3 + 80000;
            else if (money < 6600000) Kkouzyo = money * 0.2 + 440000;
            else if (money < 8500000) Kkouzyo = money * 0.1 + 1100000;
            else Kkouzyo = 1950000;
            Skouzyo = hokenryou * 12;
            n = Kkouzyo + Skouzyo + 430000;
            n = money - n;
            n = (int)((n * 0.1 + 5000 - 2500) / 24);
            label9.Text = string.Format("{0:#,0}円", n);
            tedori -= n;
        }

        //** イベント **//

        private void Form4_VisibleChanged(object sender, EventArgs e)
        {
            this.ActiveControl = this.textBox1;
            label13.Text = configData[5].data + "歳"; // 年齢
            label14.Text = configData[7].data;        // 居住地
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string[] zenkoku = new string[47]
            {
                "北海道","青森","岩手","宮城","秋田","山形","福島","茨城","栃木","群馬",
                "埼玉","千葉","東京","神奈川","新潟","富山","石川","福井","山梨","長野",
                "岐阜","静岡","愛知","三重","滋賀","京都","大阪","兵庫","奈良","和歌山",
                "鳥取","島根","岡山","広島","山口","徳島","香川","愛媛","高知","福岡",
                "佐賀","長崎","熊本","大分","宮崎","鹿児島","沖縄"
            };
            double money = double.Parse(textBox1.Text);
            int age = int.Parse(configData[5].data);
            string ken = configData[7].data;
            int k = 0;
            for (int i = 0; i < 47; i++)
            {
                if (zenkoku[i] == ken) k = i;
            }

            tedori = money;
            hoken(money, age, k);
            syotoku(money);
            zyuuminzei(money);
            label6.Text = string.Format("{0:#,0}円", hokenryou);
            label10.Text = string.Format("{0:#,0}円", tedori);
            string data = "kd12345678@st";
            label18.Text = data.Substring(2, 8);
            this.ActiveControl = this.textBox1;

        }

        private void hurusato(double money)
        {
            double n = money * 12 * 0.85;
            double rate;
            if(n <= 1950000)
            {
                rate = 0.23559;
            }
            else if(n <= 3300000)
            {
                rate = 0.25066;
            }
            else if (n <= 6950000)
            {
                rate = 0.28744;
            }
            else if (n <= 9000000)
            {
                rate = 0.30068;
            }
            else if (n <= 18000000)
            {
                rate = 0.3552;
            }
            else if (n <= 40000000)
            {
                rate = 0.40683;
            }
            else
            {
                rate = 0.45398;
            }

            n = n * 0.1 * rate;
            n = Math.Floor(n / 1000) * 1000;
            label17.Text = string.Format("{0:#,0}円", n + 2000);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\b') return;
            if (e.KeyChar < '0' || e.KeyChar > '9') e.Handled = true;
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            // コンマ付きの数字に変換
            string data = textBox1.Text;
            if (data == "") data = "0";
            textBox1.Text = String.Format("{0:#,0}", int.Parse(data.Replace(",", "")));
            // フォーカスが一番右に来る
            textBox1.Select(textBox1.Text.Length, 0);
            textBox1.Focus();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] n = new string[18]{"8,000円","15,000円","21,000円","28,000円","34,000円","43,000円","53,000円","61,000円","70,000円","77,000円","98,000円","109,000円","120,000円","131,000円","141,000円","153,000円","165,000円","177,000円"};
            int idx = comboBox1.SelectedIndex;
            textBox2.Text = comboBox1.SelectedItem.ToString();
            label17.Text = "約" + n[idx];
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            comboBox1.DroppedDown = true;
        }
    }
}
