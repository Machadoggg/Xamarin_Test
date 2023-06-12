using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin_Test.Models;
using Xamarin_Test.Services;

namespace Xamarin_Test.ViewModels
{
    public class CustomersViewModel : BaseViewModel
    {
        #region Services
        private ApiService apiService; 
        #endregion

        #region Attributes
        private ObservableCollection<Customer> customers;
        #endregion

        #region Properties
        public ObservableCollection<Customer> Customers
        {
            get { return this.customers; }
            set { SetValue(ref this.customers, value); }
        }
        #endregion

        #region Constructors
        public CustomersViewModel()
        {
            this.apiService = new ApiService();
            this.loadCustomers();
        }
        #endregion

        #region Methods
        private async void loadCustomers()
        {
            var connection = await this.apiService.CheckConnection();

            if (!connection.IsSuccess) 
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    connection.Message,
                    "Accept");

                //Back por codigo (es el equivalente si un usario le da a a la flechita para devolverse)
                await Application.Current.MainPage.Navigation.PopAsync();
                return;
            }

            var response = await this.apiService.GetList<Customer>(
                "http://192.168.1.14:45455",
                "/api",
                "/customers");

            if (!response.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    response.Message,
                    "Accept");

                //Back por codigo (es el equivalente si un usario le da a a la flechita para devolverse)
                await Application.Current.MainPage.Navigation.PopAsync();
                return;
            }

            var list = (List<Customer>)response.Result;
            this.Customers = new ObservableCollection<Customer>(list);
        } 
        #endregion
    }
}
