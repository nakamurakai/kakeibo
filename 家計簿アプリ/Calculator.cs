using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClearVale
{
    public partial class Calculator : Form
    {

        public Calculator()
        {
            InitializeComponent();

            this.Anchor = AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Bottom;
        }


        private void Calculator_Load(object sender, EventArgs e)
        {
            this.Size = new Size(438, 497);
            flag_size = false;
            button1.Text = "→";
            button10.Text = "e";
            this.ActiveControl = this.textBox1;
            button4.Image = Image.FromFile(@"Image File\電卓ボタン画像\x二乗1.jpg");
            button5.Image = Image.FromFile(@"Image File\電卓ボタン画像\xのy乗.jpg");
            button7.Image = Image.FromFile(@"Image File\電卓ボタン画像\x分の1.jpg");
            button8.Image = Image.FromFile(@"Image File\電卓ボタン画像\x分のy.jpg");
            button11.Image = Image.FromFile(@"Image File\電卓ボタン画像\10のx乗.jpg");
        }

        // フラグ、配列等の定義

            // 数字データ保存場所
            private List<decimal> number_data = new List<decimal>();
            // 数字データ保存場所
            private List<decimal> number_Parenthesis_data = new List<decimal>();
            // 関数データ保存場所
            private List<string> function_data = new List<string>();
            // 関数データ保存場所
            private List<string> function_Parenthesis_data = new List<string>();
            // label1のテキストが0
            Boolean label_write = true;
            // label1のテキストが正の数
            Boolean flag_plus = true;
            // dotフラグ
            Boolean flag_dot = false;
            // 演算子が押される
            Boolean flag_ope = false;
            // =が押されたか
            Boolean flag_equal = false;
            // 演算子
            string[] operator_symbol = new string[7] {" ", "＋", "－", "×", "÷","^","分の" };
            int symbol_point = 0;
            // 計算結果
            decimal anser;
            // 画面のサイズ(true:大きい,false:小さい)
            Boolean flag_size = false;
            //0エラー
            Boolean flag_zeroErr = false;
            // 括弧
            Boolean flag_Parenthesis = false;
            // label2に数字を表示するか
            Boolean label2_write = true;
        //

        // 1～9の数字を押したとき
        private void number_Click(object sender, EventArgs e)
        {
            confirmation();
            if (label_write)
            {
                label1.Text = ((Button)sender).Text;
                label_write = false;
            }
            else
            {
                label1.Text += ((Button)sender).Text;
            }
        }

        private void confirmation()
        {
            if (flag_ope)
            {
                if (flag_Parenthesis)
                {
                    function_Parenthesis_data.Add(operator_symbol[symbol_point]);
                }
                else
                {
                    function_data.Add(operator_symbol[symbol_point]);
                }
                label2.Text += operator_symbol[symbol_point];
                flag_ope = false;
            }
            
            if (flag_equal)
            {
                label2.Text = "";
                flag_equal = false;
            }

            Button_control_enable();
            this.ActiveControl = this.textBox1;
        }

        // 0ボタンを押したとき
        private void number0_Click(object sender, EventArgs e)
        {
            confirmation();
            if (label_write)
            {
                label1.Text = "0";
            }
            else
            {
                label1.Text += ((Button)sender).Text;
            }
            
        }

        // .ボタンを押したとき
        private void dotButton_Click(object sender, EventArgs e)
        {
            confirmation();
            if (flag_dot)
            {
                return;
            }
            else
            {
                label1.Text += ".";
                flag_dot = true;
                label_write = false;
            }
        }

        // ACボタンを押したとき
        private void allClearButton_Click(object sender, EventArgs e)
        {
            confirmation();
            Button_control_enable();

            if (flag_zeroErr)
            {
                label1.Text = "0で割ることはできません";
                flag_zeroErr = false;
            }
            else
            {
                label1.Text = "0";
            }

            label2.Text = "";
            number_data.Clear();
            number_Parenthesis_data.Clear();
            function_data.Clear();
            function_Parenthesis_data.Clear();
            flag_dot = false;
            label_write = true;
            flag_plus = true;
            flag_ope = false;
            label2_write = true;
            symbol_point = 0;
            this.ActiveControl = this.textBox1;
            anser = 0;

        }

        // 演算子を押したとき
        private void operationButton_Click(object sender, EventArgs e)
        {
            if (label1.Text == "0で割ることはできません") label1.Text = "0";

            if (flag_equal)
            {
                label2.Text = "";
                flag_equal = false;
            }
            label_write = true;
            // 数字保存場所にlabelの数字を入れる
            if (flag_ope == false)
            {
                if (flag_Parenthesis)
                {
                    number_Parenthesis_data.Add(decimal.Parse(label1.Text));
                }
                else
                {
                    number_data.Add(decimal.Parse(label1.Text));
                }
                if (label2_write)
                {
                    label2.Text += label1.Text;
                }
                else
                {
                    label2_write = true;
                }
                flag_ope = true;
            }

            // ボタンの色とコントロールの有効設定
            Button_control_enable();

            ((Button)sender).Enabled = false;
            ((Button)sender).BackColor = Color.FromArgb(255, 192, 128);


            // 選択したボタンの判定
            if (((Button)sender).Text == "＋")
            {
                symbol_point = 1;
            }
            else if (((Button)sender).Text == "－")
            {
                symbol_point = 2;
            }
            else if (((Button)sender).Text == "×")
            {
                symbol_point = 3;
            }
            else if (((Button)sender).Text == "÷")
            {
                symbol_point = 4;
            }else if(((Button)sender).Name == button5.Name)
            {
                symbol_point = 5;
                ((Button)sender).BackColor = Color.LightGray;
                ((Button)sender).Image = Image.FromFile(@"Image File\電卓ボタン画像\xのy乗選択時.jpg");
            }
            else if (((Button)sender).Name == button8.Name)
            {
                symbol_point = 6;
                ((Button)sender).BackColor = Color.LightGray;
                ((Button)sender).Image = Image.FromFile(@"Image File\電卓ボタン画像\x分のy選択時.jpg");
            }

            flag_dot = false;
            this.ActiveControl = this.textBox1;
        }

        private void Button_control_enable()
        {
            addButton.Enabled = true;
            addButton.BackColor = Color.FromArgb(255, 192, 128);
            subButton.Enabled = true;
            subButton.BackColor = Color.FromArgb(255, 192, 128);
            mulButton.Enabled = true;
            mulButton.BackColor = Color.FromArgb(255, 192, 128);
            divButton.Enabled = true;
            divButton.BackColor = Color.FromArgb(255, 192, 128);
            button5.Enabled = true;
            button5.ForeColor = Color.DarkGray;
            button5.Image = Image.FromFile(@"Image File\電卓ボタン画像\xのy乗.jpg");
            button8.Enabled = true;
            button8.ForeColor = Color.DarkGray;
            button8.Image = Image.FromFile(@"Image File\電卓ボタン画像\x分のy.jpg");
            leftParenthesisButton.Enabled = true;
            leftParenthesisButton.BackColor = Color.DarkGray;
        }

        // キー入力処理
        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            textBox1.Text = "";
            if (e.KeyValue == '0') number0.PerformClick();
            else if (e.KeyValue == '1') number1.PerformClick();
            else if (e.KeyValue == '2') number2.PerformClick();
            else if (e.KeyValue == '3') number3.PerformClick();
            else if (e.KeyValue == '4') number4.PerformClick();
            else if (e.KeyValue == '5') number5.PerformClick();
            else if (e.KeyValue == '6') number6.PerformClick();
            else if (e.KeyValue == '7') number7.PerformClick();
            else if (e.KeyValue == '8') number8.PerformClick();
            else if (e.KeyValue == '9') number9.PerformClick();
            if (e.KeyCode == Keys.OemPeriod) dotButton.PerformClick();
            if (e.KeyCode == Keys.Oemplus) addButton.PerformClick();
            if (e.KeyCode == Keys.OemMinus) subButton.PerformClick();
            if (e.KeyCode == Keys.Oem1) mulButton.PerformClick();
            if (e.KeyCode == Keys.Oem2) divButton.PerformClick();
            if (e.KeyCode == Keys.Enter) equalButton.PerformClick();
            if (e.KeyCode == Keys.Back) erase();

        }

        // label1の末尾を削除
        private void erase()
        {
            string str = label1.Text;

            if (str.Substring(str.Length - 1) == ".")
            {
                flag_dot = false;
                label1.Text = str.Substring(0, str.Length - 1);
                return;
            }
            if (str.Length == 1)
            {
                label1.Text = "0";
                label_write = true;
            }

            if (str.Length > 1)
            {
                label1.Text = str.Substring(0, str.Length - 1);
                str = label1.Text;
            }
            else if (str.Length == 1)
            {
                label1.Text = "0";
                label_write = true;
            }
        }

        // ＋/ー変更
        private void plusMinusButton_Click(object sender, EventArgs e)
        {
            if(label1.Text == "0" || label1.Text == "0で割ることはできません")
            {
                label1.Text = "0";
                return;
            }
            if (flag_plus)
            {
                label1.Text = "-" + label1.Text;
                flag_plus = false;
            }
            else
            {
                label1.Text = label1.Text.Replace("-", "");
                flag_plus = true;
            }

            this.ActiveControl = this.textBox1;
        }

        // ％ボタン
        private void percentButton_Click(object sender, EventArgs e)
        {
            decimal n = decimal.Parse(label1.Text) / 100;
            label1.Text = n.ToString();

            // 小数点があるか
            if (n - Math.Floor(n) != 0)
            {
                flag_dot = true;
            }
            else
            {
                flag_dot = false;
            }
            this.ActiveControl = this.textBox1;
        }

        // ＝ボタン
        private void equalButton_Click(object sender, EventArgs e)
        {
            if (label1.Text == "0で割ることはできません") label1.Text = "0";

            if (flag_Parenthesis) // 括弧の閉じ忘れ
            {
                number_data.AddRange(number_Parenthesis_data);
                function_data.AddRange(function_Parenthesis_data);
                flag_Parenthesis = false;
            }

            if (flag_ope)
            {
                function_data.Add(operator_symbol[symbol_point]);
                label2.Text += operator_symbol[symbol_point];
                flag_ope = false;
            }

            if (label2_write == true)
            {
                label2.Text += label1.Text;
            }
            else
            {
                label2_write = true;
            }
            
            number_data.Add(decimal.Parse(label1.Text));
            // 計算する
            calcul(number_data,function_data);
            textBox2.Text += label2.Text + "＝" + label1.Text + "\r\n";


            number_data.Clear();
            number_Parenthesis_data.Clear();
            function_data.Clear();
            function_Parenthesis_data.Clear();
            label_write = true;
            flag_plus = true;
            flag_ope = false;
            flag_equal = true;
            symbol_point = 0;
            this.ActiveControl = this.textBox1;
            Button_control_enable();
        }

        // 計算
        private void calcul(List<decimal>n_data,List<string>f_data)
        { 
            int i,j;
            decimal n;
            anser = n_data[0];
            for (i = 0,j = 1; i < f_data.Count; i++,j++)
            {
                
                if (f_data[i] == "^" || f_data[i] == "分の")
                {
                    if (f_data.Count != 1)
                    {
                        if (f_data[i - 1] == "＋")
                        {
                            arithmeticOperation("－", n_data[j - 1]);
                        }
                        else if (f_data[i - 1] == "－")
                        {
                            arithmeticOperation("＋", n_data[j - 1]);
                        }
                        else if (f_data[i - 1] == "×")
                        {
                            arithmeticOperation("÷", n_data[j - 1]);
                        }
                        else if (f_data[i - 1] == "÷")
                        {
                            arithmeticOperation("×", n_data[j - 1]);
                        }
                    }

                    if (f_data[i] == "^") // 乗数
                    {
                        n = n_data[i];
                        if (n_data[j] >= 2)
                        {
                            for (int k = 2; k <= n_data[j]; k++)
                            {
                                n *= n_data[i];
                            }
                        }
                        if (n_data[i] == 0 && n_data[j] == 0) n = 1;
                    } else // 分数
                    {
                        if (n_data[i] == 0)
                        {
                            flag_zeroErr = true;
                            allClearButton.PerformClick();
                            return;
                        }

                        n = n_data[j] / n_data[i];
                    }

                    if (f_data.Count == 1)
                    {
                        anser = n;
                        break;
                    }
                    else
                    {
                        n_data[i] = n;
                    }
                    n_data[j] = 0;
                    f_data[i] = "＋";
                    i--;
                    j--;
                }
                arithmeticOperation(f_data[i], n_data[j]);
            }

            // 小数点があるか
            if (anser - Math.Floor(anser) != 0)
            {
                flag_dot = true;
            }
            else
            {
                flag_dot = false;
            }
            
            label1.Text = anser.ToString();
        }

        // 四則演算計算
        private void arithmeticOperation(string s,decimal n)
        {
            if (s == "＋")
            {
                anser += n;
            }
            else if (s == "－")
            {
                anser -= n;
            }
            else if (s == "×")
            {
                anser *= n;
            }
            else if (s == "÷")
            {
                if (n == 0)
                {
                    flag_zeroErr = true;
                    allClearButton.PerformClick();
                    return;
                }

                anser /= n;
            }
        }

        // 画面サイズ変更
        private void button1_Click(object sender, EventArgs e)
        {
            if (flag_size) // 画面小さくする
            {
                this.Size = new Size(438, 497);
                flag_size = false;
                button1.Text = "→";
                button10.Text = "e";
            }
            else // 画面大きくする
            {
                this.Size = new Size(848, 497);
                flag_size = true;
                button1.Text = "←";
                button10.Text = "履歴削除";
            }
            this.ActiveControl = this.textBox1;
        }

        private void Calculator_Click(object sender, EventArgs e)
        {
            this.ActiveControl = this.textBox1;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.ActiveControl = this.textBox1;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.ActiveControl = this.textBox1;
        }

        // 1/x の計算
        private void button7_Click(object sender, EventArgs e)
        {
            if (label1.Text == "0で割ることはできません") label1.Text = "0";
            decimal n = decimal.Parse(label1.Text);

            if (n == 0)
            {
                flag_zeroErr = true;
                allClearButton.PerformClick();
                return;
            }
            n = 1 / n;
            
            label1.Text = n.ToString();

            label_write = true;
            // 小数点があるか
            if (n - Math.Floor(n) != 0)
            {
                flag_dot = true;
            }
            else
            {
                flag_dot = false;
            }

            label_write = true;
            this.ActiveControl = this.textBox1;
        }

        // π
        private void button9_Click(object sender, EventArgs e)
        {
            label1.Text = "3.14";
            this.ActiveControl = this.textBox1;
            label_write = true;
        }

        // 2乗
        private void button4_Click(object sender, EventArgs e)
        {
            decimal n = decimal.Parse(label1.Text);

            label1.Text = (n * n).ToString();
            this.ActiveControl = this.textBox1;
            label_write = true;
        }

        // 10^x
        private void button11_Click(object sender, EventArgs e)
        {
            double n = Math.Pow(10, double.Parse(label1.Text));
            label1.Text = n.ToString();
            this.ActiveControl = this.textBox1;
            label_write = true;
        }

        // log10
        private void log10Button_Click(object sender, EventArgs e)
        {
            double n = Math.Log10(double.Parse(label1.Text));
            label1.Text = n.ToString();
            this.ActiveControl = this.textBox1;
            label_write = true;
        }

        // ネイピア数
        private void button10_Click(object sender, EventArgs e)
        {
            if (flag_size)
            {
                textBox2.Text = "";
            }
            else
            {
                label1.Text = Math.E.ToString();
                label_write = true;
            }
            this.ActiveControl = this.textBox1;
        }

        // (
        private void leftParenthesisButton_Click(object sender, EventArgs e)
        {
            leftParenthesisButton.Enabled = false;
            leftParenthesisButton.BackColor = Color.LightGray;
            flag_Parenthesis = true;
            if (flag_ope)
            {
                function_data.Add(operator_symbol[symbol_point]);
            }
            else
            {
                function_data.Add(operator_symbol[3]);
                label2.Text += label1.Text;
            }
            label_write = true;
            label2.Text += operator_symbol[symbol_point] + "(";
            flag_ope = false;
            this.ActiveControl = this.textBox1;
        }

        private void rightParenthesisButton_Click(object sender, EventArgs e)
        {
            if (flag_Parenthesis)
            {
                leftParenthesisButton.Enabled = true;
                leftParenthesisButton.BackColor = Color.DarkGray;
                
                label2.Text += label1.Text + ")";
                number_Parenthesis_data.Add(decimal.Parse(label1.Text));
                calcul(number_Parenthesis_data, function_Parenthesis_data);
                number_data.Add(decimal.Parse(label1.Text));
                label2_write = false;
            }
            flag_Parenthesis = false;
            this.ActiveControl = this.textBox1;
        }
    }
}
