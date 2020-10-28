using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteXamarin.Models;
using TesteXamarin.ProjetoLuby;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TesteXamarin.Paginas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListaUsuario : ContentPage
    {
        public static string Token;
        public ListaUsuario(Info info)
        {
            InitializeComponent();
            Token = info.Token;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            List<Usuario> usuarios = await App.Database.GetUsuariosAsync();

            foreach(Usuario user in usuarios)
            {
                user.Nome = "Nome: " + user.Nome;
                user.DataNascimento = "Nascimento: " + user.DataNascimento;
                user.Email = "Email: " + user.Email;
                user.Telefone = "Telefone: " + user.Telefone;
            }

            Lista.ItemsSource = usuarios;
        }

    }
}