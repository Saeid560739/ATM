using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ATM_Admin1
{
    class admins
    {


        private Int32 _userID;
        private string _bankAccount;
        private string _pinCode;
        private string _fullName;
        private int _currentAmount;
        private string _date = "";
        private string _amount = "";
        private string _amountStatus = "";
        private Int32 _adminID;
        private string _adminName;
        private const int SaltSize = 16;
        private const int HashSize = 20;


        public int userID
        {
            get { return _userID; }
            set { _userID = value; }
        }
        public int AdminID
        {
            get { return _adminID; }
            set { _adminID = value; }
        }
        public string bankAccount
        {
            get { return _bankAccount; }
            set { _bankAccount = value; }
        }
        public string adminName
        {
            get { return _adminName; }
            set { _adminName = value; }
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
        public int currentAmount
        {
            get { return _currentAmount; }
            set { _currentAmount = value; }
        }
        public string amountStatus
        {
            get { return _amountStatus; }
            set { _amountStatus = value; }
        }
       

        SQL1 sql = new SQL1();

        public DataSet getData()
        {
            string Sql = "SELECT * FROM atm_db.users";

            return sql.GetDataSet(Sql);
        }
        public DataSet getSearchData(string value)
        {
            string Sql = "SELECT * FROM atm_db.users WHERE bankAccount = '" + value + "' OR fullName = '" + value + "'";

            return sql.GetDataSet(Sql);
        }
        



        //CRUD
        public void Create(string bankAccount, string pinCode, string fullName)
            {
                string Sql = string.Format("INSERT INTO atm_db.users (bankAccount, pinCode, fullName, currentAmount	) VALUES ('" + bankAccount + "','" + pinCode + "', '" + fullName + "', '" + 0 + "')");

                sql.ExecuteNonQuery(Sql);
            }
        

        public void Read(Int32 userID)
        {
            string Sql = string.Format("SELECT userID, bankAccount, fullName,pinCode, currentAmount FROM atm_db.users WHERE userID = {0}", userID);
            DataTable datatable = sql.GetDataTable(Sql);

            _bankAccount = datatable.Rows[0]["bankAccount"].ToString();
            _fullName = datatable.Rows[0]["fullName"].ToString();
            _currentAmount = Convert.ToInt32(datatable.Rows[0]["currentAmount"].ToString());
            _pinCode = datatable.Rows[0]["pinCode"].ToString();
        }
        public void ReadAdmin(Int32 adminID)
        {
            string Sql = string.Format("SELECT * FROM atm_db.admin WHERE adminID = {0}", adminID);
            DataTable datatable = sql.GetDataTable(Sql);
    
            _adminName = datatable.Rows[0]["name"].ToString();    
        }
        public bool CheckUser(String username, string password)
        {
            string Sql = string.Format("SELECT * FROM atm_db.admin WHERE username  = '" + username + "' AND password = '" + password + "' ");
            DataTable datatable = sql.GetDataTable(Sql);

            if (datatable.Rows.Count > 0)
            {
                _adminID = Convert.ToInt32(datatable.Rows[0]["adminID"].ToString());
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
                                       "fullName         = '{2}'" +
                                       "WHERE userID     = '{3}'", bankAccount, pinCode, fullName, userID);

            sql.ExecuteNonQuery(SQL);
            // System.Windows.MessageBox.Show(customerName + " is geupdate");
        }

        public bool Delete(Int32 userID)
        {
            bool isDeleted = false;
            if (System.Windows.MessageBox.Show("Moet ik deze gegevens verwijderen?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                string SQL = string.Format("DELETE FROM atm_db.users WHERE userID = {0};", userID);
                sql.ExecuteNonQuery(SQL);
                isDeleted = true;

                // System.Windows.MessageBox.Show("gegevens zijn verwijderd");
            }
            return isDeleted;


        }
    }
}
