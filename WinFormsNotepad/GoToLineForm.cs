namespace WinFormsNotepad
{
    public partial class GoToLineForm : Form
    {
        private ToolTip _toolTip = new ToolTip()
        {
            ToolTipIcon = ToolTipIcon.Error,
            ToolTipTitle = "Unacceptable character",
            IsBalloon = true
        };
        private bool _toolTipIsShown = false;
        private MainWindow _mainWindow;
        public GoToLineForm(MainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
        }

        private void lineNumberTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                if (!_toolTipIsShown)
                {
                    Point pos = lineNumberTextBox.GetPositionFromCharIndex(lineNumberTextBox.SelectionStart - 1);
                    pos.X += 12;
                    pos.Y = lineNumberTextBox.Height - 8;
                    _toolTip.Show(string.Empty, lineNumberTextBox, pos);
                    _toolTip.Show(string.Empty, lineNumberTextBox, pos);
                    _toolTip.Show("You can only type a number here", lineNumberTextBox, pos);
                    _toolTipIsShown = true;
                }

            }
            else
            {
                _toolTip.Hide(lineNumberTextBox);
                _toolTipIsShown = false;
            }
        }

        private void goToButton_Click(object sender, EventArgs e)
        {

            //MainWindow? mainWindow = Parent as MainWindow;
            //if(mainWindow is null)
            //    throw new ArgumentNullException(nameof(mainWindow));

            bool parsed = int.TryParse(lineNumberTextBox.Text, out int line);

            if(parsed && line > 0 && (line < _mainWindow.Lines + 1 || line == 1 && _mainWindow.Lines == 0))
            {
                _mainWindow.GoToLine(line - 1);
                Close();
            }
            else
            {

                new LineOutOfRangeDialogForm().ShowDialog();
            }
        }

    }
}

// The line number is beyond the total number of lines
//Jak w Windows Forms zrobic walidacje po kazdym nacisnisnieciu klawisza w TextBox, mozna wpisywac tylko cyfry, w przypadku innego znaku powinien wyswietlic sie dymek z informacja