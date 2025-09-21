using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClearVale
{
    public partial class Character : Form
    {
        private MainFrame mainFrame;
        List<(string name, string data)> configData = new List<(string name, string data)>();
        List<(string name, string charaImage, string gachaCharaImage, string rera, string get, string loginSerif, string useSerif, string nolmaSerif, string serif1, string serif2, string serif3, string Explanation)> characterData = new List<(string name, string charaImage, string gachaCharaImage, string rera, string get, string loginSerif, string useSerif, string nolmaSerif, string serif1, string serif2, string serif3, string Explanation)>();
        List<PictureBox> pictureBoxes = new List<PictureBox>();
        public Character(MainFrame mainFrame)
        {
            InitializeComponent();
            this.mainFrame = mainFrame;
        }

        private void Character_Load(object sender, EventArgs e)
        {
            configData = mainFrame.CONFIGDATA;
            characterData = mainFrame.CHARACTERDATA;
            int x = 60;
            int y = 330;
            for (int i = 1; i <= 25; i++)
            {
                PictureBox pictureBox = new PictureBox();
                pictureBox.Name = "pictureBox" + i.ToString();
                pictureBox.Click += new EventHandler(pictureBox_Click);
                pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox.BackgroundImageLayout = ImageLayout.Zoom;
                pictureBox.Location = new Point(x, y);
                pictureBox.BackColor = Color.White;
                x += 220;
                if (i % 5 == 0 && i != 1)
                {
                    x = 60;
                    y += 240;
                }
                pictureBox.Size = new Size(180, 180);
                pictureBox.BackgroundImage = Image.FromFile("ハテナ.png");

                panel1.Controls.Add(pictureBox);
                pictureBoxes.Add(pictureBox);

                if (i == 25)
                {
                    PictureBox p = new PictureBox();
                    p.Size = new Size(30, 30);
                    p.Location = new Point(x, y);
                    panel1.Controls.Add(p);
                }
                
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Character_VisibleChanged(object sender, EventArgs e)
        {
            // キャラクターをpictureBoxに表示
            if (this.Visible)
            {
                configData = mainFrame.CONFIGDATA;
                characterData = mainFrame.CHARACTERDATA;

                for(int i = 0; i < characterData.Count; i++)
                {
                    if (characterData[i].get == "1")
                    {
                        pictureBoxes[i].BackgroundImage = Image.FromFile(@characterData[i].gachaCharaImage);
                        if(i >= 5)
                        {
                            pictureBoxes[i].Image = Image.FromFile(@"Image File\frame\レア.png");
                        }
                        if (i >= 10)
                        {
                            pictureBoxes[i].Image = Image.FromFile(@"Image File\frame\ノーマル.png");
                        }
                    }
                }
                int n = int.Parse(configData[1].data) - 1;
                pictureBox_home.BackgroundImage = Image.FromFile(@characterData[n].gachaCharaImage);
                if (n - 1 >= 5)
                {
                    pictureBox_home.Image = Image.FromFile(@"Image File\frame\レア.png");
                }
                if (n - 1 >= 10)
                {
                    pictureBox_home.Image = Image.FromFile(@"Image File\frame\ノーマル.png");
                }
                label5.Text = characterData[n].Explanation;
            }
        }

        private void pictureBox_Click(object sender,EventArgs e)
        {
            string s = ((PictureBox)sender).Name;
            int n = int.Parse(s.Substring(10));
            if (characterData[n - 1].get == "1")
            {
                configData[1] = ("ホームキャラ", n.ToString());
                pictureBox_home.BackgroundImage = Image.FromFile(@characterData[n - 1].gachaCharaImage);
                if (n - 1 >= 5)
                {
                    pictureBox_home.Image = Image.FromFile(@"Image File\frame\レア.png");
                }
                if (n -1 >= 10)
                {
                    pictureBox_home.Image = Image.FromFile(@"Image File\frame\ノーマル.png");
                }
                label5.Text = characterData[n - 1].Explanation;
            }
            mainFrame.CONFIGDATA = configData;
        }

        Boolean homeCharacterSize = false;
        private void pictureBox_home_Click(object sender, EventArgs e)
        {
            if (homeCharacterSize)
            {
                pictureBox_home.Location = new Point(480, 45);
                pictureBox_home.Size = new Size(225, 225);
                label5.Visible = true;
                homeCharacterSize = false;
                panel1.AutoScroll = true;
            }
            else
            {
                pictureBox_home.Location = new Point(0, 0);
                pictureBox_home.Size = new Size(1250, 760);
                homeCharacterSize=true;
                label5.Visible = false;
                panel1.AutoScroll = false;
            }
        }
    }
}
