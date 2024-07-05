
namespace DrawingForm
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this._rectangle = new System.Windows.Forms.Button();
            this._ellipse = new System.Windows.Forms.Button();
            this._clear = new System.Windows.Forms.Button();
            this._tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this._line = new System.Windows.Forms.Button();
            this._save = new System.Windows.Forms.Button();
            this._load = new System.Windows.Forms.Button();
            this._tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this._undo = new System.Windows.Forms.Button();
            this._redo = new System.Windows.Forms.Button();
            this._info = new System.Windows.Forms.Label();
            this._tableLayoutPanel1.SuspendLayout();
            this._tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // _rectangle
            // 
            this._rectangle.Location = new System.Drawing.Point(3, 3);
            this._rectangle.Name = "_rectangle";
            this._rectangle.Size = new System.Drawing.Size(150, 47);
            this._rectangle.TabIndex = 0;
            this._rectangle.Text = "Rectangle";
            this._rectangle.UseVisualStyleBackColor = true;
            this._rectangle.Click += new System.EventHandler(this.HandleRectangleButtonClick);
            // 
            // _ellipse
            // 
            this._ellipse.Location = new System.Drawing.Point(159, 3);
            this._ellipse.Name = "_ellipse";
            this._ellipse.Size = new System.Drawing.Size(150, 47);
            this._ellipse.TabIndex = 1;
            this._ellipse.Text = "Ellipse";
            this._ellipse.UseVisualStyleBackColor = true;
            this._ellipse.Click += new System.EventHandler(this.HandleEllipseButtonClick);
            // 
            // _clear
            // 
            this._clear.Location = new System.Drawing.Point(462, 3);
            this._clear.Name = "_clear";
            this._clear.Size = new System.Drawing.Size(138, 47);
            this._clear.TabIndex = 2;
            this._clear.Text = "Clear";
            this._clear.UseVisualStyleBackColor = true;
            this._clear.Click += new System.EventHandler(this.HandleClearButtonClick);
            // 
            // _tableLayoutPanel1
            // 
            this._tableLayoutPanel1.ColumnCount = 6;
            this._tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 147F));
            this._tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 152F));
            this._tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 89F));
            this._tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 89F));
            this._tableLayoutPanel1.Controls.Add(this._ellipse, 1, 0);
            this._tableLayoutPanel1.Controls.Add(this._rectangle, 0, 0);
            this._tableLayoutPanel1.Controls.Add(this._line, 2, 0);
            this._tableLayoutPanel1.Controls.Add(this._clear, 3, 0);
            this._tableLayoutPanel1.Controls.Add(this._save, 4, 0);
            this._tableLayoutPanel1.Controls.Add(this._load, 5, 0);
            this._tableLayoutPanel1.Location = new System.Drawing.Point(12, 36);
            this._tableLayoutPanel1.Name = "_tableLayoutPanel1";
            this._tableLayoutPanel1.RowCount = 1;
            this._tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._tableLayoutPanel1.Size = new System.Drawing.Size(789, 61);
            this._tableLayoutPanel1.TabIndex = 3;
            // 
            // _line
            // 
            this._line.Location = new System.Drawing.Point(315, 3);
            this._line.Name = "_line";
            this._line.Size = new System.Drawing.Size(138, 47);
            this._line.TabIndex = 3;
            this._line.Text = "Line";
            this._line.UseVisualStyleBackColor = true;
            this._line.Click += new System.EventHandler(this.HandleLineButtonClick);
            // 
            // _save
            // 
            this._save.Location = new System.Drawing.Point(614, 3);
            this._save.Name = "_save";
            this._save.Size = new System.Drawing.Size(83, 47);
            this._save.TabIndex = 4;
            this._save.Text = "Save";
            this._save.UseVisualStyleBackColor = true;
            this._save.Click += new System.EventHandler(this.HandleSaveButtonClick);
            // 
            // _load
            // 
            this._load.Location = new System.Drawing.Point(703, 3);
            this._load.Name = "_load";
            this._load.Size = new System.Drawing.Size(83, 47);
            this._load.TabIndex = 5;
            this._load.Text = "Load";
            this._load.UseVisualStyleBackColor = true;
            this._load.Click += new System.EventHandler(this.HandleLoadButtonClick);
            // 
            // _tableLayoutPanel2
            // 
            this._tableLayoutPanel2.ColumnCount = 2;
            this._tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this._tableLayoutPanel2.Controls.Add(this._undo, 0, 0);
            this._tableLayoutPanel2.Controls.Add(this._redo, 1, 0);
            this._tableLayoutPanel2.Location = new System.Drawing.Point(12, 4);
            this._tableLayoutPanel2.Name = "_tableLayoutPanel2";
            this._tableLayoutPanel2.RowCount = 1;
            this._tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._tableLayoutPanel2.Size = new System.Drawing.Size(200, 30);
            this._tableLayoutPanel2.TabIndex = 4;
            // 
            // _undo
            // 
            this._undo.Location = new System.Drawing.Point(3, 3);
            this._undo.Name = "_undo";
            this._undo.Size = new System.Drawing.Size(75, 23);
            this._undo.TabIndex = 0;
            this._undo.Text = "Undo";
            this._undo.UseVisualStyleBackColor = true;
            this._undo.Click += new System.EventHandler(this.HandleUndoButtonClick);
            // 
            // _redo
            // 
            this._redo.Location = new System.Drawing.Point(103, 3);
            this._redo.Name = "_redo";
            this._redo.Size = new System.Drawing.Size(75, 23);
            this._redo.TabIndex = 1;
            this._redo.Text = "Redo";
            this._redo.UseVisualStyleBackColor = true;
            this._redo.Click += new System.EventHandler(this.HandleRedoButtonClick);
            // 
            // _info
            // 
            this._info.AutoSize = true;
            this._info.BackColor = System.Drawing.SystemColors.Info;
            this._info.Font = new System.Drawing.Font("新細明體", 16F);
            this._info.Location = new System.Drawing.Point(546, 419);
            this._info.Name = "_info";
            this._info.Size = new System.Drawing.Size(144, 22);
            this._info.TabIndex = 5;
            this._info.Text = "Nothing Chosen";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this._info);
            this.Controls.Add(this._tableLayoutPanel2);
            this.Controls.Add(this._tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this._tableLayoutPanel1.ResumeLayout(false);
            this._tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _rectangle;
        private System.Windows.Forms.Button _ellipse;
        private System.Windows.Forms.Button _clear;
        private System.Windows.Forms.TableLayoutPanel _tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel _tableLayoutPanel2;
        private System.Windows.Forms.Button _undo;
        private System.Windows.Forms.Button _redo;
        private System.Windows.Forms.Button _line;
        private System.Windows.Forms.Label _info;
        private System.Windows.Forms.Button _save;
        private System.Windows.Forms.Button _load;
    }
}

