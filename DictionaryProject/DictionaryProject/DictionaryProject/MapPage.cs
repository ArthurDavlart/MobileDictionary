using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace DictionaryProject
{
    public class MapPage : ContentPage
    {
        Map _map;
        public MapPage(DBWord dBWord)
        {

            _map = new Map();
            _map.IsShowingUser = true; 

            var position = new Position(dBWord.Latitude, dBWord.Longitude);
            _map.MoveToRegion(MapSpan.FromCenterAndRadius(position, Distance.FromMiles(1)));

            Pin pin = new Pin
            {
                Label = dBWord.EnWord,
                Address = dBWord.RuWord,
                Type = PinType.Place,
                Position = position
            };
            _map.Pins.Add(pin);
            //Content = _map;
            //var map = new Map();
            //map.IsShowingUser = true;

            Content = _map;
        }
    }
}