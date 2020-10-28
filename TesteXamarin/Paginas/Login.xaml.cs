using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TesteXamarin.Models;
using TesteXamarin.Paginas;
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

            if (user == null)
            {
                await DisplayAlert("Erro", "Login ou senha inválidos", "Ok");
            }
            else
            {
                WebClient wc = new WebClient();

                string resultado = wc.DownloadString("https://run.mocky.io/v3/83599a37-9b03-47d1-970d-555f8835355c");

                Info info = JsonConvert.DeserializeObject<Info>(resultado);

                await Navigation.PushAsync(new ListaUsuario(info));
            }
        }

        public async void Register(Object sender, EventArgs arg)
        {
            await Navigation.PushAsync(new Registrar());
        }
    }
}