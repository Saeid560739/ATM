using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ATM
{
    class Amount
    {
        private Int32 _transID;
        private Int32 _ID;
        private Int32 _amountwithdrawn;
        private Int32 _depositedAmount;
        private Users users = new Users();
        private Double _currentAmount;
        private Label _error = new Label();





        public Int32 transID
        {
            get { return _transID; }
            set { _transID = value; }
        }
        public Double currentAmount
        {
            get { return _currentAmount; }
            set { _currentAmount = value; }
        }
        public Int32 ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        public Int32 amountwithdrawn
        {
            get { return _amountwithdrawn; }
            set { _amountwithdrawn = value; }
        }
        public Int32 depositedAmount
        {
            get { return _depositedAmount; }
            set { _depositedAmount = value; }
        }

        public void amount_Withdraw(Int32 ID, Double amount)
        {
            if (users.maxTrans(ID) == false)
            {
                users.Read(ID);
                _currentAmount = users.currentAmount * 100;
                if (_currentAmount < amount)
                {
                    MessageBox.Show("The entered amount is not available in your account");
                }
                else if (amount > 50000)
                {
                    MessageBox.Show("You cannot withdraw an amount greater than 500");
                }
                else
                {
                    users.CreateTrans(amount, 0, ID);
                    users.UpdateAmount(amount, "min", ID);
                }
            }
            else 
            {
                MessageBox.Show("You are allowed 3 transfer per day");
            }
        }

        public void amount_deposit(Int32 ID, Double amount)
        {
            users.CreateTrans(amount, 1, ID);
            users.UpdateAmount(amount, "plus", ID);
        }
        
    }
}
