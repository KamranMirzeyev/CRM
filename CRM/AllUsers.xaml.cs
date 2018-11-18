using CRM.Model;
using System.Linq;
using System.Windows;

namespace CRM
{
    /// <summary>
    /// Interaction logic for AllUsers.xaml
    /// </summary>
    public partial class AllUsers : Window
    {
        public AllUsers()
        {
            InitializeComponent();
            FillAllUserCmb();
        }
        CRMEntities db =new CRMEntities();

        //comboboxun doldurulması
        public void FillAllUserCmb()
        {
            cmbAllUser.Items.Clear();
            CRMEntities data = new CRMEntities();
            foreach (User user in data.Users.ToList())
            {
                cmbAllUser.Items.Add(user);
            }
        }

        //İstifadənin yeniləməsi ucun doldurulması
        private void btnAllUser_Click(object sender, RoutedEventArgs e)
        {
            Istifadəçi i = new Istifadəçi();
           

            User user = cmbAllUser.SelectedItem as User;
            i.AdUpdateandDelete();
            i.Title = "Yenilə";
            i.AllUsers = this;
            i.txtName.Text = user.Name;
            i.ModelUser = db.Users.Find(user.UserId);
            i.ShowDialog();
        }

        //userin silinmesi
        private void btnUserDelete_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult mb = MessageBox.Show("Silmək istədiyinizdən əminsiniz?", "Sil", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (mb == MessageBoxResult.Yes)
            {
                User u = cmbAllUser.SelectedItem as User;
                User user = db.Users.FirstOrDefault(x => x.UserId == u.UserId);
                string username = db.Users.FirstOrDefault(x => x.UserId == u.UserId).UserName;
                db.Users.Remove(user);
                db.SaveChanges();
                MessageBox.Show("Istifadəçi silindi", "Bildiriş", MessageBoxButton.OK, MessageBoxImage.Information);
                Logger.Write("success","Admin "+ username + " adlı istifadəçini sildi");
                this.Close();
            }
           
        }
    }
}
