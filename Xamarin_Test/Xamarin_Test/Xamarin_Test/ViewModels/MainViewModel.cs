namespace Xamarin_Test.ViewModels
{
    public class MainViewModel
    {
        #region ViewModels
        public LoginViewModel Login 
        { 
            get; 
            set; 
        }
        public CustomersViewModel Customers 
        { 
            get;
            set; 
        }
        #endregion

        #region Constructors
        public MainViewModel()
        {
            instance = this;
            this.Login = new LoginViewModel();
        }
        #endregion

        #region patron Singleton, permite hacer llamados desde la MainViewModel a cualquier clase
        private static MainViewModel instance;

        public static MainViewModel GetInstance() 
        {
            if (instance == null)
            {
                return new MainViewModel();
            }

            return instance;
        }
        #endregion
    }
}
