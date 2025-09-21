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
    public partial class AddCategory : Form
    {
        private Form1 form1;
        private string _CategoryName;
        private bool EditMode;

        public bool IE{get; set;}
        public string IorE { get { return IE ? "収入" : "支出"; } }
        public string CategoryName { set { _CategoryName = value; } }

        public AddCategory(Form1 form1, bool EditMode)
        {
            InitializeComponent();

            this.form1 = form1;
            this.EditMode = EditMode;
        }

        private void AddCategory_Load(object sender, EventArgs e)
        {
            label8.Text = EditMode ? "編集" : "追加";

            if (IE)
            {
                radioButton1.Checked = true;
            }
            else
            {
                radioButton2.Checked = true;
            }

            textBox1.Text = _CategoryName;
        }

        // 追加または編集処理を行う
        private void customButton1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;

            if(EditMode) 
            {
                CategoryButton cb = form1.CB.Find(x => x.Text == _CategoryName);

                // 名前が使用されているか調べる
                if (form1.CB.Find(x => x.Text == name && x.Text != cb.Text) != null)
                {
                    MessageBox.Show("この名前は既に使用されています。");
                    return;
                }

                cb.Visible = IorE.Equals(cb.IorE);
                cb.IorE = IorE;
                cb.Text = textBox1.Text;
                this.Close();
            }
            else
            {
                // 名前が使用されているか調べる
                if (form1.CB.Find(x => x.Text == name) != null)
                {
                    MessageBox.Show("この名前は既に使用されています。");
                    return;
                }

                form1.AddCategoryButton(name, radioButton1.Checked ? "収入" : "支出");
                this.Close();
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            IE = radioButton1.Checked;
        }
    }
}
