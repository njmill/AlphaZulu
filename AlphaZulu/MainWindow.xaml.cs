using System.Windows;
using System.Windows.Input;

namespace AlphaZulu
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Vars _vars = new Vars();

        public MainWindow()
        {
            InitializeComponent();

            var convert = new AZConvert(_vars);

            DataContext = _vars;

            InputTBox.TextChanged += (o, s) =>
            {
                convert.WriteOutput(InputTBox.Text);
            };

            CheckClipboard();

            InputTBox.Focusable = true;
            Keyboard.Focus(InputTBox);
        }

        public void CheckClipboard()
        {
            string clipBoardText = null;
            if(Clipboard.ContainsText(TextDataFormat.Text) && Clipboard.GetText().Length <= 200)
            {
                InputTBox.Text = Clipboard.GetText(TextDataFormat.Text);
            }
        }
    }
}
