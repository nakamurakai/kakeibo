using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ClearVale
{
    public partial class SettingForm : Form
    {

        private MainFrame mainFrame;
        List<(string name, string data)> configData = new List<(string name, string data)>();
        public SettingForm(MainFrame mainFrame)
        {
            InitializeComponent();
            this.Anchor = AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Bottom;
            this.mainFrame = mainFrame;
            textBox7.ReadOnly = true;
            Icon icon = new Icon(@"Image File\Icon.ico", 25, 25);
            this.Icon = icon;
        }

        //** メソッド **//

        public void ShowList()
        {
            // パネル内のコントロール削除
            for (int i = panel1.Controls.Count - 1; 0 <= i; i--)
            {
                panel1.Controls[i].Dispose();
            }

            foreach (var x in mainFrame.FixdData)
            {
                var listPanel = new ListPanel(x);
                listPanel.Dock = DockStyle.Top;
                listPanel.ContextMenuStrip = contextMenuStrip1;

                panel1.Controls.Add(listPanel);
            }
        }

        //** イベント **//

        private void SettingForm_VisibleChanged(object sender, EventArgs e)
        {
            // データを表示
            configData = mainFrame.CONFIGDATA;

            textBox7.Text = configData[7].data;
            comboBox1.Text = configData[7].data;
            comboBox1.MaxDropDownItems = 10;
            comboBox1.IntegralHeight = false;

            textBox1.Text = configData[4].data;
            textBox2.Text = configData[8].data;
            textBox6.Text = configData[10].data;
            string birthday = configData[6].data;
            textBox3.Text = birthday.Substring(0, 4);
            textBox4.Text = birthday.Substring(4, 2);
            textBox5.Text = birthday.Substring(birthday.Length - 2);
            label15.Text = configData[9].data + "日";

            //自動入力データ表示
            if (this.Visible == false) return;
            ShowList();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            // ユーザ名登録

            string userName = textBox1.Text;
            if (userName == "")
            {
                MessageBox.Show("ユーザ名を入力してください");
                return;
            }
            configData[4] = ("ユーザ名", userName);

            // 生年月日・年齢のチェック、登録

            DateTime birthday;
            string data = textBox3.Text + "/" + textBox4.Text + "/" + textBox5.Text;

            if (DateTime.TryParse(data, out birthday))
            {
                int age = DateTime.Now.Year - birthday.Year;
                if (birthday > DateTime.Now.AddYears(-age)) age--;

                if (age < 0 || age > 65)
                {
                    MessageBox.Show("生年月日の数値が間違っています");
                    return;
                }
                configData[5] = ("年齢", age.ToString());
                data = birthday.ToString("yyyy") + birthday.ToString("MM") + birthday.ToString("dd");
                configData[6] = ("生年月日", data);
            }
            else
            {
                MessageBox.Show("生年月日の数値が間違っています");
                return;
            }

            // 居住地登録
            configData[7] = ("居住地", textBox7.Text);

            // 残高登録
            configData[8] = ("残高", textBox2.Text.Replace(",", ""));

            // 月間支出目標額登録
            configData[10] = ("月間支出目標額", textBox6.Text.Replace(",", ""));
            mainFrame.CONFIGDATA = configData;

            MessageBox.Show("データを保存しました");
            this.Close();
        }

        private void textBox_number_only(object sender, KeyPressEventArgs e)
        {
            // 数値のみ
            if (e.KeyChar == '\b') return;
            if (e.KeyChar < '0' || e.KeyChar > '9') e.Handled = true;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            // コンマ付きの数字に変換
            string data = textBox2.Text;
            if (data == "") data = "0";
            textBox2.Text = String.Format("{0:#,0}", int.Parse(data.Replace(",", "")));
            // フォーカスが一番右に来る
            textBox2.Select(textBox2.Text.Length, 0);
            textBox2.Focus();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            // コンマ付きの数字に変換
            string data = textBox6.Text;
            if (data == "") data = "0";
            textBox6.Text = String.Format("{0:#,0}", int.Parse(data.Replace(",", "")));
            // フォーカスが一番右に来る
            textBox6.Select(textBox6.Text.Length, 0);
            textBox6.Focus();
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            // 残高を入力するテキストボックスをクリックした際、フォーカスが一番右に来る
            textBox2.Select(textBox2.Text.Length, 0);
            textBox2.Focus();
        }

        private void textBox6_Click(object sender, EventArgs e)
        {
            // 月間支出目標額を入力するテキストボックスをクリックした際、フォーカスが一番右に来る
            textBox6.Select(textBox2.Text.Length, 0);
            textBox6.Focus();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // テキストボックスにコンボボックスで選択した件を表示する
            textBox7.Text = comboBox1.SelectedItem.ToString();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                this.Width = 631;
            }else
            {
                this.Width = 1129;
            }
        }

        //** ContextMenuStrip **//

        private void Edit_Click(object sender, EventArgs e)
        {
            //表示しているコントロールを取得する
            var source = (ListPanel)contextMenuStrip1.SourceControl;

            if (source != null)
            {
                mainFrame.OpenInputScreen(source.IEdata, true);
                ShowList();
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            //表示しているコントロールを取得する
            var source = (ListPanel)contextMenuStrip1.SourceControl;

            if (source != null)
            {
                source.Dispose();
                mainFrame.FixdData.RemoveAll(x => x.ID == source.ID);
            }
        }

        private void textBox7_Click(object sender, EventArgs e)
        {
            comboBox1.DroppedDown = true;
        }
    }
}
