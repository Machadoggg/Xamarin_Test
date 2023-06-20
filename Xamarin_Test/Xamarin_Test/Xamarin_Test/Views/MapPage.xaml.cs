using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace Xamarin_Test.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapPage : ContentPage
    {
        public MapPage()
        {
            InitializeComponent();

            // Obtén la instancia del mapa
            var map = new Map();

            // Establece el centro del mapa en una ubicación específica
            var position = new Position(6.242988, -75.555248);
            map.MoveToRegion(MapSpan.FromCenterAndRadius(position, Distance.FromMiles(1)));

            // Agrega un marcador al mapa
            var pin = new Pin
            {
                Type = PinType.Place,
                Position = position,
                Label = "Mi ubicación",
                Address = "San Francisco, CA"
            };
            map.Pins.Add(pin);

            // Agrega el mapa al control de mapa en la página
            mapContainer.Children.Add(map);

        }
    }
}