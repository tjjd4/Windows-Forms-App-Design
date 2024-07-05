
namespace CourseSystem
{
    partial class StartUpView
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
            this._buttonSelect = new System.Windows.Forms.Button();
            this._buttonManagement = new System.Windows.Forms.Button();
            this._buttonExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _buttonSelect
            // 
            this._buttonSelect.Font = new System.Drawing.Font("新細明體", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._buttonSelect.Location = new System.Drawing.Point(12, 12);
            this._buttonSelect.Name = "_buttonSelect";
            this._buttonSelect.Size = new System.Drawing.Size(776, 175);
            this._buttonSelect.TabIndex = 0;
            this._buttonSelect.Text = "Course Select System";
            this._buttonSelect.UseVisualStyleBackColor = true;
            this._buttonSelect.Click += new System.EventHandler(this.ClickSelect);
            // 
            // _buttonManagement
            // 
            this._buttonManagement.Font = new System.Drawing.Font("新細明體", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._buttonManagement.Location = new System.Drawing.Point(12, 193);
            this._buttonManagement.Name = "_buttonManagement";
            this._buttonManagement.Size = new System.Drawing.Size(776, 175);
            this._buttonManagement.TabIndex = 1;
            this._buttonManagement.Text = "Course Management System";
            this._buttonManagement.UseVisualStyleBackColor = true;
            this._buttonManagement.Click += new System.EventHandler(this.ClickManagement);
            // 
            // _buttonExit
            // 
            this._buttonExit.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._buttonExit.Location = new System.Drawing.Point(617, 374);
            this._buttonExit.Name = "_buttonExit";
            this._buttonExit.Size = new System.Drawing.Size(171, 64);
            this._buttonExit.TabIndex = 2;
            this._buttonExit.Text = "Exit";
            this._buttonExit.UseVisualStyleBackColor = true;
            this._buttonExit.Click += new System.EventHandler(this.ClickExit);
            // 
            // StartUpView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this._buttonExit);
            this.Controls.Add(this._buttonManagement);
            this.Controls.Add(this._buttonSelect);
            this.Name = "StartUpView";
            this.Text = "StartUpView";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button _buttonSelect;
        private System.Windows.Forms.Button _buttonManagement;
        private System.Windows.Forms.Button _buttonExit;
    }
}