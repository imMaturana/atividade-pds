using System;
using System.Text.RegularExpressions;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using MessageBox.Avalonia;
using MessageBox.Avalonia.DTO;
using MessageBox.Avalonia.Enums;
using ds_atividade.Models;

namespace ds_atividade.Views
{
    public partial class UserRegister : Window
    {
        private FuncionarioDAO funcionarioDAO = new FuncionarioDAO();
        private ComboBox employeeList;


        public UserRegister()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
            employeeList = this.FindControl<ComboBox>("employees");
            employeeList.Items = funcionarioDAO.List();
            employeeList.SelectedIndex = 0;
        }

        private void save(object sender, RoutedEventArgs args)
        {
            Regex invalidFieldRegex = new Regex("^[a-zA-Z0-9]+$");

            string username = this.FindControl<TextBox>("username").Text;
            string password = this.FindControl<TextBox>("password").Text;
            string confirmPassword = this.FindControl<TextBox>("confirmPassword").Text;
            Funcionario employee = employeeList.SelectedItem as Funcionario;

            if (!invalidFieldRegex.IsMatch(username))
            {
                MessageBoxManager.GetMessageBoxStandardWindow(new MessageBoxStandardParams
                {
                    ContentTitle = "Erro",
                    ContentMessage = "O nome de usuário inserido possui caracteres inválidos!",
                    ButtonDefinitions = ButtonEnum.Ok,
                    WindowStartupLocation = WindowStartupLocation.CenterOwner,
                }).Show();
                return;
            }

            if (!invalidFieldRegex.IsMatch(password))
            {
                MessageBoxManager.GetMessageBoxStandardWindow(new MessageBoxStandardParams
                {
                    ContentTitle = "Erro",
                    ContentMessage = "A senha inserida possui caracteres inválidos!",
                    ButtonDefinitions = ButtonEnum.Ok,
                    WindowStartupLocation = WindowStartupLocation.CenterOwner,
                }).Show();
                return;
            }

            if (password != confirmPassword)
            {
                MessageBoxManager.GetMessageBoxStandardWindow(new MessageBoxStandardParams
                {
                    ContentTitle = "Erro",
                    ContentMessage = "As senhas não batem!",
                    ButtonDefinitions = ButtonEnum.Ok,
                    WindowStartupLocation = WindowStartupLocation.CenterOwner,
                }).Show();
                return;
            }

            try
            {
                UsuarioDAO userDAO = new UsuarioDAO();
                userDAO.Insert(new Usuario
                {
                    Nome = username,
                    Senha = password,
                    Funcionario = employee,
                });
                
                MessageBoxManager.GetMessageBoxStandardWindow(new MessageBoxStandardParams
                {
                    ContentTitle = "Sucesso",
                    ContentHeader = "Sucesso",
                    ContentMessage = "Usuário " + username + " cadastrado com sucesso!",
                    ButtonDefinitions = ButtonEnum.Ok,
                    WindowStartupLocation = WindowStartupLocation.CenterOwner,
                }).Show();
            }
            catch (Exception e)
            {
                MessageBoxManager.GetMessageBoxStandardWindow(new MessageBoxStandardParams
                {
                    ContentTitle = "Erro",
                    ContentHeader = "Erro",
                    ContentMessage = "Um erro ocorreu: " + e,
                }).Show();
            }
        }

        async private void back(object sender, RoutedEventArgs args)
        {
            var ensure = MessageBoxManager.GetMessageBoxStandardWindow(new MessageBoxStandardParams
            {
                ShowInCenter = true,
                ContentTitle = "Confirmação",
                ContentHeader = "Confirmação",
                ContentMessage = "Deseja mesmo voltar?",
                ButtonDefinitions = ButtonEnum.YesNo,
                WindowStartupLocation = WindowStartupLocation.CenterOwner,
            });

            var result = await ensure.Show();

            switch (result)
            {
                case ButtonResult.Yes:
                    MainMenu mainMenu = new MainMenu();
                    mainMenu.Show();
                    this.Close();
                    break;
            }
        }
    }
}