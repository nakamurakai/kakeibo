using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClearVale
{
    public partial class Form2 : Form
    {
        private MainFrame mainFrame;
        private DateTime setDate;
        private MonthCalendar calendar;

        public Form2(MainFrame mainFrame)
        {
            InitializeComponent();

            this.mainFrame = mainFrame;

            // 今日の日付を設定
            setDate = DateTime.Now;
            DateButton.Text = setDate.ToString("yyyy年 MM月 dd日");

            // 画像貼り付け
            AddButton.BackgroundImage = Image.FromFile(@"Image File\List\Add Icon.png");
            panel5.BackgroundImage = Image.FromFile(@"Image File\List\List Back Top.png");
            panel4.BackgroundImage = Image.FromFile(@"Image File\List\List Back Middle.png");
        }

        //** メソッド **//

        /// <summary>
        /// 入力した値の分だけ月を前後する
        /// </summary>
        private void ChangeDay(int num)
        {
            setDate = setDate.AddDays(num);

            ShowList();
        }

        /// <summary>
        /// パネルにリストを表示☆
        /// </summary>
        public void ShowList()
        {
            //日付の表示を変更
            DateButton.Text = setDate.ToString("yyyy年 MM月 dd日");

            // パネル内のコントロール削除
            for (int i = panel3.Controls.Count - 1; 0 <= i; i--)
            {
                panel3.Controls[i].Dispose();
            }

            // パネルリストを追加
            List<IEData> dataList = mainFrame.IEDatas;
            for (int i = dataList.Count - 1; 0 <= i; i--)
            {
                if (dataList[i].date.Date != setDate.Date) continue;

                var listPanel = new ListPanel(dataList[i]);
                listPanel.ContextMenuStrip = contextMenuStrip1;
                listPanel.Dock = DockStyle.Top;
                
                panel3.Controls.Add(listPanel);
            }
        }

        private void monthCalendar_DateSelected(object sender, DateRangeEventArgs e)
        {
            var mc = (MonthCalendar)sender;
            setDate = mc.SelectionStart;

            ShowList();
            mc.Visible = false;
        }

        //** クリックイベント **//

        // 日付をクリック
        private void DateButton_Click(object sender, EventArgs e)
        {
            if (calendar == null)
            {
                //カレンダーを開く
                calendar = new MonthCalendar();
                calendar.Location = new Point(457, 84);
                calendar.DateSelected += new DateRangeEventHandler(monthCalendar_DateSelected);
                this.Controls.Add(calendar);
                calendar.BringToFront();
            }
            else
            {
                //カレンダーを閉じる
                calendar.Visible = !calendar.Visible;
            } 
        }

        // 日付を１日進める
        private void Plus_button_Click(object sender, EventArgs e)
        {
            ChangeDay(1);
        }

        // 日付を1日戻す
        private void Minus_button_Click(object sender, EventArgs e)
        {
            ChangeDay(-1);
        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            mainFrame.OpenForm("Form3");
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            var ie = new IEData();
            ie.date = setDate;

            mainFrame.OpenInputScreen(ie, false);
        }

        //** ContextMenuStrip **//

        private void Menu_Click(object sender, EventArgs e)
        {
           
        }

        private void Edit_Click(object sender, EventArgs e)
        {
            //表示しているコントロールを取得する
            var source = (ListPanel)contextMenuStrip1.SourceControl;

            if (source != null)
            {
                mainFrame.OpenInputScreen(source.IEdata, true);
            }   
        }

        //削除処理を行う
        private void Delete_Click(object sender, EventArgs e)
        {
            //表示しているコントロールを取得する
            var source = (ListPanel)contextMenuStrip1.SourceControl;

            if (source != null)
            {
                source.Dispose();
                mainFrame.IEDatas.RemoveAll(x => x.ID == source.ID);

                var configData = mainFrame.CONFIGDATA;
                var ie = source.IEdata;

                //残高更新
                int data1 = int.Parse(configData[8].data);
                int data2 = ie.IorE == "収入" ? ie.amount : -ie.amount;

                configData[8] = ("残高", (data1 - data2).ToString());
            }
        }

        private void Form2_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible) ShowList();
        }
    }
}
