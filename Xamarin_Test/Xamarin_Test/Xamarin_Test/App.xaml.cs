

namespace Xamarin_Test
{
    using Xamarin.Forms;
    using Xamarin_Test.Views;

    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new NavigationPage(new LoginPage());
            MainPage = new NavigationPage(new MapPage());
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
