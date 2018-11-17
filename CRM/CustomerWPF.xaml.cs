using System;
using System.Linq;
using CRM.Model;
using System.Text.RegularExpressions;
using System.Windows;

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

        public AllCompanies AllCompany;
        public Customer ModelCustomer;
        public int UserID;

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
            customer.CreateAt=DateTime.Now;
            db.Customers.Add(customer);
            db.SaveChanges();
            MessageBox.Show("Şirkət əlavə edildi", "Məlumat", MessageBoxButton.OK, MessageBoxImage.Information);
            string Username = db.Users.FirstOrDefault(x => x.UserId == UserID).UserName;
            Logger.Write("success",Username+ " yeni şirkət əlavə etdi");
            this.Close();
        }

        //add olunanda yenilə butonun gizlədilməsi
        public void AddButton()
        {
            btnCustomerUpdate.Visibility = Visibility.Hidden;
        }

        //yeniləmədə add butonu gizlədilməsi
        public void UpdateButton()
        {
            btnCustomerAdd.Visibility = Visibility.Hidden;
        }

        //musterinin yenilenmesi
        private void btnCustomerUpdate_Click(object sender, RoutedEventArgs e)
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

            Customer customer = db.Customers.Find(ModelCustomer.CustomerId);
            customer.CustomerName = txtCompanyName.Text;
            customer.ContactPerson = txtContactPerson.Text;
            customer.Addres = txtAdress.Text;
            customer.Mobile = txtMobile.Text;
            customer.OfficeNumber = txtOfficeNumber.Text;
            customer.Email = txtEmail.Text;
            db.SaveChanges();
            MessageBox.Show("Şirkət məlumatları yeniləndi", "Məlumat", MessageBoxButton.OK, MessageBoxImage.Information);
            string Username = db.Users.FirstOrDefault(x => x.UserId == UserID).UserName;
            Logger.Write("success", Username + " "+customer.CustomerName +" şirkətinin profilində dəyişiklik etdi");
            this.Close();
        }

        //update textboxun doldurulmasi
        private void FillCompany()
        {
            if (!string.IsNullOrEmpty(txtCompanyName.Text))
            {
                txtCompanyName.Text = ModelCustomer.CustomerName;
                txtContactPerson.Text = ModelCustomer.ContactPerson;
                txtAdress.Text = ModelCustomer.Addres;
                txtEmail.Text = ModelCustomer.Email;
                txtMobile.Text = ModelCustomer.Mobile;
                txtOfficeNumber.Text = ModelCustomer.OfficeNumber;
            }
        }

        private void Window_ContentRendered(object sender, System.EventArgs e)
        {
            FillCompany();
        }
    }
}
