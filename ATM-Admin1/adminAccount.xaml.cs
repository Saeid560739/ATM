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
    /// Interaction logic for adminAccount.xaml
    /// </summary>
    public partial class adminAccount : Window
    {
        private MainWindow MainWindow = new MainWindow();
        private Int32 _ID;
        private admins admins = new admins();
        public adminAccount(Int32 ID)
        {
            InitializeComponent();
            _ID = ID;
            admins.ReadAdmin(ID);
            lblID.Content = "Admin ID: " + Convert.ToInt32(ID.ToString());
            lblName.Content = "Admin Name: " + admins.adminName;
            dgusers.DataContext = admins.getData();
            btnAdd.Click += btnAdd_Click;
            btnLogout.Click += btnLogout_Click;
            
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            winEdit winEdit = new winEdit(_ID);
            winEdit.Show();
            this.Close();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                object item = dgusers.SelectedItem;
                int userID = int.Parse((dgusers.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text);
                winEdit winEdit = new winEdit(userID, _ID);
                winEdit.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                object item = dgusers.SelectedItem;
                int ID = int.Parse((dgusers.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text);

                if (admins.Delete(ID) == true)
                {
                    dgusers.DataContext = admins.getData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtSearch.Text != "")
            {
                dgusers.DataContext = admins.getSearchData(txtSearch.Text);
            }
            else 
            {
                dgusers.DataContext = admins.getData();
            }
        }
    }
}
