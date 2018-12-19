﻿using System;
using System.Windows;
using System.Windows.Input;
using Atlassian.Jira;

namespace Jiratt.UI.Modules.JiraModule.SubModules.Login {
    /// <summary>
    ///     Interaktionslogik für Login.xaml
    /// </summary>
    public partial class LoginView {
        /// <summary>
        /// </summary>
        public LoginView() {
            InitializeComponent();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e) {
            ILoginViewModel viewModel = (ILoginViewModel)DataContext;
            try {
                viewModel.RegisterJiraClient(Jira.CreateRestClient(Server.Text, Username.Text, Pwd.Password));
                viewModel.ErrorText = string.Empty;
                Username.Text = string.Empty;
                Pwd.Password = string.Empty;
            } catch (Exception ex) {
                viewModel.ErrorText = ex.Message;
            }
        }

        private void Pwd_OnKeyDown(object sender, KeyEventArgs e) {
            ILoginViewModel viewModel = (ILoginViewModel)DataContext;
            if (viewModel != null) {
                viewModel.IsPasswordSet = Pwd.SecurePassword.Length > 0;
            }
        }
    }
}