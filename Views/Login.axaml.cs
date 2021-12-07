using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using MessageBox.Avalonia;
using MessageBox.Avalonia.DTO;
using MessageBox.Avalonia.Enums;

namespace ds_atividade.Views
{
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        private void enter(object sender, RoutedEventArgs args)
        {
            var username = this.FindControl<TextBox>("username");
            var password = this.FindControl<TextBox>("password");

            if (username.Text == null && password.Text == null)
            {
                MainMenu mainMenu = new MainMenu();
                mainMenu.Show();
                this.Close();
            }
            else
            {
                var alert = MessageBoxManager.GetMessageBoxStandardWindow(new MessageBoxStandardParams
                {
                    ShowInCenter = true,
                    ContentTitle = "Erro",
                    ContentMessage = "Usuário e senha estão incorretos",
                    ButtonDefinitions = ButtonEnum.Ok,
                    WindowStartupLocation = WindowStartupLocation.CenterOwner,
                });
                alert.Show();
            }
        }

        async private void exit(object sender, RoutedEventArgs args)
        {
            var ensure = MessageBoxManager.GetMessageBoxStandardWindow(new MessageBoxStandardParams
            {
                ShowInCenter = true,
                ContentTitle = "Sair",
                ContentMessage = "Deseja mesmo sair?",
                ButtonDefinitions = ButtonEnum.YesNo,
                WindowStartupLocation = WindowStartupLocation.CenterOwner,
            });            

            var result = await ensure.Show();

            switch (result) {
                case ButtonResult.Yes:
                    this.Close();
                    break;
                case ButtonResult.No:
                    break;
            }
        }
    }
}