using Common;
using DictionaryServices;
using System; 
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DictionaryProject
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WordPage : ContentPage
    {
        private readonly IDictionaryService<DBWord> _dictionaryService;
        private bool enableSaveBtn;
        private DBWord _word;
        
        public WordPage(IDictionaryService<DBWord> dictionaryService, DBWord locationWord)
        {
            _dictionaryService = dictionaryService;

            InitializeComponent();

            if (locationWord != null)
            {
                _word = locationWord;
                Title = Resource.ChangeWordTitlePage;
                ruEditText.Text = _word.RuWord;
                enEditText.Text = _word.EnWord;
                discriptionWordEditText.Text = _word.Discription;
                mapBtn.IsEnabled = true;
                if (locationWord.Latitude == 0 || locationWord.Longitude == 0)
                {
                    mapBtn.IsEnabled = false;
                    SetPositionOnMap();
                }
            } 
            else
            {
                _word = new DBWord(new DictionaryWord("", "", "", 0, 0));
                Title = Resource.AddWordTitlePage;
                mapBtn.IsEnabled = false;
                SetPositionOnMap();
            }

            saveBtn.IsEnabled = false;            
            addCounterLabel.Text = _word.AddCounter.ToString();
        }

        private async void SetPositionOnMap()
        {
            try
            {
                var request = new GeolocationRequest(GeolocationAccuracy.Medium);
                var location = await Geolocation.GetLocationAsync(request);

                if (location != null)
                {
                    _word.Longitude = location.Longitude;
                    _word.Latitude = location.Latitude;
                    mapBtn.IsEnabled = true;
                }
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Handle not supported on device exception
            }
            catch (FeatureNotEnabledException fneEx)
            {
                // Handle not enabled on device exception
            }
            catch (PermissionException pEx)
            {
                // Handle permission exception
            }
            catch (Exception ex)
            {
                // Unable to get location
            }
        }

        protected internal void DisplayStack()
        {
            NavigationPage navPage = (NavigationPage)App.Current.MainPage; 
        }

        private async void OnMapClicked(object sender, EventArgs e)
        {
            MapPage page = new MapPage(_word);
            await Navigation.PushAsync(page); 
        }

        private void OnSavedClicked(object sender, EventArgs e)
        {
            _dictionaryService.TryAddWord(_word);
        }

        private void enEditTextTextChanged(object sender, TextChangedEventArgs e)
        {
            _word.EnWord = enEditText.Text;

            IsEnable();
        }

        private void ruEditTextTextChanged(object sender, TextChangedEventArgs e)
        {
            _word.RuWord = ruEditText.Text;

            IsEnable();
        }

        private void discriptionWordEditTextTextChanged(object sender, TextChangedEventArgs e)
        {
            _word.Discription = discriptionWordEditText.Text;

            IsEnable();
        }

        private void IsEnable()
        {
            if (_word.EnWord == "" || _word.RuWord == "")
            {
                enableSaveBtn = false;
                saveBtn.IsEnabled = enableSaveBtn;
                return;
            }

            enableSaveBtn = true;
            saveBtn.IsEnabled = enableSaveBtn;
        }
    }
}