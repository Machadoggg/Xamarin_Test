using Xamarin_Test.ViewModels;

namespace Xamarin_Test.Infrastructure
{

    

    public class InstanceLocator
    {
        #region Properties
        public MainViewModel Main { get; set; }
        #endregion

        #region Constructors
        public InstanceLocator()
        {
                Main = new MainViewModel();
        }
        #endregion
    }
}
