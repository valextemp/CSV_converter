namespace Polimetal_RA_CSV_converter
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.btnChooseTags = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnTagsSelectAll = new System.Windows.Forms.Button();
            this.chеckLstTags = new System.Windows.Forms.CheckedListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.chckAvgMode = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.btnFiltrTag = new System.Windows.Forms.Button();
            this.btnCreateCSV = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.btnSelectFiles = new System.Windows.Forms.Button();
            this.checkedLstFiles = new System.Windows.Forms.CheckedListBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Файл с именами Тегов";
            // 
            // txtFileName
            // 
            this.txtFileName.Location = new System.Drawing.Point(145, 12);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.ReadOnly = true;
            this.txtFileName.Size = new System.Drawing.Size(400, 20);
            this.txtFileName.TabIndex = 1;
            // 
            // btnChooseTags
            // 
            this.btnChooseTags.Location = new System.Drawing.Point(588, 9);
            this.btnChooseTags.Name = "btnChooseTags";
            this.btnChooseTags.Size = new System.Drawing.Size(101, 23);
            this.btnChooseTags.TabIndex = 2;
            this.btnChooseTags.Text = "Выбрать файл";
            this.btnChooseTags.UseVisualStyleBackColor = true;
            this.btnChooseTags.Click += new System.EventHandler(this.btnChooseTags_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.btnTagsSelectAll);
            this.groupBox1.Controls.Add(this.chеckLstTags);
            this.groupBox1.Location = new System.Drawing.Point(15, 49);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(674, 260);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Теги";
            // 
            // groupBox3
            // 
            this.groupBox3.Location = new System.Drawing.Point(398, 19);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(255, 157);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Информация о теге";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(398, 224);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(118, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "ВСЕ НЕ выбраны";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnTagsSelectAll
            // 
            this.btnTagsSelectAll.Location = new System.Drawing.Point(398, 194);
            this.btnTagsSelectAll.Name = "btnTagsSelectAll";
            this.btnTagsSelectAll.Size = new System.Drawing.Size(118, 23);
            this.btnTagsSelectAll.TabIndex = 1;
            this.btnTagsSelectAll.Text = "Выбрать ВСЕ";
            this.btnTagsSelectAll.UseVisualStyleBackColor = true;
            this.btnTagsSelectAll.Click += new System.EventHandler(this.btnTagsSelectAll_Click);
            // 
            // chеckLstTags
            // 
            this.chеckLstTags.FormattingEnabled = true;
            this.chеckLstTags.HorizontalScrollbar = true;
            this.chеckLstTags.Location = new System.Drawing.Point(6, 19);
            this.chеckLstTags.Name = "chеckLstTags";
            this.chеckLstTags.Size = new System.Drawing.Size(370, 229);
            this.chеckLstTags.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox5);
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Controls.Add(this.btnSelectFiles);
            this.groupBox2.Controls.Add(this.checkedLstFiles);
            this.groupBox2.Location = new System.Drawing.Point(15, 327);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(674, 260);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Файлы";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.chckAvgMode);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.numericUpDown1);
            this.groupBox4.Controls.Add(this.btnFiltrTag);
            this.groupBox4.Location = new System.Drawing.Point(538, 111);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(130, 135);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Фильтрованный CSV";
            this.groupBox4.Enter += new System.EventHandler(this.groupBox4_Enter);
            // 
            // chckAvgMode
            // 
            this.chckAvgMode.AutoSize = true;
            this.chckAvgMode.Location = new System.Drawing.Point(9, 48);
            this.chckAvgMode.Name = "chckAvgMode";
            this.chckAvgMode.Size = new System.Drawing.Size(81, 17);
            this.chckAvgMode.TabIndex = 9;
            this.chckAvgMode.Text = "Усреднять";
            this.chckAvgMode.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(57, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Минуты";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(9, 21);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(41, 20);
            this.numericUpDown1.TabIndex = 7;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnFiltrTag
            // 
            this.btnFiltrTag.Location = new System.Drawing.Point(6, 71);
            this.btnFiltrTag.Name = "btnFiltrTag";
            this.btnFiltrTag.Size = new System.Drawing.Size(118, 57);
            this.btnFiltrTag.TabIndex = 6;
            this.btnFiltrTag.Text = "Создать фильтрованный CSV";
            this.btnFiltrTag.UseVisualStyleBackColor = true;
            this.btnFiltrTag.Click += new System.EventHandler(this.button4_Click);
            // 
            // btnCreateCSV
            // 
            this.btnCreateCSV.Location = new System.Drawing.Point(6, 26);
            this.btnCreateCSV.Name = "btnCreateCSV";
            this.btnCreateCSV.Size = new System.Drawing.Size(118, 23);
            this.btnCreateCSV.TabIndex = 5;
            this.btnCreateCSV.Text = "Создать CSV";
            this.btnCreateCSV.UseVisualStyleBackColor = true;
            this.btnCreateCSV.Click += new System.EventHandler(this.btnCreateCSV_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(398, 223);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(118, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "ВСЕ НЕ выбраны";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(398, 193);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(118, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = "Выбрать ВСЕ";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnSelectFiles
            // 
            this.btnSelectFiles.Location = new System.Drawing.Point(382, 19);
            this.btnSelectFiles.Name = "btnSelectFiles";
            this.btnSelectFiles.Size = new System.Drawing.Size(118, 23);
            this.btnSelectFiles.TabIndex = 1;
            this.btnSelectFiles.Text = "Открыть файлы";
            this.btnSelectFiles.UseVisualStyleBackColor = true;
            this.btnSelectFiles.Click += new System.EventHandler(this.btnSelectFiles_Click);
            // 
            // checkedLstFiles
            // 
            this.checkedLstFiles.FormattingEnabled = true;
            this.checkedLstFiles.Location = new System.Drawing.Point(6, 19);
            this.checkedLstFiles.Name = "checkedLstFiles";
            this.checkedLstFiles.Size = new System.Drawing.Size(370, 229);
            this.checkedLstFiles.TabIndex = 0;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnCreateCSV);
            this.groupBox5.Location = new System.Drawing.Point(538, 47);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(130, 58);
            this.groupBox5.TabIndex = 7;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Сплошной CSV";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(701, 599);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnChooseTags);
            this.Controls.Add(this.txtFileName);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Polimetal RA converter CSV files";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.Button btnChooseTags;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnTagsSelectAll;
        private System.Windows.Forms.CheckedListBox chеckLstTags;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnSelectFiles;
        private System.Windows.Forms.CheckedListBox checkedLstFiles;
        private System.Windows.Forms.Button btnCreateCSV;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnFiltrTag;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chckAvgMode;
        private System.Windows.Forms.GroupBox groupBox5;
    }
}

