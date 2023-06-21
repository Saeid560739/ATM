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
    /// Interaction logic for winDeposit.xaml
    /// </summary>
    public partial class winDeposit : Window
    {
        private Users users = new Users();
        private Int32 _ID;
        private Amount amount = new Amount();
        public winDeposit(Int32 ID)
        {
            InitializeComponent();
            _ID = ID;
            btn1OtherAmount.Click += btn1OtherAmount_Click;
            btnCancel.Click += btnCancel_Click;

        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Account account = new Account(_ID);
            account.Show();
            this.Close();
        }

        private void btn1OtherAmount_Click(object sender, RoutedEventArgs e)
        {
            amount.amount_deposit(_ID, Convert.ToDouble(txtAmount.Text) * 100);
            Account account = new Account(_ID);
            account.Show();
            this.Close();
        }
    }
}
