using System;
using System.Windows;
using System.Windows.Controls;
using Atlassian.Jira;

namespace Jiratt.UI.Modules.Login {
    /// <summary>
    ///     Interaktionslogik für Login.xaml
    /// </summary>
    public partial class Login : UserControl {
        public Login() {
            InitializeComponent();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e) {
            ILoginViewModel viewModel = DataContext as ILoginViewModel;
            try {
                viewModel?.RegisterJiraClient(Jira.CreateRestClient(Server.Text, Username.Text, Pwd.Password));
                Error.Text = string.Empty;
            } catch (Exception ex) {
                Error.Text = ex.Message;
            }
        }
    }
}