using System;
using CRM.Model;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;

namespace CRM
{
    /// <summary>
    /// Interaction logic for Istifadəçi.xaml
    /// </summary>
    public partial class Istifadəçi : Window
    {
        CRMEntities db = new CRMEntities();

        public User ModelUser;

        public AllUsers AllUsers;
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

        //yeni istifadəçi yaradılarkən yenilə butonun gizlədilməsi
        public void AddButton()
        {
            btnUserUpdate.Visibility = Visibility.Hidden;
          
        }

        //istifadəçi yenilənərkən yadda saxla butonu gizlədildi
        public void AdUpdateandDelete()
        {
            btnAddUser.Visibility = Visibility.Hidden;
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
            //emailin duzgun daxil edilmesinin yxolanilmasi
            if (!Regex.IsMatch(TxtEmail.Text, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
            {
                MessageBox.Show("Email düzgün deyil", "Xəta", MessageBoxButton.OK, MessageBoxImage.Error);
                Logger.Write("error","Admin yeni istifadəçi yaradarkən mail duz daxil etmədi");
                return;
            }
            //combobox yoxlanilmasi secilmeyibse error mesaj
            if (cmbRole.SelectedIndex==-1)
            {
                MessageBox.Show("Istifadəçinin rolunu seçin", "Xatırlatma", MessageBoxButton.OK, MessageBoxImage.Stop);
                return;
            }

             
            //username tekrar olmamasi ucun yoxlama
            if (db.Users.FirstOrDefault(us=>us.UserName.Contains(txtUsername.Text))!=null)
            {
                MessageBox.Show("Belə bir istifadəçi artıq var", "Bildiriş", MessageBoxButton.OK, MessageBoxImage.None);
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
            u.CreateAt=DateTime.Now;
            u.RoleID = r.RoleId;
            db.Users.Add(u);
            db.SaveChanges();
            MessageBox.Show("Yeni istifadəçi yaradıldı", "Bildiriş", MessageBoxButton.OK, MessageBoxImage.Information);
            this.Close();

            Logger.Write("success","Admin" + u.UserName + " adda yeni bir istifadəçi yaratdı");
            //finish
        }

        //istifadecinin update ve delete olunmasi
        private void FillAllUser()
        {

            if (!string.IsNullOrEmpty(txtName.Text))
            {
                txtName.Text = ModelUser.Name;
                txtSurname.Text = ModelUser.Surname;
                txtPassword.Text = ModelUser.Password;
                txtUsername.Text = ModelUser.UserName;
                txtPhone.Text = ModelUser.PhoneNumber;
                TxtEmail.Text = ModelUser.Email;
                cmbRole.SelectedValue = ModelUser.RoleID.ToString();
            }
               
            
           
        }

        private void Window_ContentRendered(object sender, System.EventArgs e)
        {
            FillAllUser();
        }

        //userin yenilenmesi
        private void BtnUserUpdate_OnClick(object sender, RoutedEventArgs e)
        {
            //Validationlar bos ve emailin duz olmasi
            if (string.IsNullOrEmpty(txtName.Text) || string.IsNullOrEmpty(txtUsername.Text) || string.IsNullOrEmpty(txtSurname.Text) || string.IsNullOrEmpty(txtPassword.Text) || string.IsNullOrEmpty(txtPhone.Text))
            {
                MessageBox.Show("", "", MessageBoxButton.OK, MessageBoxImage.Stop);
                return;
            }
            //emailin duzgun daxil edilmesinin yoxlanilmasi
            if (!Regex.IsMatch(TxtEmail.Text, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
            {
                MessageBox.Show("Email düzgün deyil", "Xəta", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            //combobox yoxlanilmasi secilmeyibse error mesaj
            if (cmbRole.SelectedIndex == -1)
            {
                MessageBox.Show("Istifadəçinin rolunu seçin", "Xatırlatma", MessageBoxButton.OK, MessageBoxImage.Stop);
                return;
            }

            Role r = cmbRole.SelectedItem as Role;

            User u = db.Users.Find(ModelUser.UserId);
            u.Name = txtName.Text;
            u.Surname = txtSurname.Text;
            u.UserName = txtUsername.Text;
            u.Password = txtPassword.Text;
            u.PhoneNumber = txtPhone.Text;
            u.Email = TxtEmail.Text;
            u.RoleID = r.RoleId;
            db.SaveChanges();
            MessageBox.Show("Yeni istifadəçi yeniləndi", "Bildiriş", MessageBoxButton.OK, MessageBoxImage.Information);
            Logger.Write("success","Admin "+ u.UserName + " istifadəçisinin profilində dəyişiklik etdi");
            this.Close();
        }
    }
}
