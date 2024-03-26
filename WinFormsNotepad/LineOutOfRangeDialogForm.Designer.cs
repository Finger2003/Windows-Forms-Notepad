namespace WinFormsNotepad
{
    partial class LineOutOfRangeDialogForm
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
            mainLabel = new Label();
            okButton = new Button();
            emptyLabel = new Label();
            SuspendLayout();
            // 
            // mainLabel
            // 
            mainLabel.AutoSize = true;
            mainLabel.BackColor = Color.White;
            mainLabel.Location = new Point(5, 23);
            mainLabel.Name = "mainLabel";
            mainLabel.Size = new Size(280, 15);
            mainLabel.TabIndex = 0;
            mainLabel.Text = "The line number is beyond the total number of lines";
            // 
            // okButton
            // 
            okButton.Location = new Point(222, 68);
            okButton.Name = "okButton";
            okButton.Size = new Size(75, 23);
            okButton.TabIndex = 2;
            okButton.Text = "OK";
            okButton.UseVisualStyleBackColor = true;
            // 
            // emptyLabel
            // 
            emptyLabel.BackColor = Color.White;
            emptyLabel.Location = new Point(-12, -7);
            emptyLabel.Name = "emptyLabel";
            emptyLabel.Size = new Size(342, 65);
            emptyLabel.TabIndex = 3;
            // 
            // LineOutOfRangeDialogForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = okButton;
            ClientSize = new Size(309, 101);
            Controls.Add(okButton);
            Controls.Add(mainLabel);
            Controls.Add(emptyLabel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "LineOutOfRangeDialogForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Notepad - Goto Line";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label mainLabel;
        private Button okButton;
        private Label emptyLabel;
    }
}