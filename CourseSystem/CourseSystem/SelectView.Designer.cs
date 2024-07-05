
namespace CourseSystem
{
    partial class SelectView
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
            this._buttonSend = new System.Windows.Forms.Button();
            this._buttonSelectResult = new System.Windows.Forms.Button();
            this._tabControl1 = new System.Windows.Forms.TabControl();
            this._tabPageCSIE = new System.Windows.Forms.TabPage();
            this._dataGridViewCSIE = new System.Windows.Forms.DataGridView();
            this._checkBoxCSIE = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this._tabPageEE = new System.Windows.Forms.TabPage();
            this._dataGridViewEE = new System.Windows.Forms.DataGridView();
            this._checkBoxEE = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this._tabControl1.SuspendLayout();
            this._tabPageCSIE.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dataGridViewCSIE)).BeginInit();
            this._tabPageEE.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dataGridViewEE)).BeginInit();
            this.SuspendLayout();
            // 
            // _buttonSend
            // 
            this._buttonSend.Enabled = false;
            this._buttonSend.Location = new System.Drawing.Point(472, 441);
            this._buttonSend.Name = "_buttonSend";
            this._buttonSend.Size = new System.Drawing.Size(199, 62);
            this._buttonSend.TabIndex = 1;
            this._buttonSend.Text = "確認送出";
            this._buttonSend.UseVisualStyleBackColor = true;
            this._buttonSend.Click += new System.EventHandler(this.ClickSend);
            // 
            // _buttonSelectResult
            // 
            this._buttonSelectResult.Location = new System.Drawing.Point(677, 441);
            this._buttonSelectResult.Name = "_buttonSelectResult";
            this._buttonSelectResult.Size = new System.Drawing.Size(199, 62);
            this._buttonSelectResult.TabIndex = 2;
            this._buttonSelectResult.Text = "查看選課結果";
            this._buttonSelectResult.UseVisualStyleBackColor = true;
            this._buttonSelectResult.Click += new System.EventHandler(this.ClickSelectResult);
            // 
            // _tabControl1
            // 
            this._tabControl1.Controls.Add(this._tabPageCSIE);
            this._tabControl1.Controls.Add(this._tabPageEE);
            this._tabControl1.Location = new System.Drawing.Point(12, 12);
            this._tabControl1.Name = "_tabControl1";
            this._tabControl1.SelectedIndex = 0;
            this._tabControl1.Size = new System.Drawing.Size(859, 423);
            this._tabControl1.TabIndex = 3;
            // 
            // _tabPageCSIE
            // 
            this._tabPageCSIE.Controls.Add(this._dataGridViewCSIE);
            this._tabPageCSIE.Location = new System.Drawing.Point(4, 22);
            this._tabPageCSIE.Name = "_tabPageCSIE";
            this._tabPageCSIE.Padding = new System.Windows.Forms.Padding(3);
            this._tabPageCSIE.Size = new System.Drawing.Size(851, 397);
            this._tabPageCSIE.TabIndex = 0;
            this._tabPageCSIE.Text = "資工三";
            this._tabPageCSIE.UseVisualStyleBackColor = true;
            // 
            // _dataGridViewCSIE
            // 
            this._dataGridViewCSIE.AllowUserToAddRows = false;
            this._dataGridViewCSIE.AllowUserToDeleteRows = false;
            this._dataGridViewCSIE.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dataGridViewCSIE.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._checkBoxCSIE});
            this._dataGridViewCSIE.Location = new System.Drawing.Point(3, 3);
            this._dataGridViewCSIE.Name = "_dataGridViewCSIE";
            this._dataGridViewCSIE.RowTemplate.Height = 24;
            this._dataGridViewCSIE.Size = new System.Drawing.Size(845, 391);
            this._dataGridViewCSIE.TabIndex = 0;
            this._dataGridViewCSIE.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ClickCheckBox);
            // 
            // _checkBoxCSIE
            // 
            this._checkBoxCSIE.HeaderText = "選";
            this._checkBoxCSIE.Name = "_checkBoxCSIE";
            // 
            // _tabPageEE
            // 
            this._tabPageEE.Controls.Add(this._dataGridViewEE);
            this._tabPageEE.Location = new System.Drawing.Point(4, 22);
            this._tabPageEE.Name = "_tabPageEE";
            this._tabPageEE.Padding = new System.Windows.Forms.Padding(3);
            this._tabPageEE.Size = new System.Drawing.Size(851, 397);
            this._tabPageEE.TabIndex = 1;
            this._tabPageEE.Text = "電子三甲";
            this._tabPageEE.UseVisualStyleBackColor = true;
            // 
            // _dataGridViewEE
            // 
            this._dataGridViewEE.AllowUserToAddRows = false;
            this._dataGridViewEE.AllowUserToDeleteRows = false;
            this._dataGridViewEE.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dataGridViewEE.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._checkBoxEE});
            this._dataGridViewEE.Location = new System.Drawing.Point(3, 3);
            this._dataGridViewEE.Name = "_dataGridViewEE";
            this._dataGridViewEE.RowTemplate.Height = 24;
            this._dataGridViewEE.Size = new System.Drawing.Size(845, 391);
            this._dataGridViewEE.TabIndex = 0;
            this._dataGridViewEE.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ClickCheckBox);
            // 
            // _checkBoxEE
            // 
            this._checkBoxEE.HeaderText = "選";
            this._checkBoxEE.Name = "_checkBoxEE";
            this._checkBoxEE.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this._checkBoxEE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // SelectView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(883, 512);
            this.Controls.Add(this._tabControl1);
            this.Controls.Add(this._buttonSelectResult);
            this.Controls.Add(this._buttonSend);
            this.Name = "SelectView";
            this.Text = "CourseView";
            this._tabControl1.ResumeLayout(false);
            this._tabPageCSIE.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._dataGridViewCSIE)).EndInit();
            this._tabPageEE.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._dataGridViewEE)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button _buttonSend;
        private System.Windows.Forms.Button _buttonSelectResult;
        private System.Windows.Forms.TabControl _tabControl1;
        private System.Windows.Forms.TabPage _tabPageCSIE;
        private System.Windows.Forms.TabPage _tabPageEE;
        private System.Windows.Forms.DataGridView _dataGridViewEE;
        private System.Windows.Forms.DataGridView _dataGridViewCSIE;
        private System.Windows.Forms.DataGridViewCheckBoxColumn _checkBoxCSIE;
        private System.Windows.Forms.DataGridViewCheckBoxColumn _checkBoxEE;
    }
}