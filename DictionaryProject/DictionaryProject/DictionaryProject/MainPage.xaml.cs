using Common;
using DictionaryServices;
using System;
using System.Collections.Generic;
using System.ComponentModel; 
using System.Linq; 
using Xamarin.Essentials;
using Xamarin.Forms;

namespace DictionaryProject
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        private readonly IDictionaryService<DBWord> _dictionaryService;

        private List<DBWord> Words { get; set; }
        
        public MainPage(IDictionaryService<DBWord> dictionaryService)
        {
            _dictionaryService = dictionaryService;
            Words = _dictionaryService.GetDictionaryWords().ToList();
            
            Title = Resource.MainTitlePage; 

            BindingContext = this;
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            Words = _dictionaryService.GetDictionaryWords().ToList();

            wordsList.ItemsSource = Words;
        }

        private async void OnButtonClicked(object sender, EventArgs e)
        {
            WordPage page = new WordPage(_dictionaryService, null);
            await Navigation.PushAsync(page);
        }

        private async void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            DBWord selectedWord = e.Item as DBWord;
            if (selectedWord != null)
            {
                WordPage page = new WordPage(_dictionaryService, selectedWord);
                await Navigation.PushAsync(page);
            }            
        }
    }  
}
