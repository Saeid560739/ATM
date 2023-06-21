using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ATM_Admin1
{
    /// <summary>
    /// Interaction logic for winEdit.xaml
    /// </summary>
    public partial class winEdit : Window
    {
        Int32 _userID;
        admins admins = new admins();
        Int32 _adminID;
        SecurePasswordHasher securePasswordHasher = new SecurePasswordHasher();
        public winEdit(Int32 userID, Int32 adminID)
        {
            InitializeComponent();
            _userID = userID;
            _adminID = adminID;
            btnupdate.Visibility = Visibility.Visible;
            btncancel.Click += btncancel_Click;
            btnupdate.Click += btnupdate_Click;
            admins.Read(userID);
            txtName.Text = admins.fullName;
            txtBank.Text = admins.bankAccount;
            lblTitle.Content = "Edit";
        }

        public winEdit(Int32 adminID)
        {
            InitializeComponent();
            _adminID = adminID;
            btnAdd.Visibility = Visibility.Visible;
            btnAdd.Click += btnAdd_Click;
            btncancel.Click += btncancel_Click;
            lblTitle.Content = "New customer";
        }


        private void btnupdate_Click(object sender, RoutedEventArgs e)
        {
            if (txtBank.Text != "" && txtPin.Text != "" && txtName.Text != "")
            {
                admins.Update(_userID.ToString(), txtBank.Text, securePasswordHasher.hasher(txtPin.Text), txtName.Text);
                adminAccount adminAccount = new adminAccount(_adminID);
                adminAccount.Show();
                this.Close();
            }
            else 
            {
                lblError.Content = "Error!! Enter all data";
            }
        }

        private void btncancel_Click(object sender, RoutedEventArgs e)
        {
            adminAccount adminAccount = new adminAccount(_adminID);
            adminAccount.Show();
            this.Close();
        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (txtBank.Text != "" && txtPin.Text != "" && txtName.Text != "")
            {
                admins.Create(txtBank.Text, securePasswordHasher.hasher(txtPin.Text), txtName.Text);
                adminAccount adminAccount = new adminAccount(_adminID);
                adminAccount.Show();
                this.Close();
            }
            else
            {
                lblError.Content = "Error!! Enter all data";
            }
        }

    }
}
