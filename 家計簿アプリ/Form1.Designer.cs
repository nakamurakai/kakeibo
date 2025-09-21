namespace ClearVale
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel9 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.Minus_button = new System.Windows.Forms.Button();
            this.Plus_button = new System.Windows.Forms.Button();
            this.Date_label = new System.Windows.Forms.Label();
            this.panel11 = new System.Windows.Forms.Panel();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel12 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel13 = new System.Windows.Forms.Panel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Edit = new System.Windows.Forms.ToolStripMenuItem();
            this.Delete = new System.Windows.Forms.ToolStripMenuItem();
            this.serifTimer = new System.Windows.Forms.Timer(this.components);
            this.customPanel4 = new ClearVale.CustomPanel();
            this.label7 = new System.Windows.Forms.Label();
            this.customSwitch1 = new ClearVale.CustomSwitch();
            this.customButton1 = new ClearVale.CustomButton();
            this.customPanel3 = new ClearVale.CustomPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.customPanel2 = new ClearVale.CustomPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.customPanel1 = new ClearVale.CustomPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            this.panel10.SuspendLayout();
            this.panel11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.panel12.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel13.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.customPanel4.SuspendLayout();
            this.customPanel3.SuspendLayout();
            this.customPanel2.SuspendLayout();
            this.customPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chart2
            // 
            chartArea1.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart2.Legends.Add(legend1);
            this.chart2.Location = new System.Drawing.Point(404, 120);
            this.chart2.Name = "chart2";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            series1.YValuesPerPoint = 4;
            this.chart2.Series.Add(series1);
            this.chart2.Size = new System.Drawing.Size(305, 240);
            this.chart2.TabIndex = 12;
            this.chart2.Text = "chart2";
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.White;
            this.panel9.Location = new System.Drawing.Point(31, 134);
            this.panel9.Name = "panel9";
            this.panel9.Padding = new System.Windows.Forms.Padding(4);
            this.panel9.Size = new System.Drawing.Size(312, 482);
            this.panel9.TabIndex = 13;
            // 
            // panel10
            // 
            this.panel10.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel10.Controls.Add(this.Minus_button);
            this.panel10.Controls.Add(this.Plus_button);
            this.panel10.Controls.Add(this.Date_label);
            this.panel10.Location = new System.Drawing.Point(23, 26);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(804, 48);
            this.panel10.TabIndex = 16;
            // 
            // Minus_button
            // 
            this.Minus_button.BackColor = System.Drawing.Color.White;
            this.Minus_button.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Minus_button.BackgroundImage")));
            this.Minus_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Minus_button.FlatAppearance.BorderSize = 0;
            this.Minus_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Minus_button.Font = new System.Drawing.Font("メイリオ", 13.8F, System.Drawing.FontStyle.Bold);
            this.Minus_button.ForeColor = System.Drawing.Color.Black;
            this.Minus_button.Location = new System.Drawing.Point(252, 10);
            this.Minus_button.Name = "Minus_button";
            this.Minus_button.Size = new System.Drawing.Size(30, 30);
            this.Minus_button.TabIndex = 7;
            this.Minus_button.UseVisualStyleBackColor = false;
            this.Minus_button.Click += new System.EventHandler(this.Minus_button_Click);
            // 
            // Plus_button
            // 
            this.Plus_button.BackColor = System.Drawing.Color.White;
            this.Plus_button.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Plus_button.BackgroundImage")));
            this.Plus_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Plus_button.FlatAppearance.BorderSize = 0;
            this.Plus_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Plus_button.Font = new System.Drawing.Font("メイリオ", 13.8F, System.Drawing.FontStyle.Bold);
            this.Plus_button.ForeColor = System.Drawing.Color.Black;
            this.Plus_button.Location = new System.Drawing.Point(472, 10);
            this.Plus_button.Name = "Plus_button";
            this.Plus_button.Size = new System.Drawing.Size(30, 30);
            this.Plus_button.TabIndex = 6;
            this.Plus_button.UseVisualStyleBackColor = false;
            this.Plus_button.Click += new System.EventHandler(this.Plus_button_Click);
            // 
            // Date_label
            // 
            this.Date_label.BackColor = System.Drawing.Color.White;
            this.Date_label.Font = new System.Drawing.Font("メイリオ", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Date_label.Location = new System.Drawing.Point(288, 6);
            this.Date_label.Name = "Date_label";
            this.Date_label.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.Date_label.Size = new System.Drawing.Size(175, 38);
            this.Date_label.TabIndex = 0;
            this.Date_label.Text = "2022年 12月";
            this.Date_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel11
            // 
            this.panel11.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel11.Controls.Add(this.chart1);
            this.panel11.Controls.Add(this.customPanel3);
            this.panel11.Controls.Add(this.customPanel2);
            this.panel11.Controls.Add(this.customPanel1);
            this.panel11.Controls.Add(this.chart2);
            this.panel11.Location = new System.Drawing.Point(23, 87);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(804, 405);
            this.panel11.TabIndex = 17;
            // 
            // chart1
            // 
            chartArea2.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chart1.Legends.Add(legend2);
            this.chart1.Location = new System.Drawing.Point(49, 120);
            this.chart1.Name = "chart1";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
            series2.Legend = "Legend1";
            series2.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            series2.Name = "s1";
            series2.YValuesPerPoint = 4;
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(305, 240);
            this.chart1.TabIndex = 13;
            this.chart1.Text = "chart1";
            // 
            // panel12
            // 
            this.panel12.AutoScroll = true;
            this.panel12.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel12.Controls.Add(this.panel1);
            this.panel12.Controls.Add(this.pictureBox1);
            this.panel12.Location = new System.Drawing.Point(23, 507);
            this.panel12.Name = "panel12";
            this.panel12.Padding = new System.Windows.Forms.Padding(10);
            this.panel12.Size = new System.Drawing.Size(804, 226);
            this.panel12.TabIndex = 17;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.label8);
            this.panel1.Location = new System.Drawing.Point(27, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(560, 190);
            this.panel1.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("メイリオ", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label8.Location = new System.Drawing.Point(16, 25);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(491, 142);
            this.label8.TabIndex = 1;
            this.label8.Text = "label8";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Location = new System.Drawing.Point(606, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(171, 200);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.VisibleChanged += new System.EventHandler(this.pictureBox1_VisibleChanged);
            // 
            // panel13
            // 
            this.panel13.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel13.Controls.Add(this.customPanel4);
            this.panel13.Controls.Add(this.customSwitch1);
            this.panel13.Controls.Add(this.panel9);
            this.panel13.Controls.Add(this.customButton1);
            this.panel13.Location = new System.Drawing.Point(846, 26);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(375, 707);
            this.panel13.TabIndex = 17;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Edit,
            this.Delete});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(162, 52);
            // 
            // Edit
            // 
            this.Edit.Name = "Edit";
            this.Edit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.Edit.Size = new System.Drawing.Size(161, 24);
            this.Edit.Text = "編集";
            this.Edit.Click += new System.EventHandler(this.Edit_Click);
            // 
            // Delete
            // 
            this.Delete.Name = "Delete";
            this.Delete.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.Delete.Size = new System.Drawing.Size(161, 24);
            this.Delete.Text = "削除";
            this.Delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // serifTimer
            // 
            this.serifTimer.Interval = 15000;
            this.serifTimer.Tick += new System.EventHandler(this.serifTimer_Tick);
            // 
            // customPanel4
            // 
            this.customPanel4.BackColor = System.Drawing.Color.White;
            this.customPanel4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("customPanel4.BackgroundImage")));
            this.customPanel4.Controls.Add(this.label7);
            this.customPanel4.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.customPanel4.Location = new System.Drawing.Point(32, 89);
            this.customPanel4.Name = "customPanel4";
            this.customPanel4.PenSize = 2;
            this.customPanel4.Size = new System.Drawing.Size(311, 43);
            this.customPanel4.TabIndex = 16;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(0, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(311, 43);
            this.label7.TabIndex = 2;
            this.label7.Text = "カテゴリ";
            this.label7.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // customSwitch1
            // 
            this.customSwitch1.BackColor = System.Drawing.Color.White;
            this.customSwitch1.FlatAppearance.BorderSize = 0;
            this.customSwitch1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.customSwitch1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.customSwitch1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.customSwitch1.Font = new System.Drawing.Font("MS UI Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.customSwitch1.Image = ((System.Drawing.Image)(resources.GetObject("customSwitch1.Image")));
            this.customSwitch1.Location = new System.Drawing.Point(31, 28);
            this.customSwitch1.MainColor = System.Drawing.Color.White;
            this.customSwitch1.Name = "customSwitch1";
            this.customSwitch1.Selected = false;
            this.customSwitch1.Size = new System.Drawing.Size(312, 53);
            this.customSwitch1.SubColor = System.Drawing.Color.Gainsboro;
            this.customSwitch1.TabIndex = 15;
            this.customSwitch1.UseVisualStyleBackColor = false;
            this.customSwitch1.Click += new System.EventHandler(this.customSwitch1_Click);
            // 
            // customButton1
            // 
            this.customButton1.BackColor = System.Drawing.Color.White;
            this.customButton1.Color = System.Drawing.Color.DarkOrange;
            this.customButton1.FlatAppearance.BorderSize = 0;
            this.customButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.customButton1.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.customButton1.ForeColor = System.Drawing.Color.White;
            this.customButton1.Image = ((System.Drawing.Image)(resources.GetObject("customButton1.Image")));
            this.customButton1.Location = new System.Drawing.Point(31, 633);
            this.customButton1.Name = "customButton1";
            this.customButton1.Size = new System.Drawing.Size(312, 53);
            this.customButton1.TabIndex = 14;
            this.customButton1.Text = "カテゴリ追加";
            this.customButton1.UseVisualStyleBackColor = false;
            this.customButton1.Click += new System.EventHandler(this.customButton1_Click);
            // 
            // customPanel3
            // 
            this.customPanel3.BackColor = System.Drawing.Color.White;
            this.customPanel3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("customPanel3.BackgroundImage")));
            this.customPanel3.Controls.Add(this.label2);
            this.customPanel3.Controls.Add(this.label1);
            this.customPanel3.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.customPanel3.Location = new System.Drawing.Point(10, 27);
            this.customPanel3.Name = "customPanel3";
            this.customPanel3.PenSize = 2;
            this.customPanel3.Size = new System.Drawing.Size(243, 43);
            this.customPanel3.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(74, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(169, 43);
            this.label2.TabIndex = 4;
            this.label2.Text = "\\425,000";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 43);
            this.label1.TabIndex = 3;
            this.label1.Text = "収入";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // customPanel2
            // 
            this.customPanel2.BackColor = System.Drawing.Color.White;
            this.customPanel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("customPanel2.BackgroundImage")));
            this.customPanel2.Controls.Add(this.label3);
            this.customPanel2.Controls.Add(this.label4);
            this.customPanel2.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.customPanel2.Location = new System.Drawing.Point(280, 27);
            this.customPanel2.Name = "customPanel2";
            this.customPanel2.PenSize = 2;
            this.customPanel2.Size = new System.Drawing.Size(243, 43);
            this.customPanel2.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(74, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(169, 43);
            this.label3.TabIndex = 4;
            this.label3.Text = "\\75,000";
            this.label3.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Dock = System.Windows.Forms.DockStyle.Left;
            this.label4.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 43);
            this.label4.TabIndex = 3;
            this.label4.Text = "支出";
            this.label4.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // customPanel1
            // 
            this.customPanel1.BackColor = System.Drawing.Color.White;
            this.customPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("customPanel1.BackgroundImage")));
            this.customPanel1.Controls.Add(this.label5);
            this.customPanel1.Controls.Add(this.label6);
            this.customPanel1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.customPanel1.Location = new System.Drawing.Point(550, 27);
            this.customPanel1.Name = "customPanel1";
            this.customPanel1.PenSize = 2;
            this.customPanel1.Size = new System.Drawing.Size(243, 43);
            this.customPanel1.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(74, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(169, 43);
            this.label5.TabIndex = 4;
            this.label5.Text = "\\350,000";
            this.label5.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Dock = System.Windows.Forms.DockStyle.Left;
            this.label6.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 43);
            this.label6.TabIndex = 3;
            this.label6.Text = "収支";
            this.label6.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1249, 757);
            this.Controls.Add(this.panel13);
            this.Controls.Add(this.panel12);
            this.Controls.Add(this.panel11);
            this.Controls.Add(this.panel10);
            this.Font = new System.Drawing.Font("MS UI Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.VisibleChanged += new System.EventHandler(this.Form1_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            this.panel10.ResumeLayout(false);
            this.panel11.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.panel12.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel13.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.customPanel4.ResumeLayout(false);
            this.customPanel3.ResumeLayout(false);
            this.customPanel2.ResumeLayout(false);
            this.customPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private System.Windows.Forms.Panel panel9;
        private CustomButton customButton1;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.Panel panel13;
        private CustomSwitch customSwitch1;
        private System.Windows.Forms.Label Date_label;
        private CustomPanel customPanel1;
        private CustomPanel customPanel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private CustomPanel customPanel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private CustomPanel customPanel4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem Edit;
        private System.Windows.Forms.ToolStripMenuItem Delete;
        private System.Windows.Forms.Button Minus_button;
        private System.Windows.Forms.Button Plus_button;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Timer serifTimer;
        private System.Windows.Forms.Panel panel1;
    }
}

