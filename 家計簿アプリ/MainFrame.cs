using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection.Emit;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml.Serialization;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ClearVale
{
    public partial class MainFrame : Form
    {
        private List<IEData> _IEDatas;
        private List<IEData> _FixedData;
        private Form[] FormArray;

        private DateTime today;
        private Form1 form1;
        private Form2 form2;
        private Form3 form3;
        private Form4 form4;
        private Calculator calculator;
        private InitialSetting initialSetting;
        private InputScreen input;
        private SettingForm settingForm;
        private Character character;

        List<(string name, string data)> configData = new List<(string name, string data)>();
        List<(string name, string charaImage, string gachaCharaImage, string rera, string get, string loginSerif, string useSerif, string nolmaSerif, string serif1, string serif2, string serif3, string Explanation)> characterData = new List<(string name, string charaImage, string gachaCharaImage, string rera, string get, string loginSerif, string useSerif, string nolmaSerif, string serif1, string serif2, string serif3, string Explanation)>();

        public List<(string name, string data)> CONFIGDATA { get { return configData; } set { configData = value; } }
        public List<(string name, string charaImage, string gachaCharaImage, string rera, string get, string loginSerif, string useSerif, string nolmaSerif, string serif1, string serif2, string serif3, string Explanation)> CHARACTERDATA { get { return characterData; } set { characterData = value; } }

        //** プロパティ **//
        public DateTime SetDate { get; set; }
        public List<IEData> IEDatas { get { return _IEDatas; } }
        public List<IEData> FixdData { get { return _FixedData; } }
        public List<CategoryButton> CB { get { return form1.CB; } }

        public MainFrame()
        {
            InitializeComponent();

            _IEDatas = new List<IEData>();
            _FixedData = new List<IEData>();
            today = DateTime.Now;

            //フォームの初期化
            form1 = new Form1(this);
            form2 = new Form2(this);
            form3 = new Form3(this);
            form4 = new Form4(this);
            initialSetting = new InitialSetting(this);
            character = new Character(this);


            FormArray = new Form[]
            {
                form1, form2, form3, form4, character
            };
            foreach (Form form in FormArray)
            {
                form.TopLevel = false;
                form.Dock = DockStyle.Fill;
                panel1.Controls.Add(form);
            }

            OpenForm("Form1");
            this.Text = "ホーム";

            // 設定値取得
            string[] values = new string[2];
            StreamReader sr = new StreamReader("ClearVale_Config.csv", Encoding.GetEncoding("shift_jis"));
            string line = sr.ReadLine();

            //設定値の読み込み
            while (sr.Peek() != -1)
            {
                line = sr.ReadLine();
                values = line.Split(',');
                configData.Add((values[0], values[1]));
            }
            sr.Close();

            LoadFile();

            // 初期設定を開く
            if (configData[3].data == "0")
            {
                initialSetting.ShowDialog();
            }

            // キャラクターデータの読み込み
            values = new string[11];
            sr = new StreamReader("Chara_information.csv", Encoding.GetEncoding("shift_jis"));
            line = sr.ReadLine();
            while (sr.Peek() != -1)
            {
                line = sr.ReadLine();
                values = line.Split(',');
                characterData.Add((values[0], values[1], values[2], values[3], values[4], values[5], values[6], values[7], values[8], values[9], values[10], values[11]));
            }
            sr.Close();


            // アイコン画像貼り付け
            button1.BackgroundImage = System.Drawing.Image.FromFile(@"Image File\Icon\Icon Home.png");
            button2.BackgroundImage = System.Drawing.Image.FromFile(@"Image File\Icon\Icon List.png");
            button3.BackgroundImage = System.Drawing.Image.FromFile(@"Image File\Icon\Icon Gatya.png");
            button4.BackgroundImage = System.Drawing.Image.FromFile(@"Image File\Icon\Icon Calculator.png");
            button5.BackgroundImage = System.Drawing.Image.FromFile(@"Image File\Icon\Icon Taxes.png");
            button6.BackgroundImage = System.Drawing.Image.FromFile(@"Image File\Icon\Icon Charcter.png");
            button7.BackgroundImage = System.Drawing.Image.FromFile(@"Image File\Icon\Icon Setting.png");
            Icon icon = new Icon(@"Image File\Icon.ico", 25, 25);
            this.Icon = icon;

            // フォームの設定
            this.Size = new Size(1348, 804);


        }

        private void MainFrame_Load(object sender, EventArgs e)
        {
            // 今日の日付を取得
            var dt = DateTime.Now;
            string day = dt.ToString("yyyy") + dt.ToString("MM") + dt.ToString("dd");
            int time = int.Parse(day);
                
            // 通算ログイン日の日付間隔
            int[] loginDay = new int[] { 7, 10, 20, 30, 40, 50, 60, 70, 80, 90, 100, 125, 150, 175, 200, 250, 300, 350, 365 };
            
            // ログインボーナス
            if (time > int.Parse(configData[2].data))
            {
                configData[2] = ("最終ログイン日", day);
                int n = int.Parse(configData[0].data); // コイン枚数
                int m = int.Parse(configData[9].data); // 通算ログイン日数
                n++;
                m++;
                configData[9] = ("通算ログイン日数", m.ToString());

                // 誕生日ボーナス
                if (day.Substring(4, 4) == configData[6].data.Substring(4, 4))
                {
                    n += 10;
                }

                // 通算ログイン
                for (int i = 0; i < loginDay.Length; i++)
                {
                    if (loginDay[i] == m)
                    {
                        n += 3;
                    }
                }

                configData[0] = ("コイン枚数", n.ToString());
            }
        }

        //** メソッド **//

        /// <summary>
        /// ファイル読み込み (ファイル → リスト)
        /// </summary>
        private void LoadFile()
        {
            var sr = new StreamReader("IEData.csv", Encoding.GetEncoding("shift_jis"));
            var line = new string[7];

            try
            {
                //読み込み
                while (sr.Peek() != -1)
                {
                    line = sr.ReadLine().Split(',');
                    if (line[0] == "-2") continue;

                    IEData ie = new IEData()
                    {
                        ID         = int.Parse(line[0]),
                        amount     = int.Parse(line[1]),
                        repetition = int.Parse(line[2]),
                        IorE       = line[3],
                        categry    = line[4],
                        memo       = line[5],
                        date       = DateTime.Parse(line[6]),
                    };

                    if (ie.repetition == 0)
                    {
                        _IEDatas.Add(ie);
                    }
                    else
                    {
                        _FixedData.Add(ie);
                        CheckFixedData(ie);
                    }
                }
                sr.Close(); 
            }
            catch
            {
                if (configData[3].data == "1")
                {
                    MessageBox.Show("ファイルの読み込みに失敗しました。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                sr.Close();
            }
        }

        /// <summary>
        /// ファイル書き込み (リスト → ファイル)
        /// </summary>
        private void WriteFile()
        {
            StreamWriter sw;
            
            try
            {
                //収入支出データ
                sw = new StreamWriter("IEData.csv", false, Encoding.GetEncoding("shift_jis"));
             
                foreach (var x in _IEDatas)
                {
                    sw.WriteLine(x.GetLine);
                }
                sw.WriteLine("-2");
                foreach (var x in _FixedData)
                {
                    sw.WriteLine(x.GetLine);
                }
                sw.Close();

                //初期設定データ
                configData.Insert(0, ("名称", "設定値"));
                sw = new StreamWriter("ClearVale_Config.csv", false, Encoding.GetEncoding("shift_jis"));
                for (int i = 0; i < configData.Count; i++)
                {
                    sw.WriteLine(String.Format("{0},{1}", configData[i].name, configData[i].data));
                }
                sw.Close();

                // キャラクターデータ
                characterData.Insert(0, ("キャラ名", "ガチャパス", "画像パス", "レア度", "入手(0:未入手 1:入手済)", "ログイン", "使いすぎ", "ノルマ", "セリフ1", "セリフ2", "セリフ3", "説明"));
                sw = new StreamWriter("Chara_information.csv", false, Encoding.GetEncoding("shift_jis"));
                for(int i = 0; i < characterData.Count; i++)
                {
                    sw.WriteLine(String.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11}", characterData[i].name, characterData[i].charaImage, characterData[i].gachaCharaImage, characterData[i].rera, characterData[i].get, characterData[i].loginSerif, characterData[i].useSerif, characterData[i].nolmaSerif, characterData[i].serif1, characterData[i].serif2, characterData[i].serif3, characterData[i].Explanation));
                }
                sw.Close();

                //カテゴリボタンを保存
                sw = new StreamWriter("Category data.txt");
                foreach (var cb in form1.CB)
                {
                    sw.WriteLine(String.Format("{0},{1}", cb.Text, cb.IorE));
                }
                sw.Close();
            }
            catch
            {
                MessageBox.Show("書き込みに失敗しました(MainFrame)", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 指定のフォームを開く☆
        /// </summary>
        public void OpenForm(string formName)
        {
            foreach (Form form in FormArray)
            {
                form.Visible = form.Name == formName;
            }
        }

        /// <summary>
        /// 入力画面を開く☆
        /// </summary>
        public void OpenInputScreen(IEData ie, bool EditMode)
        {
            input = new InputScreen(this, ie, EditMode);
            input.FormClosed += new FormClosedEventHandler(input_FormClosed);
            input.ShowDialog();
        }
            
        /// <summary>
        /// IEDdatasリストに追加☆
        /// </summary>
        public void AddList(IEData ie)
        {
            int makeID = 0;

            if (_IEDatas.Count > 0)
            {
                makeID = _IEDatas.Select(x => x.ID).Max();
            }

            //最大値のID + 1を新しいIDとして与える
            ie.ID = makeID + 1;
            ie.memo = DateTime.Now.ToString("T");

            if (ie.repetition == 0)
            {
                _IEDatas.Add(ie);

                //残高更新
                int data1 = int.Parse(configData[8].data);
                int data2 = ie.IorE == "収入" ? ie.amount : -ie.amount;

                configData[8] = ("残高", (data1 + data2).ToString());
            }
            else
            {
                _FixedData.Add(ie);
                CheckFixedData(ie);
            }
            
        }

        /// <summary>
        /// 固定入力データを調べる
        /// </summary>
        private void CheckFixedData(IEData x)
        {
            int rep = x.repetition;

            while (x.date.Date <= today.Date)
            {
                var kari = new IEData()
                {
                    ID = -1,
                    amount = x.amount,
                    repetition = 0,
                    IorE = x.IorE,
                    categry = x.categry,
                    memo = x.memo,
                    date = x.date
                };

                AddList(kari);

                if (rep == 1)
                {
                    x.date = x.date.AddDays(1);
                }
                else if (rep == 2)
                {
                    x.date = x.date.AddDays(8);
                }
                else if (rep == 3)
                {
                    x.date = x.date.AddMonths(1);
                }
            }
        }

        //** クリックイベント **/

        private void button1_Click(object sender, EventArgs e)
        {
            OpenForm("Form1");
            this.Text = "ホーム";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenForm("Form2");
            this.Text = "リスト";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenForm("Form3");
            this.Text = "ガチャ";
        }

        // 電卓
        private void button4_Click(object sender, EventArgs e)
        {
            if (calculator == null || calculator.IsDisposed)
            {
                calculator = new Calculator();
                calculator.Show();
            }
            else
            {
                calculator.Visible = !calculator.Visible;
            }
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            OpenForm("Form4");
            this.Text = "税金";
        }

        private void MainFrame_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 年齢更新
            DateTime birthday;
            string data = configData[6].data;

            if (DateTime.TryParse(data, out birthday))
            {
                int age = DateTime.Now.Year - birthday.Year;
                if (birthday > DateTime.Now.AddYears(-age)) age--;
                configData[5] = ("年齢", age.ToString());
            }

            WriteFile();
        }

        private void input_FormClosed(object sender, FormClosedEventArgs e)
        {
            IEDatas.Sort((a,b) => b.ID - a.ID);

            if (form1.Visible)
            {
                form1.CalculateTotal(SetDate);
            }
            else if (form2.Visible)
            {
                form2.ShowList();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (settingForm == null || settingForm.IsDisposed)
            {
                settingForm = new SettingForm(this);
                settingForm.Show();
            }
            else
            {
                settingForm.Visible = !settingForm.Visible;
            }
        }

        private void IntervalTimer_Tick(object sender, EventArgs e)
        {
            var now = DateTime.Now;

            if (today.Date != now) return;

            foreach (var x in _FixedData)
            {
                CheckFixedData(x);
            }

            today = now;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            OpenForm("Character");
            this.Text = "キャラ";
        }
    }

    /// <summary>
    /// 収入・支出のデータ
    /// </summary>
    public class IEData
    {
        public int ID;          //ID
        public int amount;      //金額
        public int repetition;  //繰り返し (0:なし 1毎日 2:毎週 3:毎月)
        public string IorE;     //収入 or 支出
        public string categry;  //カテゴリ
        public string memo;     //メモ
        public DateTime date;   //日付

        public int Target{ get{ return int.Parse(date.ToString("yyMMdd")); } }

        public string GetLine { get { return String.Format("{0},{1},{2},{3},{4},{5},{6}", ID, amount, repetition, IorE, categry, memo, date); } }

        public IEData()
        {
            ID = -1;
            amount = 0;
        }
    }
}
