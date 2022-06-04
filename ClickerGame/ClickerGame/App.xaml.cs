using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using System.IO;
namespace ClickerGame
{
    public partial class App : Application
    {

        public const string DATABASE_NAME = "friends2.db";
        public static BaseDatos database;
        public static BaseDatos Database
        {
            get
            {
                if (database == null)
                {
                    database = new BaseDatos(
                        Path.Combine(
                            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DATABASE_NAME));
                }
                return database;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage( new MainPage());
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
