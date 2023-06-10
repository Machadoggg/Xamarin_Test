using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Xamarin_Test.ViewModels
{
    public class LoginViewModel
    {
        #region Properties
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsRunning { get; set; }
        public bool IsRemember { get; set; }
        #endregion

        #region Constructors
        public LoginViewModel()
        {
            this.IsRemember = true;  
        }
        #endregion

        #region Commands
        public Command LoginCommand { get; set; }
        #endregion
    }
}
