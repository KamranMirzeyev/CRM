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
    /// Interaction logic for Istifadəçi.xaml
    /// </summary>
    public partial class Istifadəçi : Window
    {
        CRMEntities db = new CRMEntities();
        public Istifadəçi()
        {
            InitializeComponent();
            FillCmbRole();
        }

        //Role combobox doldurulmasi

        private void FillCmbRole()
        {
            foreach (Role rol in db.Roles.ToList())
            {
                cmbRole.Items.Add(rol);
            }
        }

        //yeni userin elave edilmesi
        private void BtnAddUser_OnClick(object sender, RoutedEventArgs e)
        {
            //Validationlar bos ve emailin duz olmasi
            if (string.IsNullOrEmpty(txtName.Text) || string.IsNullOrEmpty(txtUsername.Text) || string.IsNullOrEmpty(txtSurname.Text) || string.IsNullOrEmpty(txtPassword.Text) || string.IsNullOrEmpty(txtPhone.Text))
            {
                MessageBox.Show("", "", MessageBoxButton.OK, MessageBoxImage.Stop);
                return;
            }
            if (!Regex.IsMatch(TxtEmail.Text, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
            {
                MessageBox.Show("Email düzgün deyil", "Xəta", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            //combobox yoxlanilmasi secilmeyibse error mesaj
            if (cmbRole.SelectedIndex==-1)
            {
                MessageBox.Show("Istifadəçinin rolunu seçin", "Xatırlatma", MessageBoxButton.OK, MessageBoxImage.Stop);
                return;
            }

            //yeni istifadecini elave olunmasi
            Role r = cmbRole.SelectedItem as Role;

            User u = new User();
            u.Name = txtName.Text;
            u.Surname = txtSurname.Text;
            u.UserName = txtUsername.Text;
            u.Password = txtPassword.Text;
            u.PhoneNumber = txtPhone.Text;
            u.Email = TxtEmail.Text;
            u.RoleID = r.RoleId;
            db.Users.Add(u);
            db.SaveChanges();
            MessageBox.Show("Yeni istifadəçi yaradıldı", "Bildiriş", MessageBoxButton.OK, MessageBoxImage.Information);
            this.Close();
            //finish
        }
    }
}
