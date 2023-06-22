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
            var positionUser = new Position(6.242988, -75.555248);
            var positionItm = new Position(6.245495936323433, -75.55104127505932);
            var positionCfa = new Position(6.251262614865208, -75.56532325621255);
            map.MoveToRegion(MapSpan.FromCenterAndRadius(positionUser, Distance.FromKilometers(1)));

            // Agrega un marcador al mapa
            var pinUser = new Pin
            {
                Type = PinType.Place,
                Position = positionUser,
                Label = "Mi ubicación",
                Address = "Calle 50 # 33-53, Medellín, Antioquia"
            }; 
            var pinItm = new Pin
            {
                Type = PinType.Place,
                Position = positionItm,
                Label = "ITM Campus Fraternidad",
                Address = "Calle 54a, Medellín, Antioquia"
            };
            var pinCfa = new Pin
            {
                Type = PinType.Place,
                Position = positionCfa,
                Label = "CFA Cooperativa Financiera Oficina Camino Real",
                Address = "Cra. 47 #52 - 89, Medellín, Antioquia"
            };
            map.Pins.Add(pinUser);
            map.Pins.Add(pinItm);
            map.Pins.Add(pinCfa);

            // Agrega el mapa al control de mapa en la página
            mapContainer.Children.Add(map);

        }
    }
}