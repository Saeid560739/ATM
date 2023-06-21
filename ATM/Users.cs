using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ATM
{
    class Users
    {

        private Int32 _userID;
        private string _bankAccount;
        private string _pinCode;
        private string _fullName;
        private Double _currentAmount;
        private string _date = "";
        private string _amount = "";
        private string _amountStatus = "";
        
        

        public int userID
        {
            get { return _userID; }
            set { _userID = value; }
        }
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

        public string fullName
        {
            get { return _fullName; }
            set { _fullName = value; }
        }
        public string amount
        {
      
            get { return _amount; }
            set { _amount = value; }
        }
        public string date
        {
            get { return _date; }
            set { _date = value; }
        }
        public Double currentAmount
        {
            get { return _currentAmount; }
            set { _currentAmount = value; }
        }
        public string amountStatus
        {
            get { return _amountStatus; }
            set { _amountStatus = value; }
        }


        SQL sql = new SQL();

        public DataSet getData()
        {
            string Sql = "SELECT userID, bankAccount, pinCode, fullName, currentAmount FROM atm_db.users";

            return sql.GetDataSet(Sql);
        }




        //CRUD
        public void Create(string bankAccount, string pinCode, string fullName, int currentAmount)
        {
            string Sql = string.Format("INSERT INTO atm_db.users (bankAccount, pinCode, fullName, currentAmount) VALUES ('{0,1,2,3}')", bankAccount, pinCode, fullName, currentAmount);

            sql.ExecuteNonQuery(Sql);
        }
        public void CreateTrans(Double amountWithdrawn, Int32 AmountStatus, Int32 userID)
        {
            string Sql = string.Format("INSERT INTO atm_db.transfer (amountWithdrawn, AmountStatus, userID) VALUES (" + amountWithdrawn +"," + AmountStatus + ","+ userID + ")");
            sql.ExecuteNonQuery(Sql);
        }
        public void UpdateAmount(Double amount, string plusMin , Int32 userID )
        {
            if (plusMin == "plus")
            {
                string SQL = string.Format("Update atm_db.users  Set currentAmount = (currentAmount + " + amount + ")  WHERE userID =" + userID);
                sql.ExecuteNonQuery(SQL);
            }
            else if(plusMin == "min")
            {
                string SQL = string.Format("Update atm_db.users  Set currentAmount = (currentAmount - " + amount + ")  WHERE userID =" + userID);
                sql.ExecuteNonQuery(SQL);
            }
            
            // System.Windows.MessageBox.Show(customerName + " is geupdate");
        }

        public bool maxTrans(Int32 userID)
        {
            string Sql = string.Format("SELECT * FROM atm_db.transfer where DATE(datum) = DATE('"+ DateTime.Now.ToString("yyyy/MM/dd") + "') AND AmountStatus = 0 AND userID = '"+ userID +"'");
            DataTable datatable = sql.GetDataTable(Sql);
            // DateTime.Now.ToString("dd/MM/yyyy");
            //MessageBox.Show(DateTime.Now.ToString("yyyy/MM/dd") + datatable.Rows.Count.ToString());
            //SELECT * FROM transfer WHERE datum >='2023-03-13';
            if (datatable.Rows.Count >= 3)
            {
                return true;
            }
            else 
            {
                return false;
            }   
        }
        //Update atm_db.users  Set currentAmount = currentAmount + 10  WHERE userID = 2 


        public void Read(Int32 userID)
        {
            string Sql = string.Format("SELECT userID, bankAccount, fullName, currentAmount FROM atm_db.users WHERE userID = {0}", userID);
            DataTable datatable = sql.GetDataTable(Sql);
            
            _bankAccount = datatable.Rows[0]["bankAccount"].ToString();
            _fullName = datatable.Rows[0]["fullName"].ToString();
            _currentAmount = Convert.ToDouble(datatable.Rows[0]["currentAmount"].ToString())/100;

        }

        public void getOverview(Int32 userID, Int32 index , Label lblAmount , Label lblDate, Label lblStatus)
        {
            
            //SELECT datum, amountWithdrawn, AmountStatus FROM atm_db.transfer WHERE userID = 2 ORDER BY transferID DESC LIMIT 2;
            string Sql = string.Format("SELECT datum , amountWithdrawn, AmountStatus FROM atm_db.transfer WHERE userID = " + userID + " ORDER BY transferID DESC LIMIT 3");
            DataTable datatable = sql.GetDataTable(Sql);
            int dr = datatable.Rows.Count;

            if (dr > index)
            {
                lblAmount.Content = (Convert.ToDouble( datatable.Rows[index]["amountWithdrawn"].ToString()) / 100).ToString("C");
            }
            else 
            {
                lblAmount.Content = "";
            }
 
            if (dr > index)
            {
                lblDate.Content = datatable.Rows[index]["datum"].ToString();
            }
            else 
            {
                lblDate.Content = "";
            }
            if (dr > index)
            {
                if (Convert.ToInt32(datatable.Rows[index]["AmountStatus"].ToString()) == 1)
                {
                    
                    lblStatus.Content = "+";
                }
                else
                {
                    
                    lblStatus.Content = "-";
                }
            }
            else 
            {
                lblStatus.Content = "";
            }
        }


        public bool CheckUser(String bankAccount, string pinCode)
        {
            SecurePasswordHasher securePasswordHasher = new SecurePasswordHasher();
            string Sql = string.Format("SELECT userID, bankAccount, pinCode FROM atm_db.users WHERE bankAccount = '" + bankAccount + "' AND pinCode = '" + securePasswordHasher.hasher(pinCode) + "' ");
            DataTable datatable = sql.GetDataTable(Sql);

            if (datatable.Rows.Count > 0) {
                _userID = Convert.ToInt32(datatable.Rows[0]["userID"].ToString());
                //MessageBox.Show(datatable.Rows.Count.ToString());
                return true;                     
            }

            return false;
        }

        public void Update(string userID, string bankAccount, string pinCode, string fullName)
        {
            string SQL = string.Format("Update atm_db.users " +
                                       "Set bankAccount  = '{0}'," +
                                       "pinCode          = '{1}'," +
                                       "fullName         = '{2}'," +
                                       "WHERE userID     = '{3}'", bankAccount, pinCode, fullName, userID);

            sql.ExecuteNonQuery(SQL);
            // System.Windows.MessageBox.Show(customerName + " is geupdate");
        }

        public bool Delete(Int32 userID)
        {
            bool isDeleted = false;
            if (System.Windows.MessageBox.Show("Moet ik deze gegevens verwijderen?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                string SQL = string.Format("DELETE FROMatm_db.users WHERE userID = {0};", userID);
                sql.ExecuteNonQuery(SQL);
                isDeleted = true;

                // System.Windows.MessageBox.Show("gegevens zijn verwijderd");
            }
            return isDeleted;
        }
    }
}
