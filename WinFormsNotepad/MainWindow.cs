namespace WinFormsNotepad
{
    public partial class MainWindow : Form
    {
        private string? _filename = null;
        private bool _modified = false;
        private bool _redo = false;
        private int _zoom = 100;
        public int Lines { get { return textArea.Lines.Length; } }
        public MainWindow()
        {
            InitializeComponent();
            UpdateTitle();
            UpdateZoom();
            UpdateStatusBar();
        }

        public void GoToLine(int line)
        {
            int index = textArea.GetFirstCharIndexFromLine(line);
            textArea.Select(index, 0);
        }
        private void UpdateZoom()
        {
            textArea.ZoomFactor = _zoom / 100f;
            sbZoomLabel.Text = $"{_zoom}%";
        }

        private void UpdateStatusBar()
        {
            int line = textArea.GetLineFromCharIndex(textArea.SelectionStart) + 1;
            int column = textArea.SelectionStart - textArea.GetFirstCharIndexOfCurrentLine() + 1;

            sbTextPositionLabel.Text = $"Ln {line}, col {column}";
        }
        private void UpdateTitle()
        {
            string fn = _filename == null ? "Untitled" : Path.GetFileName(_filename);
            Text = $"{(_modified ? "*" : string.Empty)}{fn}";
        }
        private void OpenFile(string filename)
        {
            using StreamReader sr = new StreamReader(filename);
            textArea.Text = sr.ReadToEnd();
            _modified = false;
            UpdateTitle();

        }
        private void SaveFile(string filename)
        {
            using StreamWriter sw = new StreamWriter(filename);
            sw.Write(textArea.Text);
            _modified = false;
            UpdateTitle();
        }

        private void MainWindow_FormClosing(object? sender, FormClosingEventArgs e)
        {
            if (_modified)
            {
                DialogResult result = MessageBox.Show("Do you want to save changes to the current file?", "Notepad", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                    saveToolStripMenuItem_Click(sender, e);
                else if (result == DialogResult.Cancel)
                    e.Cancel = true;
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_modified)
            {
                DialogResult result = MessageBox.Show("Do you want to save changes to the current file?", "Notepad", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                    saveToolStripMenuItem_Click(sender, e);
                else if (result == DialogResult.No)
                    _modified = false;
                else
                    return;
            }
            if (!_modified)
                textArea.Text = string.Empty;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter =
                "Text files (*.txt)|*.txt|" +
                "JSON files (*.json)|*.json|" +
                "HTML files (*.html; *.htm)|*.html;*.htm|" +
                "All files (*.*)|(*.*)";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                _filename = openFileDialog.FileName;
                OpenFile(_filename);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_filename == null)
                saveAsToolStripMenuItem_Click(sender, e);
            else
                SaveFile(_filename);
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter =
                "Text files (*.txt)|*.txt|" +
                "JSON files (*.json)|*.json|" +
                "HTML files (*.html; *.htm)|*.html;*.htm|" +
                "All files (*.*)|(*.*)";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                _filename = saveFileDialog.FileName;
                SaveFile(_filename);
            }
        }

        private void textArea_TextChanged(object sender, EventArgs e)
        {
            if (!_modified)
            {
                _modified = true;
                UpdateTitle();
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm aboutForm = new AboutForm();
            aboutForm.ShowDialog();
        }

        private void wordWrapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            goToToolStripMenuItem.Enabled = wordWrapToolStripMenuItem.Checked;
            wordWrapToolStripMenuItem.Checked = !wordWrapToolStripMenuItem.Checked;
            textArea.WordWrap = wordWrapToolStripMenuItem.Checked;
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using FontDialog fontDialog = new FontDialog();
            fontDialog.Font = textArea.Font;
            fontDialog.ShowEffects = false;
            if (fontDialog.ShowDialog() == DialogResult.OK)
                textArea.Font = fontDialog.Font;
        }

        private void statusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusBarToolStripMenuItem.Checked = !statusBarToolStripMenuItem.Checked;
            statusBar.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void textArea_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                _zoom = ((int)Math.Round(textArea.ZoomFactor * 10)) * 10;
                UpdateZoom();

                if (e.KeyCode == Keys.Add)
                {
                    zoomInToolStripMenuItem_Click(sender, e);
                }
                else if (e.KeyCode == Keys.Subtract)
                {
                    zoomOutToolStripMenuItem_Click(sender, e);
                }
            }
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_redo)
                textArea.Redo();
            else
                textArea.Undo();
            _redo = !_redo;
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textArea.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textArea.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textArea.Paste();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textArea.SelectedText = string.Empty;
        }

        private void findToolStripMenuItem_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void findNextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void findPreviousToolStripMenuItem_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void replaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textArea.SelectAll();
        }

        private void timeDateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textArea.AppendText(DateTime.Now.ToString("g"));
        }

        private void textArea_SelectionChanged(object sender, EventArgs e)
        {
            UpdateStatusBar();
            if (textArea.SelectedText.Length > 0)
            {
                if (!cutToolStripMenuItem.Enabled)
                {
                    cutToolStripMenuItem.Enabled = true;
                    copyToolStripMenuItem.Enabled = true;
                    deleteToolStripMenuItem.Enabled = true;
                }
            }
            else
            {
                if (cutToolStripMenuItem.Enabled)
                {
                    cutToolStripMenuItem.Enabled = false;
                    copyToolStripMenuItem.Enabled = false;
                    deleteToolStripMenuItem.Enabled = false;
                }
            }
        }

        private void zoomInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_zoom < 500)
            {
                _zoom += 10;
                UpdateZoom();
            }
        }

        private void zoomOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_zoom > 10)
            {
                _zoom -= 10;
                UpdateZoom();
            }
        }

        private void restoreDefaultZoomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_zoom != 100)
            {
                _zoom = 100;
                UpdateZoom();
            }
        }

        private void newWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Application.ExecutablePath);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void goToToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new GoToLineForm(this).ShowDialog();
        }
    }
}
