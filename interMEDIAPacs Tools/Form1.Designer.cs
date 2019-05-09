namespace interMEDIAPacs_Tools
{
    partial class AnaFrom
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AnaFrom));
            this.PatientList = new System.Windows.Forms.DataGridView();
            this.sec = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Accacces = new System.Windows.Forms.Label();
            this.Bul = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.işlemlerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cosİşlemleriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ayarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.baglantıAyarıToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.infoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.interMEDIAPacsTools15ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.PatientList)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // PatientList
            // 
            this.PatientList.AllowUserToAddRows = false;
            this.PatientList.AllowUserToOrderColumns = true;
            this.PatientList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PatientList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.sec});
            this.PatientList.Location = new System.Drawing.Point(26, 180);
            this.PatientList.Name = "PatientList";
            this.PatientList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.PatientList.Size = new System.Drawing.Size(919, 248);
            this.PatientList.TabIndex = 0;
            this.PatientList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.PatientList_CellClick);
            // 
            // sec
            // 
            this.sec.HeaderText = "";
            this.sec.Name = "sec";
            this.sec.ReadOnly = true;
            this.sec.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.sec.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Accacces
            // 
            this.Accacces.AutoSize = true;
            this.Accacces.Location = new System.Drawing.Point(23, 48);
            this.Accacces.Name = "Accacces";
            this.Accacces.Size = new System.Drawing.Size(60, 13);
            this.Accacces.TabIndex = 1;
            this.Accacces.Text = "Patient ID :";
            // 
            // Bul
            // 
            this.Bul.Location = new System.Drawing.Point(83, 113);
            this.Bul.Name = "Bul";
            this.Bul.Size = new System.Drawing.Size(100, 23);
            this.Bul.TabIndex = 2;
            this.Bul.Text = "Ara";
            this.Bul.UseVisualStyleBackColor = true;
            this.Bul.Click += new System.EventHandler(this.Bul_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(83, 45);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 3;
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(83, 87);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 20);
            this.textBox4.TabIndex = 7;
            this.textBox4.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox4_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Accs No :";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.işlemlerToolStripMenuItem,
            this.ayarToolStripMenuItem,
            this.infoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(968, 24);
            this.menuStrip1.TabIndex = 13;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // işlemlerToolStripMenuItem
            // 
            this.işlemlerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cosİşlemleriToolStripMenuItem});
            this.işlemlerToolStripMenuItem.Name = "işlemlerToolStripMenuItem";
            this.işlemlerToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.işlemlerToolStripMenuItem.Text = "İşlemler";
            // 
            // cosİşlemleriToolStripMenuItem
            // 
            this.cosİşlemleriToolStripMenuItem.Name = "cosİşlemleriToolStripMenuItem";
            this.cosİşlemleriToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.cosİşlemleriToolStripMenuItem.Text = "Cos İşlemleri";
            this.cosİşlemleriToolStripMenuItem.Click += new System.EventHandler(this.cosİşlemleriToolStripMenuItem_Click);
            // 
            // ayarToolStripMenuItem
            // 
            this.ayarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.baglantıAyarıToolStripMenuItem});
            this.ayarToolStripMenuItem.Name = "ayarToolStripMenuItem";
            this.ayarToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.ayarToolStripMenuItem.Text = "Ayar";
            // 
            // baglantıAyarıToolStripMenuItem
            // 
            this.baglantıAyarıToolStripMenuItem.Name = "baglantıAyarıToolStripMenuItem";
            this.baglantıAyarıToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.baglantıAyarıToolStripMenuItem.Text = "Baglantı Ayarı";
            this.baglantıAyarıToolStripMenuItem.Click += new System.EventHandler(this.baglantıAyarıToolStripMenuItem_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(205, 113);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(110, 23);
            this.button1.TabIndex = 14;
            this.button1.Text = "Seçilenleri Sil";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(80, 149);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "label1";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(205, 45);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 19;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(205, 28);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(96, 17);
            this.checkBox1.TabIndex = 20;
            this.checkBox1.Text = "Tarih ile Arama";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(205, 87);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker2.TabIndex = 21;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(538, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 22;
            // 
            // infoToolStripMenuItem
            // 
            this.infoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.interMEDIAPacsTools15ToolStripMenuItem});
            this.infoToolStripMenuItem.Name = "infoToolStripMenuItem";
            this.infoToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.infoToolStripMenuItem.Text = "İnfo";
            // 
            // interMEDIAPacsTools15ToolStripMenuItem
            // 
            this.interMEDIAPacsTools15ToolStripMenuItem.Name = "interMEDIAPacsTools15ToolStripMenuItem";
            this.interMEDIAPacsTools15ToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.interMEDIAPacsTools15ToolStripMenuItem.Text = "interMEDIAPacs Tools 1.5";
            // 
            // AnaFrom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(968, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Accacces);
            this.Controls.Add(this.Bul);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.PatientList);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.label4);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "AnaFrom";
            this.Text = "interMEDIA Pasc Tools 1.5";
            this.Load += new System.EventHandler(this.AnaFrom_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PatientList)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView PatientList;
        private System.Windows.Forms.Label Accacces;
        private System.Windows.Forms.Button Bul;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem işlemlerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cosİşlemleriToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ayarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem baglantıAyarıToolStripMenuItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn sec;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripMenuItem infoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem interMEDIAPacsTools15ToolStripMenuItem;
    }
}

