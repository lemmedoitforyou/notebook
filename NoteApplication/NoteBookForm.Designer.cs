namespace NoteApplication
{
    partial class NoteBookForm
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
            this.titleLabel = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.newNoteButton = new System.Windows.Forms.Button();
            this.selectedFileComboBox = new System.Windows.Forms.ComboBox();
            this.selectFileLabel = new System.Windows.Forms.Label();
            this.fileNameLabel = new System.Windows.Forms.Label();
            this.fileContentsRichTextBox = new System.Windows.Forms.RichTextBox();
            this.fileNameTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.titleLabel.ForeColor = System.Drawing.Color.DarkMagenta;
            this.titleLabel.Location = new System.Drawing.Point(450, 11);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(159, 37);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "NoteBook";
            // 
            // saveButton
            // 
            this.saveButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.saveButton.ForeColor = System.Drawing.Color.DarkMagenta;
            this.saveButton.Location = new System.Drawing.Point(12, 490);
            this.saveButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(109, 54);
            this.saveButton.TabIndex = 1;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.deleteButton.ForeColor = System.Drawing.Color.DarkMagenta;
            this.deleteButton.Location = new System.Drawing.Point(127, 490);
            this.deleteButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(168, 54);
            this.deleteButton.TabIndex = 2;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // newNoteButton
            // 
            this.newNoteButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.newNoteButton.ForeColor = System.Drawing.Color.DarkMagenta;
            this.newNoteButton.Location = new System.Drawing.Point(300, 490);
            this.newNoteButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.newNoteButton.Name = "newNoteButton";
            this.newNoteButton.Size = new System.Drawing.Size(183, 54);
            this.newNoteButton.TabIndex = 3;
            this.newNoteButton.Text = "New Note";
            this.newNoteButton.UseVisualStyleBackColor = true;
            this.newNoteButton.Click += new System.EventHandler(this.newNoteButton_Click);
            // 
            // selectedFileComboBox
            // 
            this.selectedFileComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.selectedFileComboBox.Font = new System.Drawing.Font("Microsoft JhengHei UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectedFileComboBox.ForeColor = System.Drawing.SystemColors.WindowText;
            this.selectedFileComboBox.FormattingEnabled = true;
            this.selectedFileComboBox.Location = new System.Drawing.Point(12, 66);
            this.selectedFileComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.selectedFileComboBox.Name = "selectedFileComboBox";
            this.selectedFileComboBox.Size = new System.Drawing.Size(213, 30);
            this.selectedFileComboBox.Sorted = true;
            this.selectedFileComboBox.TabIndex = 4;
            this.selectedFileComboBox.SelectedIndexChanged += new System.EventHandler(this.selectedFileComboBox_SelectedIndexChanged);
            // 
            // selectFileLabel
            // 
            this.selectFileLabel.AutoSize = true;
            this.selectFileLabel.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.selectFileLabel.ForeColor = System.Drawing.Color.DarkMagenta;
            this.selectFileLabel.Location = new System.Drawing.Point(15, 33);
            this.selectFileLabel.Name = "selectFileLabel";
            this.selectFileLabel.Size = new System.Drawing.Size(108, 23);
            this.selectFileLabel.TabIndex = 5;
            this.selectFileLabel.Text = "Select File";
            // 
            // fileNameLabel
            // 
            this.fileNameLabel.AutoSize = true;
            this.fileNameLabel.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.fileNameLabel.ForeColor = System.Drawing.Color.DarkMagenta;
            this.fileNameLabel.Location = new System.Drawing.Point(830, 57);
            this.fileNameLabel.Name = "fileNameLabel";
            this.fileNameLabel.Size = new System.Drawing.Size(107, 23);
            this.fileNameLabel.TabIndex = 6;
            this.fileNameLabel.Text = "File Name";
            // 
            // fileContentsRichTextBox
            // 
            this.fileContentsRichTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.fileContentsRichTextBox.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.fileContentsRichTextBox.ForeColor = System.Drawing.Color.DarkBlue;
            this.fileContentsRichTextBox.Location = new System.Drawing.Point(12, 129);
            this.fileContentsRichTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.fileContentsRichTextBox.Name = "fileContentsRichTextBox";
            this.fileContentsRichTextBox.Size = new System.Drawing.Size(1015, 355);
            this.fileContentsRichTextBox.TabIndex = 7;
            this.fileContentsRichTextBox.Text = "";
            // 
            // fileNameTextBox
            // 
            this.fileNameTextBox.Font = new System.Drawing.Font("Microsoft JhengHei UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fileNameTextBox.ForeColor = System.Drawing.SystemColors.WindowText;
            this.fileNameTextBox.Location = new System.Drawing.Point(825, 91);
            this.fileNameTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.fileNameTextBox.Name = "fileNameTextBox";
            this.fileNameTextBox.Size = new System.Drawing.Size(201, 29);
            this.fileNameTextBox.TabIndex = 8;
            // 
            // NoteBookForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LavenderBlush;
            this.ClientSize = new System.Drawing.Size(1043, 558);
            this.Controls.Add(this.fileNameTextBox);
            this.Controls.Add(this.fileContentsRichTextBox);
            this.Controls.Add(this.fileNameLabel);
            this.Controls.Add(this.selectFileLabel);
            this.Controls.Add(this.selectedFileComboBox);
            this.Controls.Add(this.newNoteButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.titleLabel);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximumSize = new System.Drawing.Size(1061, 605);
            this.MinimumSize = new System.Drawing.Size(1061, 605);
            this.Name = "NoteBookForm";
            this.Text = "NoteBook";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button newNoteButton;
        private System.Windows.Forms.ComboBox selectedFileComboBox;
        private System.Windows.Forms.Label selectFileLabel;
        private System.Windows.Forms.Label fileNameLabel;
        private System.Windows.Forms.RichTextBox fileContentsRichTextBox;
        private System.Windows.Forms.TextBox fileNameTextBox;
    }
}

