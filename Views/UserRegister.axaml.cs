using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace ds_atividade.Views
{
    public partial class UserRegister : Window
    {
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
        }
    }
}