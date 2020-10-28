using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TesteXamarin.ProjetoLuby
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Registrar : ContentPage
    {

   
        public Registrar()
        {
            InitializeComponent();
        }

        public async void Cadastrar(Object sender, EventArgs args)
        {

            if (!Senha.Text.Equals(ConfirmaSenha.Text))
            {
                await DisplayAlert("Erro", "Senhas não são iguais.", "Ok");
                return;
            }

            /*if ((DateTime.Now.Year - DataNascimento.Date.Year) < 18)
            {
                await DisplayAlert("Erro", "Você tem que ter mais de 18 anos.", "Ok");
                return;
            }*/

            if (!Email.Text.Contains("@"))
            {
                await DisplayAlert("Erro", "Email Inválido.", "Ok");
                return;
            }

            object check = await App.Database.CheckRegister(Email.Text);

            if(check == null)
            {
                Usuario user = new Usuario();


                user.ID = 0;
                user.Nome = Nome.Text;
                user.DataNascimento = DataNascimento.Date;
                user.Telefone = Telefone.Text;
                user.Email = Email.Text;
                user.Senha = Security.Security.encryptSHA256(Senha.Text);

                await App.Database.SaveUsuarioAsync(user);
                await DisplayAlert("Sucesso", "Usuario Cadastrado com Sucesso.", "Ok");
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("Erro", "Email já cadastrado.", "Ok");
            }

           
        }
    }
}