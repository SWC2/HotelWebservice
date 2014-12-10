using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelsApp.Common;
using HotelsApp.Model;
using HotelsApp.Util;
using HotelsApp.ViewModel;
using Microsoft.Xaml.Interactions.Core;

namespace HotelsApp.Handler
{
    class LoginHandler
    {
        private LoginViewModel loginViewModel;

        public LoginHandler(LoginViewModel loginViewModel)
        {
            this.loginViewModel = loginViewModel;
        }
        public Login Login()
        {
            return new PersistenceFacade().ValidateLogin(loginViewModel.UserName, loginViewModel.PassWord);
           
        }
    }
}
