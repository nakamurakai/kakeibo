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
    public partial class InputScreen : Form
    {
        private MainFrame mainFrame;
        private IEData ie;
        private bool EditMode;

        //** プロパティ **//

        public InputScreen(MainFrame mainFrame, IEData ie, bool EditMode)
        {
            InitializeComponent();
            this.mainFrame = mainFrame;
            this.ie = ie;
            this.EditMode = EditMode;
            Icon icon = new Icon(@"Image File\Icon.ico", 25, 25);
            this.Icon = icon;
        }

        private void InputScreen_Load(object sender, EventArgs e)
        {
            label8.Text = EditMode ? "編集" : "追加";
            comboBox2.Visible = !EditMode;

            if (ie.IorE == "収入")
            {
                radioButton1.Checked = true;
            }
            else
            {
                radioButton2.Checked = true;
            }

            textBox1.Text = ie.date.ToString("yyyy/MM/dd");
            comboBox1.Text = ie.categry;
            textBox3.Text = ie.memo;
            textBox4.Text = ie.amount.ToString();
            comboBox2.SelectedIndex = 0;

            foreach (var x in mainFrame.CB)
            {
                comboBox1.Items.Add(x.Text);
            }
        }

        //** イベント **//

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            int num = textBox3.Text.Length;
            label4.Text = String.Format("{0}/{1}", num, textBox3.MaxLength);
        }

        private void customButton1_Click(object sender, EventArgs e)
        {
            ie.IorE = radioButton1.Checked ? "収入" : "支出";
            ie.date = DateTime.Parse(textBox1.Text);
            ie.categry = comboBox1.Text;
            ie.memo = textBox3.Text;
            ie.amount = int.Parse(textBox4.Text.Replace(",", ""));
            ie.repetition = comboBox2.SelectedIndex;

            if (EditMode)
            {
                Console.WriteLine(mainFrame.IEDatas.Find(x => x.ID == ie.ID).ID);
            }
            else
            {
                mainFrame.AddList(ie);
            }

            this.Close();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            // コンマ付きの数字に変換
            string data = textBox4.Text;
            if (data == "") data = "0";
            textBox4.Text = String.Format("{0:#,0}", int.Parse(data.Replace(",", "")));
            // フォーカスが一番右に来る
            textBox4.Select(textBox4.Text.Length, 0);
            textBox4.Focus();
        }

        private void textBox4_Click(object sender, EventArgs e)
        {
            textBox4.Select(textBox4.Text.Length, 0);
            textBox4.Focus();
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 数値のみ
            if (e.KeyChar == '\b') return;
            if (e.KeyChar < '0' || e.KeyChar > '9') e.Handled = true;
        }
    }
}
