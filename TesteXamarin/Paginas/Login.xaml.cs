using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TesteXamarin.ProjetoLuby
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
        }

        public async void TryLogin(Object sender, EventArgs arg)
        {

            if (string.IsNullOrEmpty(email.Text) || string.IsNullOrEmpty(senha.Text))
            {
                await DisplayAlert("Erro", "Insira o login e senha", "Ok");
                return;
            }

            string newSenha = Security.Security.encryptSHA256(senha.Text);

            object user = await App.Database.LoginAsync(email.Text, newSenha);

            object list = await App.Database.GetUsuariosAsync();

            if (user == null)
            {
                await DisplayAlert("Erro", "Login ou senha inválidos", "Ok");
            }
            else
            {
                await Navigation.PushAsync(new Principal());
            }
        }

        public async void Register(Object sender, EventArgs arg)
        {
            await Navigation.PushAsync(new Registrar());
        }
    }
}