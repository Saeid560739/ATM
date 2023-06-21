using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ATM
{
    class userLogin
    {
        private string _bankAccount;
        private string _pinCode;
        private string _error = null;
        
        public string bankAccount
        {
            get { return _bankAccount; }
            set { _bankAccount = value; }
        }
        public string pinCode
        {
            get { return _pinCode; }
            set { _pinCode = value; }
        }
        public string error
        {
            get { return _error; }
            set { _error = value; }
        }

        Users users = new Users();




    }
}
