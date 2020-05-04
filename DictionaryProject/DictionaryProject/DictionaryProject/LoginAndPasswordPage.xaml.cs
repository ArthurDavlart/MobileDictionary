using DictionaryServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DictionaryProject
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginAndPasswordPage : ContentPage
    {
        IDictionaryService<DBWord> _dictionaryService;
        public LoginAndPasswordPage(IDictionaryService<DBWord> dictionaryService)
        {
            _dictionaryService = dictionaryService;
            InitializeComponent();
        }

        public async void OnLoginButtonClicked(object sender, EventArgs e)
        { 
            HttpClient client = new HttpClient();
            string request = $"http://192.168.0.102/Autorisation/Check?login={usernameEntry.Text}&password={passwordEntry.Text}";
            string response = await client.GetStringAsync(request);
            if (response == "true")
            {
                var page = new MainPage(_dictionaryService);
                await Navigation.PushAsync(page);
                Navigation.RemovePage(this);
            }
            else
            {
                await DisplayAlert("Ошибка", "Неверный логин или пароль", "Ок");
            }
        }

        public void OnSignUpButtonClicked(object sender, EventArgs e)
        {

        }
    }
}