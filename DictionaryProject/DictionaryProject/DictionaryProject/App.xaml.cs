
using DictionaryServices;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DictionaryProject
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            var dictionaryRepositry = new DictionaryRepository(
                Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "DictionaryDB.db3"));
            var dictionaryService = new DictionaryService<DBWord>(dictionaryRepositry);

            //MainPage = new NavigationPage(new MainPage(dictionaryService)); 
            MainPage = new NavigationPage(new LoginAndPasswordPage(dictionaryService)); 
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
