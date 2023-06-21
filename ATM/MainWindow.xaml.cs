using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace ATM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Users users = new Users();
        userLogin userLogin = new userLogin();
        SecurePasswordHasher securePasswordHasher = new SecurePasswordHasher();
       
        
       
        
        public MainWindow()
        {

            InitializeComponent();
            btnEnter.Click += btnEnter_Click;

        }


        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {

          
            if (users.CheckUser(txtBankAct.Text,  passPin.Password) == false)
            {
                //System.Windows.MessageBox.Show(securePasswordHasher.hasher(passPin.Password).ToString());
                lblError.Content = "Bank account or pin code incorrect";
            }
            else
            {
                
                int ID = users.userID;
                Account account = new Account( ID);
                account.Show();
                this.Close();
            }
            
        }
    }
}
