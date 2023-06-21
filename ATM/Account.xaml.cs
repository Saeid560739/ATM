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


namespace ATM
{
    /// <summary>
    /// Interaction logic for Account.xaml
    /// </summary>
    public partial class Account : Window
    {
        private int _ID;
        Users users = new Users();
       
        public Account( Int32 ID)
        {
            InitializeComponent();
            
            users.Read(ID);
            lblAccount.Content = users.bankAccount.ToString();
            lblAmount.Content = users.currentAmount.ToString("C");
            lblFullName.Content = users.fullName.ToString();
            btnToWithdraw.Click += btnToWithdraw_Click;
            btnDeposit.Click += btnDeposit_Click;
            btnSignOut.Click += btnSignOut_Click;
            _ID = ID;
            users.getOverview(ID, 0, lblamount1, lbldate1, lblplusMin1);
            users.getOverview(ID, 1, lblamount2, lbldate2, lblplusMin2);
            users.getOverview(ID, 2, lblamount3, lbldate3, lblplusMin3);
        }

        private void btnSignOut_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void btnDeposit_Click(object sender, RoutedEventArgs e)
        {
            winDeposit winDeposit = new winDeposit(_ID);
            winDeposit.Show();
            this.Close();
        }

        private void btnToWithdraw_Click(object sender, RoutedEventArgs e)
        {

            toWithdraw toWithdraw = new toWithdraw(_ID);
            toWithdraw.Show();
            this.Close();
        }

    }
}
