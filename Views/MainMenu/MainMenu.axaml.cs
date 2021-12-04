using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace ds_atividade.Views
{
    public partial class MainMenu : Window
    {
        public MainMenu()
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

        // register
        private void registerUser(object sender, RoutedEventArgs args)
        {
            UserRegister userRegisterScreen = new UserRegister();
            userRegisterScreen.Show();
            this.Close();
        }

        private void registerEmployee(object sender, RoutedEventArgs args)
        {
            UserRegister userRegisterScreen = new UserRegister();
            userRegisterScreen.Show();
            this.Close();
        }

        private void registerCustomer(object sender, RoutedEventArgs args)
        {
            UserRegister userRegisterScreen = new UserRegister();
            userRegisterScreen.Show();
            this.Close();
        }

        private void registerProduct(object sender, RoutedEventArgs args)
        {
            UserRegister userRegisterScreen = new UserRegister();
            userRegisterScreen.Show();
            this.Close();
        }
        
        private void registerSale(object sender, RoutedEventArgs args)
        {
            UserRegister userRegisterScreen = new UserRegister();
            userRegisterScreen.Show();
            this.Close();
        }
    }
}