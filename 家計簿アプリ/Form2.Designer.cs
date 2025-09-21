namespace ClearVale
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.panel5 = new System.Windows.Forms.Panel();
            this.DateButton = new System.Windows.Forms.Button();
            this.Minus_button = new System.Windows.Forms.Button();
            this.Plus_button = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.customPanel1 = new ClearVale.CustomPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.AddButton = new System.Windows.Forms.Button();
            this.Menu = new System.Windows.Forms.ToolStripMenuItem();
            this.Edit = new System.Windows.Forms.ToolStripMenuItem();
            this.Delete = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.customPanel1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel5
            // 
            this.panel5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel5.Controls.Add(this.DateButton);
            this.panel5.Controls.Add(this.Minus_button);
            this.panel5.Controls.Add(this.Plus_button);
            this.panel5.Location = new System.Drawing.Point(28, 26);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1187, 52);
            this.panel5.TabIndex = 4;
            // 
            // DateButton
            // 
            this.DateButton.BackColor = System.Drawing.Color.White;
            this.DateButton.FlatAppearance.BorderSize = 0;
            this.DateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DateButton.Font = new System.Drawing.Font("メイリオ", 13.8F, System.Drawing.FontStyle.Bold);
            this.DateButton.Location = new System.Drawing.Point(432, 8);
            this.DateButton.Name = "DateButton";
            this.DateButton.Size = new System.Drawing.Size(244, 38);
            this.DateButton.TabIndex = 4;
            this.DateButton.Text = "2022年 12月 01日";
            this.DateButton.UseVisualStyleBackColor = false;
            this.DateButton.Click += new System.EventHandler(this.DateButton_Click);
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
            this.Minus_button.Location = new System.Drawing.Point(396, 12);
            this.Minus_button.Name = "Minus_button";
            this.Minus_button.Size = new System.Drawing.Size(30, 30);
            this.Minus_button.TabIndex = 9;
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
            this.Plus_button.Location = new System.Drawing.Point(682, 12);
            this.Plus_button.Name = "Plus_button";
            this.Plus_button.Size = new System.Drawing.Size(30, 30);
            this.Plus_button.TabIndex = 8;
            this.Plus_button.UseVisualStyleBackColor = false;
            this.Plus_button.Click += new System.EventHandler(this.Plus_button_Click);
            // 
            // panel4
            // 
            this.panel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel4.Controls.Add(this.customPanel1);
            this.panel4.Controls.Add(this.panel3);
            this.panel4.Location = new System.Drawing.Point(28, 92);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1187, 643);
            this.panel4.TabIndex = 3;
            // 
            // customPanel1
            // 
            this.customPanel1.BackColor = System.Drawing.Color.White;
            this.customPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("customPanel1.BackgroundImage")));
            this.customPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.customPanel1.Controls.Add(this.label3);
            this.customPanel1.Controls.Add(this.label4);
            this.customPanel1.Controls.Add(this.label2);
            this.customPanel1.Controls.Add(this.label1);
            this.customPanel1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.customPanel1.Location = new System.Drawing.Point(20, 12);
            this.customPanel1.Name = "customPanel1";
            this.customPanel1.PenSize = 2;
            this.customPanel1.Size = new System.Drawing.Size(1129, 44);
            this.customPanel1.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("メイリオ", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(470, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(659, 44);
            this.label3.TabIndex = 7;
            this.label3.Text = "メモ内容";
            this.label3.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Dock = System.Windows.Forms.DockStyle.Left;
            this.label4.Font = new System.Drawing.Font("メイリオ", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label4.Location = new System.Drawing.Point(295, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(175, 44);
            this.label4.TabIndex = 8;
            this.label4.Text = "金額";
            this.label4.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Font = new System.Drawing.Font("メイリオ", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(120, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(175, 44);
            this.label2.TabIndex = 6;
            this.label2.Text = "カテゴリ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("メイリオ", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 44);
            this.label1.TabIndex = 5;
            this.label1.Text = "IorE";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Location = new System.Drawing.Point(20, 62);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1129, 552);
            this.panel3.TabIndex = 2;
            // 
            // AddButton
            // 
            this.AddButton.BackColor = System.Drawing.Color.Transparent;
            this.AddButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.AddButton.FlatAppearance.BorderSize = 0;
            this.AddButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.AddButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddButton.Location = new System.Drawing.Point(1180, 636);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(70, 70);
            this.AddButton.TabIndex = 5;
            this.AddButton.UseVisualStyleBackColor = false;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // Menu
            // 
            this.Menu.Name = "Menu";
            this.Menu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
            this.Menu.Size = new System.Drawing.Size(161, 24);
            this.Menu.Text = "詳細";
            this.Menu.Click += new System.EventHandler(this.Menu_Click);
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
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu,
            this.Edit,
            this.toolStripSeparator1,
            this.Delete});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(162, 82);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(158, 6);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(1249, 757);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Font = new System.Drawing.Font("MS UI Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form2";
            this.Text = "Form2";
            this.VisibleChanged += new System.EventHandler(this.Form2_VisibleChanged);
            this.panel5.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.customPanel1.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button AddButton;
        private CustomPanel customPanel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Minus_button;
        private System.Windows.Forms.Button Plus_button;
        private System.Windows.Forms.Button DateButton;
        private System.Windows.Forms.ToolStripMenuItem Menu;
        private System.Windows.Forms.ToolStripMenuItem Edit;
        private System.Windows.Forms.ToolStripMenuItem Delete;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}