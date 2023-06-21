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
    /// Interaction logic for toWithdraw.xaml
    /// </summary>
    public partial class toWithdraw : Window
    {
        
        
        private Int32 _ID;
        private Amount amount = new Amount();
        private Users users = new Users();
        
        
        public toWithdraw( Int32 ID)
        {
            InitializeComponent();
            
            _ID = ID;
            btn1OtherAmount.Click += btn1OtherAmount_Click;
            btnCancel.Click += btnCancel_Click;
            btn20.Click += btn20_Click;
            btn10.Click += Btn10_Click;
            btn40.Click += Btn40_Click;
            btn70.Click += Btn70_Click;
            btn50.Click += Btn50_Click;
            users.maxTrans(ID);
            
        }

        private void Btn50_Click(object sender, RoutedEventArgs e)
        {
            amount.amount_Withdraw(_ID, 5000);
            Account account = new Account(_ID);
            account.Show();
            this.Close();
        }

        private void Btn70_Click(object sender, RoutedEventArgs e)
        {
            amount.amount_Withdraw(_ID, 7000);
            Account account = new Account(_ID);
            account.Show();
            this.Close();
        }

        private void Btn40_Click(object sender, RoutedEventArgs e)
        {
            amount.amount_Withdraw(_ID, 4000);
            Account account = new Account(_ID);
            account.Show();
            this.Close();
        }

        private void Btn10_Click(object sender, RoutedEventArgs e)
        {
            amount.amount_Withdraw(_ID, 1000);
            Account account = new Account(_ID);
            account.Show();
            this.Close();
        }

        private void btn20_Click(object sender, RoutedEventArgs e)
        {
            amount.amount_Withdraw(_ID, 2000);
            Account account = new Account(_ID);
            account.Show();
            this.Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Account account = new Account(_ID);
            account.Show();
            this.Close();
        }

        private void btn1OtherAmount_Click(object sender, RoutedEventArgs e)
        {
            amount.amount_Withdraw(_ID, Convert.ToDouble( txtAmount.Text) * 100);
            Account account = new Account(_ID);
            account.Show();
            this.Close();
            
        }
    }
}
