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
using System.Windows.Forms.DataVisualization.Charting;
using System.Xml.Serialization;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace ClearVale
{
    public partial class Form1 : Form
    {
        //** フィールド **//
        private MainFrame mainFrame;
        private DateTime setDate;
        private List<CategoryButton> categoryButtons; //カテゴリボタンを格納             
        private List<SumData> sumArray;               //月ごとの合計値を格納
        private string[] charData = new string[6];
        private SumData theMonth;
        
        // 設定値
        List<(string name, string data)> configData = new List<(string name, string data)>();
        // キャラクターデータ
        List<(string name, string charaImage, string gachaCharaImage, string rera, string get, string loginSerif, string useSerif, string nolmaSerif, string serif1, string serif2, string serif3, string Explanation)> characterData = new List<(string name, string charaImage, string gachaCharaImage, string rera, string get, string loginSerif, string useSerif, string nolmaSerif, string serif1, string serif2, string serif3, string Explanation)>();
        public List<CategoryButton> CB { get { return categoryButtons; } }

        public Form1(MainFrame mainFrame)
        {
            InitializeComponent();

            this.mainFrame = mainFrame;
            categoryButtons = new List<CategoryButton>();
            sumArray = new List<SumData>();

            //今日の日付を設定
            setDate = DateTime.Now;
            mainFrame.SetDate = setDate;

            //カテゴリボタン読み込み
            var sr = new StreamReader("Category data.txt", Encoding.GetEncoding("UTF-8"));
            string[] line = new string[2];

            while (sr.Peek() != -1)
            {
                line = sr.ReadLine().Split(',');
                AddCategoryButton(line[0], line[1]);
            }
            sr.Close();

            // panelにイメージ画像貼り付け
            panel10.BackgroundImage = Image.FromFile(@"Image File\Home Back Image\Home Back Top.png");
            panel11.BackgroundImage = Image.FromFile(@"Image File\Home Back Image\Home Back Middle.png");
            panel12.BackgroundImage = Image.FromFile(@"Image File\Home Back Image\Home Back  Under.png");
            panel13.BackgroundImage = Image.FromFile(@"Image File\Home Back Image\Home Back Right.png");
            panel1.BackgroundImage = Image.FromFile(@"Image File\吹き出し.png");

            // フォームの設定
            this.Size = new Size(1249, 757);
        }

        //** メソッド **//

        /// <summary>
        /// 入力した値の分だけ月を前後する
        /// </summary>
        private void ChangeDate(int num)
        {
            setDate = setDate.AddMonths(num);
            Date_label.Text = setDate.ToString("yyyy年 MM月");
            mainFrame.SetDate = setDate;

            //計算
            CalculateTotal(setDate);
        }

        /// <summary>
        /// 収入・支出・収支を計算☆
        /// </summary>
        /// 
        public SumData CalculateTotal(DateTime date)
        {
            var inc = new List<Data>(); // 収入データ
            var exp = new List<Data>(); // 支出データ

            var total = new SumData();
            total.date = date;
            bool flag;

            foreach (var ie in mainFrame.IEDatas)
            {
                if (ie.date.ToString("yyMM") != date.ToString("yyMM")) continue;
                flag =true;

                if (ie.IorE == "収入")
                {
                    total.Income += ie.amount;

                    foreach (var x in inc)
                    {
                        if (x.categry != ie.categry) continue;

                        x.num += ie.amount;
                        flag = false;
                        break;
                    }

                    if (flag)
                    {
                        var data = new Data();
                        data.categry = ie.categry;
                        data.num = ie.amount;

                        inc.Add(data);
                    }
                }
                else
                {
                    total.Expenditure += ie.amount;
                    
                    foreach (var x in exp)
                    {
                        if (x.categry != ie.categry) continue;

                        x.num += ie.amount;
                        flag = false;
                        break;
                    }

                    if (flag)
                    {
                        var data = new Data();
                        data.categry = ie.categry;
                        data.num = ie.amount;

                        exp.Add(data);
                    }
                }
            }

            total.Balance = total.Income - total.Expenditure;

            label2.Text = String.Format("{0:c}", total.Income);
            label3.Text = String.Format("{0:c}", total.Expenditure);
            label5.Text = String.Format("{0:c}", total.Balance);

            ShowChart(chart1, inc);
            ShowChart(chart2, exp);
            inc.Clear();
            exp.Clear();

            return total;
        }

        /// <summary>
        /// チャートを表示
        /// </summary>
        private void ShowChart(Chart chart, List<Data> data)
        {
            chart.Series.Clear();
            chart.Legends.Clear();

            //Add a new Legend(if needed) and do some formating
            chart.Legends.Add("MyLegend");
            chart.Legends[0].LegendStyle = LegendStyle.Table;
            chart.Legends[0].Docking = Docking.Right;
            chart.Legends[0].Alignment = StringAlignment.Near;
            chart.Legends[0].BackGradientStyle = GradientStyle.None;
            chart.Legends[0].Font = new Font("メイリオ", 9);
            //chart.Legends[0].Title = "カテゴリ";
            //chart.Legends[0].BorderColor = Color.Black;

            //Add a new chart-series
            string seriesname = "MySeriesName";
            chart.Series.Add(seriesname);
            //set the chart-type to "Pie"
            chart.Series[seriesname].ChartType = SeriesChartType.Doughnut;

            foreach (var x in data)
            {
                chart.Series[seriesname].Points.AddXY(x.categry, x.num.ToString());
            }
        }

        /// <summary>
        /// CategoryButtonを追加☆
        /// </summary>
        public void AddCategoryButton(string name, string IorE)
        {
            var categoryButton = new CategoryButton();
            categoryButton.Click += new EventHandler(categoryButton_Click);
            categoryButton.ContextMenuStrip = contextMenuStrip1;
            categoryButton.Text = name;
            categoryButton.IorE = IorE;
            categoryButton.LineColor = Color.FromArgb(229, 229, 229);
            categoryButton.Visible = IorE.Equals(customSwitch1.IorE);
            categoryButton.Dock = DockStyle.Top;

            panel9.Controls.Add(categoryButton);
            categoryButtons.Add(categoryButton);
            categoryButton.BringToFront();
        }

        private void LoadData()
        {
            // ホームキャラの設定
            // 今日の日付を取得
            var dt = DateTime.Now;
            string day = dt.ToString("yyyy") + dt.ToString("MM") + dt.ToString("dd");
            int time = int.Parse(day);

            // 月末を求める
            int days = DateTime.DaysInMonth(dt.Year, dt.Month); // その月の日数
            var lastDay = new DateTime(dt.Year, dt.Month, days);
            Console.WriteLine("{0}年{1}月の最後の日は {2}",
                              dt.Year, dt.Month, lastDay.ToString());

            theMonth = CalculateTotal(dt);

            configData = mainFrame.CONFIGDATA;
            characterData = mainFrame.CHARACTERDATA;

            int n = int.Parse(configData[1].data) - 1;
            pictureBox1.Image = Image.FromFile(@characterData[n].charaImage);

            charData[0] = characterData[n].loginSerif;
            charData[1] = characterData[n].nolmaSerif;
            charData[2] = characterData[n].useSerif;
            charData[3] = characterData[n].serif1;
            charData[4] = characterData[n].serif2;
            charData[5] = characterData[n].serif3;

            
            if (time > int.Parse(configData[2].data))
            {
                label8.Text = charData[0];
            }
            else if (dt.Date == lastDay.Date)
            {
                if (theMonth.Balance < int.Parse(configData[10].data))
                {
                    label8.Text = charData[1];

                    // コインもらう
                    if (time > int.Parse(configData[2].data))
                    {
                        int koin = int.Parse(configData[0].data); // コイン枚数
                        koin += 3;
                        configData[0] = ("コイン枚数", koin.ToString());
                    }
                }
            }
            else
            {
                label8.Text = charData[3];
            }
        }

        //** ボタンイベント **//

        //日付を１ヶ月進める
        private void Plus_button_Click(object sender, EventArgs e)
        {
            ChangeDate(1);
        }

        //日付を１ヶ月戻す
        private void Minus_button_Click(object sender, EventArgs e)
        {
            ChangeDate(-1);
        }
      
        //収入・支出を切り替える
        private void customSwitch1_Click(object sender, EventArgs e)
        {
            foreach(var cp in categoryButtons)
            {
                cp.Visible = !cp.Visible;
            }
        }

        //カテゴリ追加画面を開く
        private void customButton1_Click(object sender, EventArgs e)
        {           
            var addCategory = new AddCategory(this, false);
            addCategory.IE = customSwitch1.Selected;
            addCategory.ShowDialog();
        }

        //入力画面を開く
        private void categoryButton_Click(object sender, EventArgs g)
        {
            var cb = (CategoryButton)sender;
            var ie = new IEData();

            ie.IorE = customSwitch1.IorE;
            ie.categry = cb.Text;
            ie.date = setDate;

            mainFrame.OpenInputScreen(ie, false);
        }

        //** ContextMenuStrip **//

        //編集画面を開く
        private void Edit_Click(object sender, EventArgs e)
        {
            //表示しているコントロールを取得する
            Control source = contextMenuStrip1.SourceControl;

            if (source != null)
            {
                var addCategory = new AddCategory(this, true);
                addCategory.IE = customSwitch1.Selected;
                addCategory.CategoryName = source.Text;
                addCategory.ShowDialog();
            }
        }

        //削除処理を行う
        private void Delete_Click(object sender, EventArgs e)
        {
            //表示しているコントロールを取得する
            Control source = contextMenuStrip1.SourceControl;

            if (source != null)
            {
                source.Dispose();
                categoryButtons.RemoveAll(x => x.Text == source.Text);
            } 
        }

        private void Form1_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                CalculateTotal(setDate);
                ChangeDate(0);
                LoadData();
            }
        }

        private void pictureBox1_VisibleChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            serifTimer.Enabled = true;
        }

        private void serifTimer_Tick(object sender, EventArgs e)
        {
            var rand = new Random();
            int idx = 0;

            if (theMonth.Balance >= 0)
            {
                idx = rand.Next(2, 6);
            }
            else
            {
                idx = rand.Next(3, 6);
            }

            label8.Text = charData[0];
        }
    }

    /// <summary>
    /// 収入・支出・収支データを保存
    /// </summary>
    public class SumData
    {
        public DateTime date;  //日付

        public int Income;     //収入
        public int Expenditure;//支出
        public int Balance;    //収支

        public SumData()
        {
            Income = 0;
            Expenditure = 0;
            Balance = 0;
        }
    }

    public class Data
    {
        public string categry;
        public int num;
    }
}
