using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using HotelsApp.Common;
using HotelsApp.Handler;

namespace HotelsApp.ViewModel
{
    class LoginViewModel
    {
        //private ICommand _loginCommand;
        public LoginHandler LoginHandler { get; set; }

        public LoginViewModel()
        {
            LoginHandler=new LoginHandler(this);
        }
     
        //public ICommand LoginCommand
        //{
        //    get { if (_loginCommand==null)
        //            _loginCommand = new RelayCommand(LoginHandler.Login);
        //        return _loginCommand; }
        //    set { _loginCommand = value; }
        //}

        public string UserName { get; set; }
        public string PassWord { get; set; }
    }
}
