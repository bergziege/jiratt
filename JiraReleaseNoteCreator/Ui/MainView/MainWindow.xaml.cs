using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace JiraReleaseNoteCreator.Ui.MainView {
    /// <summary>
    ///     Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        private void UIElement_OnKeyUp(object sender, KeyEventArgs e) {
            if (((TextBox)sender).Text == null) {
                return;
            }
            if (e.Key == Key.Enter) {
                if (_searchButton.Command != null) {
                    if (_searchButton.Command.CanExecute(null)) {
                        _searchButton.Command.Execute(null);
                    }
                }
            }
        }
    }
}