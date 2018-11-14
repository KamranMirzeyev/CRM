﻿using System.Linq;
using System.Windows;
using CRM.Model;


namespace CRM
{
    /// <summary>
    /// Interaction logic for AllCompanies.xaml
    /// </summary>
    public partial class AllCompanies : Window
    {
        public AllCompanies()
        {
            InitializeComponent();
            FillCmbCompany();
        }
        CRMEntities db = new CRMEntities();

        //combobox doldurulmasi
        private void FillCmbCompany()
        {

            foreach (Customer customer in db.Customers.ToList())
            {
                cmbCompany.Items.Add(customer);
            }
        }

        //company silinmesi
        private void btnCompanyDelete_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult mb = MessageBox.Show("Silmək istədiyinizdən əminsiniz?", "Sil", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (mb == MessageBoxResult.Yes)
            {
                Customer custom = cmbCompany.SelectedItem as Customer;
                Customer cus = db.Customers.FirstOrDefault(x => x.CustomerId==custom.CustomerId);
                db.Customers.Remove(cus);
                db.SaveChanges();
                MessageBox.Show("Istifadəçi silindi", "Bildiriş", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
        }

        //Company update olunmasi
        private void btnCompanyUpdate_Click(object sender, RoutedEventArgs e)
        {
            CustomerWPF c = new CustomerWPF();

            Customer customer = cmbCompany.SelectedItem as Customer;

            c.UpdateButton();
            c.Title = "Yenilə";
            c.txtCompanyName.Text = customer.CustomerName;
            c.AllCompany = this;
            c.ModelCustomer = db.Customers.Find(customer.CustomerId);
            c.ShowDialog();

        }
    }
}
