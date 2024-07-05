
namespace CourseSystem
{
    partial class ManagementView
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
            this._tabControl1 = new System.Windows.Forms.TabControl();
            this._tabPageCourse = new System.Windows.Forms.TabPage();
            this._buttonDownload = new System.Windows.Forms.Button();
            this._buttonSave = new System.Windows.Forms.Button();
            this._groupBox = new System.Windows.Forms.GroupBox();
            this._dataGridViewTime = new System.Windows.Forms.DataGridView();
            this._comboBoxHour = new System.Windows.Forms.ComboBox();
            this._comboBoxClassName = new System.Windows.Forms.ComboBox();
            this._comboBoxRequired = new System.Windows.Forms.ComboBox();
            this._label11 = new System.Windows.Forms.Label();
            this._label10 = new System.Windows.Forms.Label();
            this._label9 = new System.Windows.Forms.Label();
            this._label8 = new System.Windows.Forms.Label();
            this._label7 = new System.Windows.Forms.Label();
            this._label6 = new System.Windows.Forms.Label();
            this._label5 = new System.Windows.Forms.Label();
            this._label4 = new System.Windows.Forms.Label();
            this._label3 = new System.Windows.Forms.Label();
            this._textBoxAssistant = new System.Windows.Forms.TextBox();
            this._textBoxNote = new System.Windows.Forms.TextBox();
            this._textBoxLanguage = new System.Windows.Forms.TextBox();
            this._textBoxCredit = new System.Windows.Forms.TextBox();
            this._textBoxTeacher = new System.Windows.Forms.TextBox();
            this._textBoxStage = new System.Windows.Forms.TextBox();
            this._textBoxName = new System.Windows.Forms.TextBox();
            this._label2 = new System.Windows.Forms.Label();
            this._textBoxNumber = new System.Windows.Forms.TextBox();
            this._label1 = new System.Windows.Forms.Label();
            this._comboBoxStatus = new System.Windows.Forms.ComboBox();
            this._buttonAdd = new System.Windows.Forms.Button();
            this._listBox = new System.Windows.Forms.ListBox();
            this._tabPageClass = new System.Windows.Forms.TabPage();
            this._buttonSaveClass = new System.Windows.Forms.Button();
            this._buttonAddClass = new System.Windows.Forms.Button();
            this._groupBoxClass = new System.Windows.Forms.GroupBox();
            this._labelCourse = new System.Windows.Forms.Label();
            this._listBoxCourse = new System.Windows.Forms.ListBox();
            this._textBoxClass = new System.Windows.Forms.TextBox();
            this._labelClass = new System.Windows.Forms.Label();
            this._listBoxClass = new System.Windows.Forms.ListBox();
            this._tabControl1.SuspendLayout();
            this._tabPageCourse.SuspendLayout();
            this._groupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dataGridViewTime)).BeginInit();
            this._tabPageClass.SuspendLayout();
            this._groupBoxClass.SuspendLayout();
            this.SuspendLayout();
            // 
            // _tabControl1
            // 
            this._tabControl1.Controls.Add(this._tabPageCourse);
            this._tabControl1.Controls.Add(this._tabPageClass);
            this._tabControl1.Location = new System.Drawing.Point(12, 12);
            this._tabControl1.Name = "_tabControl1";
            this._tabControl1.SelectedIndex = 0;
            this._tabControl1.Size = new System.Drawing.Size(851, 526);
            this._tabControl1.TabIndex = 0;
            // 
            // _tabPageCourse
            // 
            this._tabPageCourse.Controls.Add(this._buttonDownload);
            this._tabPageCourse.Controls.Add(this._buttonSave);
            this._tabPageCourse.Controls.Add(this._groupBox);
            this._tabPageCourse.Controls.Add(this._buttonAdd);
            this._tabPageCourse.Controls.Add(this._listBox);
            this._tabPageCourse.Location = new System.Drawing.Point(4, 22);
            this._tabPageCourse.Name = "_tabPageCourse";
            this._tabPageCourse.Padding = new System.Windows.Forms.Padding(3);
            this._tabPageCourse.Size = new System.Drawing.Size(843, 500);
            this._tabPageCourse.TabIndex = 0;
            this._tabPageCourse.Text = "課程管理";
            this._tabPageCourse.UseVisualStyleBackColor = true;
            // 
            // _buttonDownload
            // 
            this._buttonDownload.Location = new System.Drawing.Point(102, 432);
            this._buttonDownload.Name = "_buttonDownload";
            this._buttonDownload.Size = new System.Drawing.Size(81, 62);
            this._buttonDownload.TabIndex = 4;
            this._buttonDownload.Text = "匯入資工系全部課程";
            this._buttonDownload.UseVisualStyleBackColor = true;
            this._buttonDownload.Click += new System.EventHandler(this.ClickButtonDownload);
            // 
            // _buttonSave
            // 
            this._buttonSave.Location = new System.Drawing.Point(675, 432);
            this._buttonSave.Name = "_buttonSave";
            this._buttonSave.Size = new System.Drawing.Size(162, 62);
            this._buttonSave.TabIndex = 3;
            this._buttonSave.Text = "儲存";
            this._buttonSave.UseVisualStyleBackColor = true;
            this._buttonSave.Click += new System.EventHandler(this.ClickButtonSave);
            // 
            // _groupBox
            // 
            this._groupBox.Controls.Add(this._dataGridViewTime);
            this._groupBox.Controls.Add(this._comboBoxHour);
            this._groupBox.Controls.Add(this._comboBoxClassName);
            this._groupBox.Controls.Add(this._comboBoxRequired);
            this._groupBox.Controls.Add(this._label11);
            this._groupBox.Controls.Add(this._label10);
            this._groupBox.Controls.Add(this._label9);
            this._groupBox.Controls.Add(this._label8);
            this._groupBox.Controls.Add(this._label7);
            this._groupBox.Controls.Add(this._label6);
            this._groupBox.Controls.Add(this._label5);
            this._groupBox.Controls.Add(this._label4);
            this._groupBox.Controls.Add(this._label3);
            this._groupBox.Controls.Add(this._textBoxAssistant);
            this._groupBox.Controls.Add(this._textBoxNote);
            this._groupBox.Controls.Add(this._textBoxLanguage);
            this._groupBox.Controls.Add(this._textBoxCredit);
            this._groupBox.Controls.Add(this._textBoxTeacher);
            this._groupBox.Controls.Add(this._textBoxStage);
            this._groupBox.Controls.Add(this._textBoxName);
            this._groupBox.Controls.Add(this._label2);
            this._groupBox.Controls.Add(this._textBoxNumber);
            this._groupBox.Controls.Add(this._label1);
            this._groupBox.Controls.Add(this._comboBoxStatus);
            this._groupBox.Location = new System.Drawing.Point(189, 6);
            this._groupBox.Name = "_groupBox";
            this._groupBox.Size = new System.Drawing.Size(648, 424);
            this._groupBox.TabIndex = 2;
            this._groupBox.TabStop = false;
            this._groupBox.Text = "編輯課程";
            // 
            // _dataGridViewTime
            // 
            this._dataGridViewTime.AllowUserToAddRows = false;
            this._dataGridViewTime.AllowUserToDeleteRows = false;
            this._dataGridViewTime.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this._dataGridViewTime.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dataGridViewTime.Location = new System.Drawing.Point(8, 192);
            this._dataGridViewTime.Name = "_dataGridViewTime";
            this._dataGridViewTime.RowTemplate.Height = 24;
            this._dataGridViewTime.Size = new System.Drawing.Size(634, 226);
            this._dataGridViewTime.TabIndex = 23;
            this._dataGridViewTime.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ClickClassTime);
            // 
            // _comboBoxHour
            // 
            this._comboBoxHour.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._comboBoxHour.FormattingEnabled = true;
            this._comboBoxHour.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6"});
            this._comboBoxHour.Location = new System.Drawing.Point(55, 166);
            this._comboBoxHour.Name = "_comboBoxHour";
            this._comboBoxHour.Size = new System.Drawing.Size(121, 20);
            this._comboBoxHour.TabIndex = 22;
            this._comboBoxHour.TextChanged += new System.EventHandler(this.CheckState);
            // 
            // _comboBoxClassName
            // 
            this._comboBoxClassName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._comboBoxClassName.FormattingEnabled = true;
            this._comboBoxClassName.Items.AddRange(new object[] {
            "資工三",
            "電子三甲"});
            this._comboBoxClassName.Location = new System.Drawing.Point(231, 166);
            this._comboBoxClassName.Name = "_comboBoxClassName";
            this._comboBoxClassName.Size = new System.Drawing.Size(128, 20);
            this._comboBoxClassName.TabIndex = 21;
            this._comboBoxClassName.TextChanged += new System.EventHandler(this.CheckState);
            // 
            // _comboBoxRequired
            // 
            this._comboBoxRequired.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._comboBoxRequired.FormattingEnabled = true;
            this._comboBoxRequired.Items.AddRange(new object[] {
            "○",
            "△",
            "☆",
            "●",
            "▲",
            "★"});
            this._comboBoxRequired.Location = new System.Drawing.Point(531, 59);
            this._comboBoxRequired.Name = "_comboBoxRequired";
            this._comboBoxRequired.Size = new System.Drawing.Size(97, 20);
            this._comboBoxRequired.TabIndex = 20;
            this._comboBoxRequired.TextChanged += new System.EventHandler(this.CheckState);
            // 
            // _label11
            // 
            this._label11.AutoSize = true;
            this._label11.Location = new System.Drawing.Point(182, 169);
            this._label11.Name = "_label11";
            this._label11.Size = new System.Drawing.Size(43, 12);
            this._label11.TabIndex = 19;
            this._label11.Text = "班級(*)";
            // 
            // _label10
            // 
            this._label10.AutoSize = true;
            this._label10.Location = new System.Drawing.Point(6, 169);
            this._label10.Name = "_label10";
            this._label10.Size = new System.Drawing.Size(43, 12);
            this._label10.TabIndex = 18;
            this._label10.Text = "時數(*)";
            // 
            // _label9
            // 
            this._label9.AutoSize = true;
            this._label9.Location = new System.Drawing.Point(6, 133);
            this._label9.Name = "_label9";
            this._label9.Size = new System.Drawing.Size(29, 12);
            this._label9.TabIndex = 17;
            this._label9.Text = "備註";
            // 
            // _label8
            // 
            this._label8.AutoSize = true;
            this._label8.Location = new System.Drawing.Point(322, 99);
            this._label8.Name = "_label8";
            this._label8.Size = new System.Drawing.Size(53, 12);
            this._label8.TabIndex = 16;
            this._label8.Text = "授課語言";
            // 
            // _label7
            // 
            this._label7.AutoSize = true;
            this._label7.Location = new System.Drawing.Point(6, 99);
            this._label7.Name = "_label7";
            this._label7.Size = new System.Drawing.Size(53, 12);
            this._label7.TabIndex = 15;
            this._label7.Text = "教學助理";
            // 
            // _label6
            // 
            this._label6.AutoSize = true;
            this._label6.Location = new System.Drawing.Point(316, 62);
            this._label6.Name = "_label6";
            this._label6.Size = new System.Drawing.Size(43, 12);
            this._label6.TabIndex = 14;
            this._label6.Text = "教師(*)";
            // 
            // _label5
            // 
            this._label5.AutoSize = true;
            this._label5.Location = new System.Drawing.Point(155, 62);
            this._label5.Name = "_label5";
            this._label5.Size = new System.Drawing.Size(43, 12);
            this._label5.TabIndex = 13;
            this._label5.Text = "學分(*)";
            // 
            // _label4
            // 
            this._label4.AutoSize = true;
            this._label4.Location = new System.Drawing.Point(6, 62);
            this._label4.Name = "_label4";
            this._label4.Size = new System.Drawing.Size(43, 12);
            this._label4.TabIndex = 12;
            this._label4.Text = "階級(*)";
            // 
            // _label3
            // 
            this._label3.AutoSize = true;
            this._label3.Location = new System.Drawing.Point(494, 62);
            this._label3.Name = "_label3";
            this._label3.Size = new System.Drawing.Size(31, 12);
            this._label3.TabIndex = 11;
            this._label3.Text = "修(*)";
            // 
            // _textBoxAssistant
            // 
            this._textBoxAssistant.Location = new System.Drawing.Point(65, 96);
            this._textBoxAssistant.Name = "_textBoxAssistant";
            this._textBoxAssistant.Size = new System.Drawing.Size(245, 22);
            this._textBoxAssistant.TabIndex = 10;
            // 
            // _textBoxNote
            // 
            this._textBoxNote.Location = new System.Drawing.Point(41, 130);
            this._textBoxNote.Name = "_textBoxNote";
            this._textBoxNote.Size = new System.Drawing.Size(447, 22);
            this._textBoxNote.TabIndex = 9;
            // 
            // _textBoxLanguage
            // 
            this._textBoxLanguage.Location = new System.Drawing.Point(381, 96);
            this._textBoxLanguage.Name = "_textBoxLanguage";
            this._textBoxLanguage.Size = new System.Drawing.Size(247, 22);
            this._textBoxLanguage.TabIndex = 8;
            // 
            // _textBoxCredit
            // 
            this._textBoxCredit.Location = new System.Drawing.Point(204, 59);
            this._textBoxCredit.Name = "_textBoxCredit";
            this._textBoxCredit.Size = new System.Drawing.Size(106, 22);
            this._textBoxCredit.TabIndex = 7;
            this._textBoxCredit.TextChanged += new System.EventHandler(this.CheckState);
            this._textBoxCredit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PressKeyInNumber);
            // 
            // _textBoxTeacher
            // 
            this._textBoxTeacher.Location = new System.Drawing.Point(365, 59);
            this._textBoxTeacher.Name = "_textBoxTeacher";
            this._textBoxTeacher.Size = new System.Drawing.Size(123, 22);
            this._textBoxTeacher.TabIndex = 6;
            this._textBoxTeacher.TextChanged += new System.EventHandler(this.CheckState);
            // 
            // _textBoxStage
            // 
            this._textBoxStage.Location = new System.Drawing.Point(55, 59);
            this._textBoxStage.Name = "_textBoxStage";
            this._textBoxStage.Size = new System.Drawing.Size(94, 22);
            this._textBoxStage.TabIndex = 5;
            this._textBoxStage.TextChanged += new System.EventHandler(this.CheckState);
            this._textBoxStage.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PressKeyInNumber);
            // 
            // _textBoxName
            // 
            this._textBoxName.Location = new System.Drawing.Point(389, 21);
            this._textBoxName.Name = "_textBoxName";
            this._textBoxName.Size = new System.Drawing.Size(239, 22);
            this._textBoxName.TabIndex = 4;
            this._textBoxName.TextChanged += new System.EventHandler(this.CheckState);
            // 
            // _label2
            // 
            this._label2.AutoSize = true;
            this._label2.Location = new System.Drawing.Point(316, 24);
            this._label2.Name = "_label2";
            this._label2.Size = new System.Drawing.Size(67, 12);
            this._label2.TabIndex = 3;
            this._label2.Text = "課程名稱(*)";
            // 
            // _textBoxNumber
            // 
            this._textBoxNumber.Location = new System.Drawing.Point(182, 21);
            this._textBoxNumber.Name = "_textBoxNumber";
            this._textBoxNumber.Size = new System.Drawing.Size(128, 22);
            this._textBoxNumber.TabIndex = 2;
            this._textBoxNumber.TextChanged += new System.EventHandler(this.CheckState);
            this._textBoxNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PressKeyInNumber);
            // 
            // _label1
            // 
            this._label1.AutoSize = true;
            this._label1.Font = new System.Drawing.Font("新細明體", 9F);
            this._label1.Location = new System.Drawing.Point(133, 24);
            this._label1.Name = "_label1";
            this._label1.Size = new System.Drawing.Size(43, 12);
            this._label1.TabIndex = 1;
            this._label1.Text = "課號(*)";
            // 
            // _comboBoxStatus
            // 
            this._comboBoxStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._comboBoxStatus.FormattingEnabled = true;
            this._comboBoxStatus.Items.AddRange(new object[] {
            "開課",
            "停課"});
            this._comboBoxStatus.Location = new System.Drawing.Point(6, 23);
            this._comboBoxStatus.Name = "_comboBoxStatus";
            this._comboBoxStatus.Size = new System.Drawing.Size(121, 20);
            this._comboBoxStatus.TabIndex = 0;
            this._comboBoxStatus.TextChanged += new System.EventHandler(this.CheckState);
            // 
            // _buttonAdd
            // 
            this._buttonAdd.Location = new System.Drawing.Point(6, 432);
            this._buttonAdd.Name = "_buttonAdd";
            this._buttonAdd.Size = new System.Drawing.Size(90, 62);
            this._buttonAdd.TabIndex = 1;
            this._buttonAdd.Text = "新增課程";
            this._buttonAdd.UseVisualStyleBackColor = true;
            this._buttonAdd.Click += new System.EventHandler(this.ClickButtonAdd);
            // 
            // _listBox
            // 
            this._listBox.FormattingEnabled = true;
            this._listBox.ItemHeight = 12;
            this._listBox.Location = new System.Drawing.Point(6, 6);
            this._listBox.Name = "_listBox";
            this._listBox.Size = new System.Drawing.Size(177, 424);
            this._listBox.TabIndex = 0;
            this._listBox.Click += new System.EventHandler(this.ClickListBox);
            // 
            // _tabPageClass
            // 
            this._tabPageClass.Controls.Add(this._buttonSaveClass);
            this._tabPageClass.Controls.Add(this._buttonAddClass);
            this._tabPageClass.Controls.Add(this._groupBoxClass);
            this._tabPageClass.Controls.Add(this._listBoxClass);
            this._tabPageClass.Location = new System.Drawing.Point(4, 22);
            this._tabPageClass.Name = "_tabPageClass";
            this._tabPageClass.Padding = new System.Windows.Forms.Padding(3);
            this._tabPageClass.Size = new System.Drawing.Size(843, 500);
            this._tabPageClass.TabIndex = 1;
            this._tabPageClass.Text = "班級管理";
            this._tabPageClass.UseVisualStyleBackColor = true;
            // 
            // _buttonSaveClass
            // 
            this._buttonSaveClass.Enabled = false;
            this._buttonSaveClass.Location = new System.Drawing.Point(644, 426);
            this._buttonSaveClass.Name = "_buttonSaveClass";
            this._buttonSaveClass.Size = new System.Drawing.Size(193, 68);
            this._buttonSaveClass.TabIndex = 3;
            this._buttonSaveClass.Text = "新增";
            this._buttonSaveClass.UseVisualStyleBackColor = true;
            this._buttonSaveClass.Click += new System.EventHandler(this.ClickButtonSaveClass);
            // 
            // _buttonAddClass
            // 
            this._buttonAddClass.Location = new System.Drawing.Point(6, 426);
            this._buttonAddClass.Name = "_buttonAddClass";
            this._buttonAddClass.Size = new System.Drawing.Size(193, 68);
            this._buttonAddClass.TabIndex = 2;
            this._buttonAddClass.Text = "新增班級";
            this._buttonAddClass.UseVisualStyleBackColor = true;
            this._buttonAddClass.Click += new System.EventHandler(this.ClickButtonAddClass);
            // 
            // _groupBoxClass
            // 
            this._groupBoxClass.Controls.Add(this._labelCourse);
            this._groupBoxClass.Controls.Add(this._listBoxCourse);
            this._groupBoxClass.Controls.Add(this._textBoxClass);
            this._groupBoxClass.Controls.Add(this._labelClass);
            this._groupBoxClass.Location = new System.Drawing.Point(205, 8);
            this._groupBoxClass.Name = "_groupBoxClass";
            this._groupBoxClass.Size = new System.Drawing.Size(632, 412);
            this._groupBoxClass.TabIndex = 1;
            this._groupBoxClass.TabStop = false;
            this._groupBoxClass.Text = "班級";
            // 
            // _labelCourse
            // 
            this._labelCourse.AutoSize = true;
            this._labelCourse.Location = new System.Drawing.Point(6, 106);
            this._labelCourse.Name = "_labelCourse";
            this._labelCourse.Size = new System.Drawing.Size(65, 12);
            this._labelCourse.TabIndex = 3;
            this._labelCourse.Text = "班級內課程";
            // 
            // _listBoxCourse
            // 
            this._listBoxCourse.FormattingEnabled = true;
            this._listBoxCourse.ItemHeight = 12;
            this._listBoxCourse.Location = new System.Drawing.Point(8, 131);
            this._listBoxCourse.Name = "_listBoxCourse";
            this._listBoxCourse.Size = new System.Drawing.Size(617, 268);
            this._listBoxCourse.TabIndex = 2;
            // 
            // _textBoxClass
            // 
            this._textBoxClass.Enabled = false;
            this._textBoxClass.Location = new System.Drawing.Point(82, 45);
            this._textBoxClass.Name = "_textBoxClass";
            this._textBoxClass.Size = new System.Drawing.Size(543, 22);
            this._textBoxClass.TabIndex = 1;
            this._textBoxClass.TextChanged += new System.EventHandler(this.CheckClassState);
            // 
            // _labelClass
            // 
            this._labelClass.AutoSize = true;
            this._labelClass.Location = new System.Drawing.Point(6, 48);
            this._labelClass.Name = "_labelClass";
            this._labelClass.Size = new System.Drawing.Size(70, 12);
            this._labelClass.TabIndex = 0;
            this._labelClass.Text = "班級名稱 (*)";
            // 
            // _listBoxClass
            // 
            this._listBoxClass.FormattingEnabled = true;
            this._listBoxClass.ItemHeight = 12;
            this._listBoxClass.Location = new System.Drawing.Point(6, 8);
            this._listBoxClass.Name = "_listBoxClass";
            this._listBoxClass.Size = new System.Drawing.Size(193, 412);
            this._listBoxClass.TabIndex = 0;
            this._listBoxClass.Click += new System.EventHandler(this.ClickListBoxClass);
            // 
            // ManagementView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(875, 550);
            this.Controls.Add(this._tabControl1);
            this.Name = "ManagementView";
            this.Text = "ManagementView";
            this._tabControl1.ResumeLayout(false);
            this._tabPageCourse.ResumeLayout(false);
            this._groupBox.ResumeLayout(false);
            this._groupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dataGridViewTime)).EndInit();
            this._tabPageClass.ResumeLayout(false);
            this._groupBoxClass.ResumeLayout(false);
            this._groupBoxClass.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl _tabControl1;
        private System.Windows.Forms.TabPage _tabPageCourse;
        private System.Windows.Forms.GroupBox _groupBox;
        private System.Windows.Forms.Label _label1;
        private System.Windows.Forms.ComboBox _comboBoxStatus;
        private System.Windows.Forms.Button _buttonAdd;
        private System.Windows.Forms.ListBox _listBox;
        private System.Windows.Forms.TabPage _tabPageClass;
        private System.Windows.Forms.DataGridView _dataGridViewTime;
        private System.Windows.Forms.ComboBox _comboBoxHour;
        private System.Windows.Forms.ComboBox _comboBoxClassName;
        private System.Windows.Forms.ComboBox _comboBoxRequired;
        private System.Windows.Forms.Label _label11;
        private System.Windows.Forms.Label _label10;
        private System.Windows.Forms.Label _label9;
        private System.Windows.Forms.Label _label8;
        private System.Windows.Forms.Label _label7;
        private System.Windows.Forms.Label _label6;
        private System.Windows.Forms.Label _label5;
        private System.Windows.Forms.Label _label4;
        private System.Windows.Forms.Label _label3;
        private System.Windows.Forms.TextBox _textBoxAssistant;
        private System.Windows.Forms.TextBox _textBoxNote;
        private System.Windows.Forms.TextBox _textBoxLanguage;
        private System.Windows.Forms.TextBox _textBoxCredit;
        private System.Windows.Forms.TextBox _textBoxTeacher;
        private System.Windows.Forms.TextBox _textBoxStage;
        private System.Windows.Forms.TextBox _textBoxName;
        private System.Windows.Forms.Label _label2;
        private System.Windows.Forms.TextBox _textBoxNumber;
        private System.Windows.Forms.Button _buttonSave;
        private System.Windows.Forms.Button _buttonDownload;
        private System.Windows.Forms.ListBox _listBoxClass;
        private System.Windows.Forms.GroupBox _groupBoxClass;
        private System.Windows.Forms.Label _labelClass;
        private System.Windows.Forms.ListBox _listBoxCourse;
        private System.Windows.Forms.TextBox _textBoxClass;
        private System.Windows.Forms.Button _buttonSaveClass;
        private System.Windows.Forms.Button _buttonAddClass;
        private System.Windows.Forms.Label _labelCourse;
    }
}