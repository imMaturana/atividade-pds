using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using ds_atividade.Models;
using MessageBox.Avalonia;
using MessageBox.Avalonia.DTO;

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

        // actions
        private void executeSale(object sender, RoutedEventArgs args)
        {
        }

        private void registerUser(object sender, RoutedEventArgs args)
        {
            int employeesQuantity = new FuncionarioDAO().List().Count;
            if (employeesQuantity == 0)
            {
                MessageBoxManager.GetMessageBoxStandardWindow(new MessageBoxStandardParams
                {
                    ContentTitle = "Erro",
                    ContentMessage = "Não é possível cadastrar um usuário sem funcionário cadastrado no sistema!",
                    WindowStartupLocation = WindowStartupLocation.CenterOwner,
                }).Show();
            }
            else
            {
                UserRegister userRegisterScreen = new UserRegister();
                userRegisterScreen.Show();
                this.Close();
            }
        }

        private void registerEmployee(object sender, RoutedEventArgs args)
        {
            CadastroFuncionario cadastroFuncionario = new CadastroFuncionario();
            cadastroFuncionario.Show();
            this.Close();
        }

        private void registerCustomer(object sender, RoutedEventArgs args)
        {
        }

        private void registerProduct(object sender, RoutedEventArgs args)
        {
        }
        
        // list
        private void listUsers(object sender, RoutedEventArgs args)
        {
            UserList userListWindow = new UserList();
            userListWindow.Show();
            this.Close();
        }

        private void listEmployees(object sender, RoutedEventArgs args)
        {
            
        }

        private void listCustomers(object sender, RoutedEventArgs args)
        {
            
        }

        private void listProducts(object sender, RoutedEventArgs args)
        {
            
        }

        private void listSales(object sender, RoutedEventArgs args)
        {
            
        }
    }
}