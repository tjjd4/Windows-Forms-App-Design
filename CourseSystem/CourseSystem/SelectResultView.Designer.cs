
namespace CourseSystem
{
    partial class SelectResultView
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
            this._dataGridViewResult = new System.Windows.Forms.DataGridView();
            this._columnDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this._dataGridViewResult)).BeginInit();
            this.SuspendLayout();
            // 
            // _dataGridViewResult
            // 
            this._dataGridViewResult.AllowUserToAddRows = false;
            this._dataGridViewResult.AllowUserToDeleteRows = false;
            this._dataGridViewResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dataGridViewResult.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._columnDelete});
            this._dataGridViewResult.Location = new System.Drawing.Point(12, 12);
            this._dataGridViewResult.Name = "_dataGridViewResult";
            this._dataGridViewResult.RowTemplate.Height = 24;
            this._dataGridViewResult.Size = new System.Drawing.Size(776, 426);
            this._dataGridViewResult.TabIndex = 0;
            this._dataGridViewResult.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ClickDeleteButton);
            // 
            // _columnDelete
            // 
            this._columnDelete.HeaderText = "退";
            this._columnDelete.Name = "_columnDelete";
            this._columnDelete.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this._columnDelete.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // SelectResultView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this._dataGridViewResult);
            this.Name = "SelectResultView";
            this.Text = "SelectedCourseView";
            ((System.ComponentModel.ISupportInitialize)(this._dataGridViewResult)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView _dataGridViewResult;
        private System.Windows.Forms.DataGridViewButtonColumn _columnDelete;
    }
}