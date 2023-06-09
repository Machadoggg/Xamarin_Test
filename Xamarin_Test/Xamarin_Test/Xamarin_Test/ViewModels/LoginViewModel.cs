﻿using GalaSoft.MvvmLight.Command;
using System;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin_Test.Views;

namespace Xamarin_Test.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        //#region Events, como herada de la BaseViewModel ya no se necesita el evento
        //public event PropertyChangedEventHandler PropertyChanged;
        //#endregion


        #region Attributes
        private string email;
        private string password;
        private bool isRunning;
        private bool isEnabled;
        #endregion

        #region Properties
        public string Email
        {
            get { return this.email; }
            set { SetValue(ref this.email, value); }
        }

        public string Password
        {
            get { return this.password; }
            set { SetValue(ref this.password, value); }
        }

        public bool IsRunning
        {
            get { return this.isRunning; }
            set { SetValue(ref this.isRunning, value); }
        }

        public bool IsRemember { get; set; }
        public bool IsEnabled 
        {
            get { return this.isEnabled; }
            set { SetValue(ref this.isEnabled, value); }
        }
        #endregion

        #region Constructors
        public LoginViewModel()
        {
            this.IsRemember = true;
            this.IsEnabled = true;

            this.email = "machadoggg@gmail.com";
            this.password = "1234";
        }
        #endregion

        #region Commands
        public ICommand LoginCommand
        {
            get
            {
                return new RelayCommand(Login);
            }
        }


        private async void Login()
        {
            if (string.IsNullOrEmpty(this.Email))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "You must enter an email",
                    "Accept");
                return;
            }
            if (string.IsNullOrEmpty(this.Password))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "You must enter an password",
                    "Accept");
                return;
            }

            this.IsRunning = true;
            this.IsEnabled = false;

            if (this.Email != "machadoggg@gmail.com" || this.Password != "1234")
            {
                this.IsRunning = false;
                this.IsEnabled = true;
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Email or password incorrect",
                    "Accept");
                this.Password = string.Empty;
                return;
            }

            this.IsRunning = false;
            this.IsEnabled = true;

            this.Email = string.Empty;
            this.Password = string.Empty;

            //Llamada al singleton, antes de pintar la (CustomersPage)
            //estamos estableciendo la (CustomersViewModel) alineado a la (MainViewModel)
            MainViewModel.GetInstance().Customers = new CustomersViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new CustomersPage());
        }

        public ICommand MapCommand
        {
            get
            {
                return new RelayCommand(Map);
            }
        }

        private async void Map()
        {
            MainViewModel.GetInstance().Maps = new MapViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new MapPage());
        }

        public ICommand RegisterCommand
        {
            get
            { 
                return new RelayCommand(Register);
            }
        }

        private async void Register()
        {
            MainViewModel.GetInstance().Register = new RegisterViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new RegisterPage());
        }
        #endregion
    }
}
