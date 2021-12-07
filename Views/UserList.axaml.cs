using System;
using System.Collections.Generic;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using ds_atividade.Models;
using Avalonia;

namespace ds_atividade.Views
{
    public partial class UserList : Window
    {
        public UserList()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
            //LoadList();
        }

        private void LoadList()
        {
            DataGrid userDataGrid = this.FindControl<DataGrid>("userDataGrid");

            UsuarioDAO userDAO = new UsuarioDAO();
            List<Usuario> usuarios = userDAO.List();

            //System.Console.WriteLine(usuarios[0].Nome);

            List<Sexo> sexos = new List<Sexo>() { new Sexo() { Id = 1, Nome = "M" } };

            foreach(var sexo in sexos)
            {
                Console.WriteLine(sexo.Id);
            }

            userDataGrid.Items = sexos;
        }
    }
}