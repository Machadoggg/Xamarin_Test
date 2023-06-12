using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
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
        private bool isRefreshing;
        private string filter;
        private List<Customer> customersList;
        #endregion

        #region Properties
        public ObservableCollection<Customer> Customers
        {
            get { return this.customers; }
            set { SetValue(ref this.customers, value); }
        }
        public bool IsRefreshing
        {
            get { return this.isRefreshing; }
            set { SetValue(ref this.isRefreshing, value); }
        }
        public string Filter
        {
            get { return this.filter; }
            set 
            { 
                SetValue(ref this.filter, value);
                this.Search();
            }
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
            this.IsRefreshing = true;
            var connection = await this.apiService.CheckConnection();

            if (!connection.IsSuccess)
            {
                this.IsRefreshing = false;
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
                this.IsRefreshing = false;
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    response.Message,
                    "Accept");

                //Back por codigo (es el equivalente si un usario le da a a la flechita para devolverse)
                await Application.Current.MainPage.Navigation.PopAsync();
                return;
            }

            this.customersList = (List<Customer>)response.Result;
            this.Customers = new ObservableCollection<Customer>(this.customersList);
            this.IsRefreshing = false;
        }
        #endregion

        #region Commands
        public ICommand RefreshCommand 
        {
            get
            {
                return new RelayCommand(loadCustomers);
            }
        }

        public ICommand SearchCommand 
        {
            get
            {
                return new RelayCommand(Search);
            }
        }

        private void Search()
        {
            if (string.IsNullOrEmpty(this.Filter))
            {
                this.Customers = new ObservableCollection<Customer>(
                    this.customersList);
            }
            else
            {
                this.Customers = new ObservableCollection<Customer>(
                    this.customersList.Where(
                        c => c.Nombres.ToLower().Contains(this.Filter.ToLower()) ||
                             c.Apellido_1.ToLower().Contains(this.Filter.ToLower())));
            }
        }

        #endregion
    }
}
