using System;
using System.IO;
using TesteXamarin.Data;
using TesteXamarin.ProjetoLuby;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TesteXamarin
{
    public partial class App : Application
    {

        static UsuarioDatabase database;

        public static UsuarioDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new UsuarioDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Usuario.db3"));
                }
                return database;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Login());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
