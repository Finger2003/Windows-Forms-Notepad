namespace WinFormsNotepad
{
    partial class GoToLineForm
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
            lineNumberTextBox = new TextBox();
            lineNumberLabel = new Label();
            cancelButton = new Button();
            goToButton = new Button();
            SuspendLayout();
            // 
            // lineNumberTextBox
            // 
            lineNumberTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lineNumberTextBox.Location = new Point(12, 36);
            lineNumberTextBox.Name = "lineNumberTextBox";
            lineNumberTextBox.Size = new Size(262, 23);
            lineNumberTextBox.TabIndex = 0;
            lineNumberTextBox.KeyPress += lineNumberTextBox_KeyPress;
            // 
            // lineNumberLabel
            // 
            lineNumberLabel.AutoSize = true;
            lineNumberLabel.Location = new Point(12, 18);
            lineNumberLabel.Name = "lineNumberLabel";
            lineNumberLabel.Size = new Size(77, 15);
            lineNumberLabel.TabIndex = 1;
            lineNumberLabel.Text = "Line number:";
            // 
            // cancelButton
            // 
            cancelButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            cancelButton.Location = new Point(199, 89);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(75, 23);
            cancelButton.TabIndex = 2;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = true;
            // 
            // goToButton
            // 
            goToButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            goToButton.BackColor = SystemColors.Control;
            goToButton.CausesValidation = false;
            goToButton.Location = new Point(118, 89);
            goToButton.Name = "goToButton";
            goToButton.Size = new Size(75, 23);
            goToButton.TabIndex = 3;
            goToButton.Text = "Go To";
            goToButton.UseVisualStyleBackColor = true;
            goToButton.Click += goToButton_Click;
            // 
            // GoToLineForm
            // 
            AcceptButton = goToButton;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = cancelButton;
            ClientSize = new Size(286, 124);
            Controls.Add(goToButton);
            Controls.Add(cancelButton);
            Controls.Add(lineNumberLabel);
            Controls.Add(lineNumberTextBox);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "GoToLineForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Go To Line";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox lineNumberTextBox;
        private Label lineNumberLabel;
        private Button cancelButton;
        private Button goToButton;
    }
}