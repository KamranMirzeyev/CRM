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
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using CRM.Model;

namespace CRM
{
    /// <summary>
    /// Interaction logic for CustomerWPF.xaml
    /// </summary>
    public partial class CustomerWPF : Window
    {
        public CustomerWPF()
        {
            InitializeComponent();
        }
        CRMEntities db = new CRMEntities();

        //Yeni musteri elave etme
        private void btnCustomerAdd_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtCompanyName.Text) || string.IsNullOrEmpty(txtContactPerson.Text) || string.IsNullOrEmpty(txtAdress.Text) || string.IsNullOrEmpty(txtMobile.Text) || string.IsNullOrEmpty(txtOfficeNumber.Text) || string.IsNullOrEmpty(txtEmail.Text))
            {
                MessageBox.Show("Xana`nı(ları) boş buraxmayın", "xəbərdarlıq", MessageBoxButton.OK, MessageBoxImage.Information);
                return;

            }
            //emailin yoxlanisi
            if (!Regex.IsMatch(txtEmail.Text, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
            {
                MessageBox.Show("Email düzgün deyil", "Xəta", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            //elave edilme
            Customer customer = new Customer();

            customer.CustomerName = txtCompanyName.Text;
            customer.ContactPerson = txtContactPerson.Text;
            customer.Addres = txtAdress.Text;
            customer.Mobile = txtMobile.Text;
            customer.OfficeNumber = txtOfficeNumber.Text;
            customer.Email = txtEmail.Text;
            db.Customers.Add(customer);
            db.SaveChanges();
            MessageBox.Show("Şirkət əlavə edildi", "Məlumat", MessageBoxButton.OK, MessageBoxImage.Information);
            this.Close();
        }
        
    }
}
