namespace WinFormsNotepad
{
    partial class AboutForm
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
            splitContainer1 = new SplitContainer();
            descLabel = new Label();
            descPictureBox = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)descPictureBox).BeginInit();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(descPictureBox);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(descLabel);
            splitContainer1.Size = new Size(280, 317);
            splitContainer1.SplitterDistance = 208;
            splitContainer1.TabIndex = 0;
            // 
            // descLabel
            // 
            descLabel.Dock = DockStyle.Fill;
            descLabel.Location = new Point(0, 0);
            descLabel.Name = "descLabel";
            descLabel.Size = new Size(280, 105);
            descLabel.TabIndex = 0;
            descLabel.Text = "My first Windows Forms app!";
            descLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // descPictureBox
            // 
            descPictureBox.Dock = DockStyle.Fill;
            descPictureBox.Image = Properties.Resources.about_image;
            descPictureBox.Location = new Point(0, 0);
            descPictureBox.Name = "descPictureBox";
            descPictureBox.Size = new Size(280, 208);
            descPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            descPictureBox.TabIndex = 0;
            descPictureBox.TabStop = false;
            // 
            // AboutForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(277, 317);
            Controls.Add(splitContainer1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "AboutForm";
            Text = "About";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)descPictureBox).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private Label descLabel;
        private PictureBox descPictureBox;
    }
}