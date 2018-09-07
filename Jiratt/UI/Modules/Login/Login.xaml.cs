using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Atlassian.Jira;

namespace Jiratt.UI.Modules.Login {
    /// <summary>
    ///     Interaktionslogik für Login.xaml
    /// </summary>
    public partial class Login : UserControl {
        /// <summary>
        /// </summary>
        public Login() {
            InitializeComponent();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e) {
            ILoginViewModel viewModel = DataContext as ILoginViewModel;
            try {
                viewModel?.RegisterJiraClient(Jira.CreateRestClient(Server.Text, Username.Text, Pwd.Password));
                Error.Text = string.Empty;
                Username.Text = string.Empty;
                Pwd.Password = string.Empty;
            } catch (Exception ex) {
                Error.Text = ex.Message;
            }
        }

        private void Pwd_OnKeyDown(object sender, KeyEventArgs e) {
            ILoginViewModel viewModel = DataContext as ILoginViewModel;
            if (viewModel != null) {
                viewModel.IsPasswordSet = Pwd.SecurePassword.Length > 0;
            }
        }
    }
}