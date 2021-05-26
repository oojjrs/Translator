
namespace Translator
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.loadButton = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.saveButton = new System.Windows.Forms.Button();
            this.wordListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // loadButton
            // 
            this.loadButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.loadButton.Location = new System.Drawing.Point(0, 0);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(1481, 34);
            this.loadButton.TabIndex = 0;
            this.loadButton.Text = "번역할 파일 불러오기";
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "txt";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "txt";
            // 
            // saveButton
            // 
            this.saveButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.saveButton.Location = new System.Drawing.Point(0, 34);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(1481, 34);
            this.saveButton.TabIndex = 2;
            this.saveButton.Text = "번역본 저장하기";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // wordListView
            // 
            this.wordListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.wordListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wordListView.Font = new System.Drawing.Font("D2Coding", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.wordListView.FullRowSelect = true;
            this.wordListView.HideSelection = false;
            this.wordListView.Location = new System.Drawing.Point(0, 68);
            this.wordListView.Name = "wordListView";
            this.wordListView.Size = new System.Drawing.Size(1481, 794);
            this.wordListView.TabIndex = 3;
            this.wordListView.UseCompatibleStateImageBehavior = false;
            this.wordListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Name = "columnHeader1";
            this.columnHeader1.Text = "Line";
            this.columnHeader1.Width = 150;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Name = "columnHeader2";
            this.columnHeader2.Text = "원본";
            this.columnHeader2.Width = 400;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Name = "columnHeader3";
            this.columnHeader3.Text = "번역(ko-KR)";
            this.columnHeader3.Width = 400;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1481, 862);
            this.Controls.Add(this.wordListView);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.loadButton);
            this.Name = "MainForm";
            this.Text = "번역기";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.ListView wordListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
    }
}

