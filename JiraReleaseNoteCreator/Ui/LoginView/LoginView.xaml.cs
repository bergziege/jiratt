﻿using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

using Atlassian.Jira;

using JiraReleaseNoteCreator.Ui.MainView.ViewModels;
using Microsoft.Practices.Unity;

namespace JiraReleaseNoteCreator.Ui.LoginView {
    /// <summary>
    ///     Interaktionslogik für LoginView.xaml
    /// </summary>
    public partial class LoginView : UserControl {
        public LoginView() {
            InitializeComponent();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e) {
            DoLogin();
        }

        private void DoLogin() {
            if (DataContext is MainViewModel) {
                ((MainViewModel)DataContext).RegisterJiraInstanceAsSingleton(Jira.CreateRestClient(_serverUrl.Text, username.Text, pwd.Password));
                ((MainViewModel)DataContext).Init();
            }
        }

        private void Pwd_OnKeyUp(object sender, KeyEventArgs e) {
            if (e.Key ==Key.Enter) {
                DoLogin();
            }
        }
    }
}