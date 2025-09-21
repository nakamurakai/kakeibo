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
    public partial class InitialSetting : Form
    {
        private MainFrame mainframe;
        string[] str = new string[4];
        List<(string name, string data)> configData = new List<(string name, string data)>();

        public InitialSetting(MainFrame mainframe)
        {
            InitializeComponent();
            this.mainframe = mainframe;
            textBox7.ReadOnly = true;
        }

        private void InitialSetting_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            textBox7.Text = comboBox1.SelectedItem.ToString();
            comboBox1.IntegralHeight = false;
            this.ActiveControl = textBox1;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ActiveControl = textBox1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            configData = mainframe.CONFIGDATA;
            // ユーザ名登録
            configData[3] = ("初期設定", "1");
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
            configData[7] = ("居住地", comboBox1.Text);

            // 残金登録
            configData[8] = ("残金", textBox2.Text.Replace(",", ""));

            // 月間支出目標額登録
            configData[10] = ("月間支出目標額", textBox6.Text.Replace(",", ""));
            mainframe.CONFIGDATA = configData;
            this.Close();
        }

        private void InitialSetting_KeyPress(object sender, KeyPressEventArgs e)
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

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            // テキストボックスにコンボボックスで選択した件を表示する
            textBox7.Text = comboBox1.SelectedItem.ToString();
        }

        private void textBox7_Click(object sender, EventArgs e)
        {
            comboBox1.DroppedDown = true;
        }
    }
}
