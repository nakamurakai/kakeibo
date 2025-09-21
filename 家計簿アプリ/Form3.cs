using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClearVale
{
    public partial class Form3 : Form
    {
        private MainFrame mainFrame;
        List<(string name, string data)> configData = new List<(string name, string data)>();
        List<(string name, string charaImage, string gachaCharaImage, string rera, string get, string loginSerif, string useSerif, string nolmaSerif, string serif1, string serif2, string serif3, string Explanation)> characterData = new List<(string name, string charaImage, string gachaCharaImage, string rera, string get, string loginSerif, string useSerif, string nolmaSerif, string serif1, string serif2, string serif3, string Explanation)>();
        int time = 0;
        // ガチャの残りの回せる回数
        int numberOfTime;

        public Form3(MainFrame mainFrame)
        {
            InitializeComponent();

            this.mainFrame = mainFrame;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            // アニメーションgifの設定
            pictureBox1.Image = Image.FromFile("gacha_Directing.gif");
            pictureBox1.Enabled = false;

            gacha_timer.Enabled = false;

            //メダル枚数取得
            configData = mainFrame.CONFIGDATA;
            numberOfTime = int.Parse(configData[0].data);
            label1.Text = numberOfTime + "枚";

            pictureBox2.Image = Image.FromFile(@"Image File\豚コイン.png");
            this.BackgroundImage = Image.FromFile(@"Image File\ガチャ背景.png");
            panel1.BackgroundImage = Image.FromFile(@"Image File\frame\ガチャフレーム 2.png");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Enabled == false)
            {
                pictureBox1.Image = Image.FromFile("gacha_Directing.gif");
            }
            if (numberOfTime == 0)
            {
                MessageBox.Show("コインが足りません");
            }
            else
            {
                button1.Visible = false;
                gacha_timer.Enabled = true;
                pictureBox1.Enabled = true;
                numberOfTime--;
                label1.Text = numberOfTime + "枚";
                configData[0] = ("メダル枚数", numberOfTime.ToString());
                mainFrame.CONFIGDATA = configData;
            }
        }

        private void gacha_timer_Tick(object sender, EventArgs e)
        {
            time++;
            if (time == 19)
            {
                characterData = mainFrame.CHARACTERDATA;

                // ガチャの排出確率
                Random r = new Random();
                int n = r.Next(0, 100);
                if (n >= 0 && n < 3)
                {
                    n = r.Next(0, 3);
                    pictureBox1.Image = Image.FromFile(characterData[n].gachaCharaImage);
                }
                else if (n >= 3 && n < 23)
                {
                    n = r.Next(5, 9);
                    pictureBox1.Image = Image.FromFile(characterData[n].gachaCharaImage);
                }
                else
                {
                    n = r.Next(10, 24);
                    pictureBox1.Image = Image.FromFile(characterData[n].gachaCharaImage);
                }
                characterData[n] = (characterData[n].name, characterData[n].charaImage, characterData[n].gachaCharaImage, characterData[n].rera, "1", characterData[n].loginSerif, characterData[n].useSerif, characterData[n].nolmaSerif, characterData[n].serif1, characterData[n].serif2, characterData[n].serif3, characterData[n].Explanation);
                mainFrame.CHARACTERDATA = characterData;
                time = 0;
                button1.Visible = true;
                gacha_timer.Enabled = false;
                pictureBox1.Enabled = false;

            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile("gacha_Directing.gif");
        }

        private void Form3_VisibleChanged(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile("gacha_Directing.gif");
        }
    }
}
