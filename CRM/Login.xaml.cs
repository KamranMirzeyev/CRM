using CRM.Model;
using System.Linq;
using System.Windows;

namespace CRM
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        CRMEntities db = new CRMEntities();
        MainWindow main = new MainWindow();
       
        public Login()
        {
            InitializeComponent();
        }

       

        public void btnLogin_Click(object sender, RoutedEventArgs e)

        { 
            //Xanalarin bos buraxmamagini yoxlanir
            if (string.IsNullOrEmpty(txtUsername.Text) || string.IsNullOrEmpty(Pbxpassword.Password))
            {
                MessageBox.Show("Xana'nı(ları) doldurun", "Xədərdarlıq", MessageBoxButton.OK, MessageBoxImage.Stop);
                return;
            }

            //Userin yoxlanisi
            if (!string.IsNullOrEmpty(txtUsername.Text) && !string.IsNullOrEmpty(Pbxpassword.Password))
            {
                foreach (User u in db.Users)
                {
                    if (u.UserName == txtUsername.Text && u.Password == Pbxpassword.Password)
                    {

                        //Daxil olan usere gore Dashboardin gorunusu
                         int UserID = db.Users.FirstOrDefault(x => x.UserName == txtUsername.Text).UserId;
                        main.currentUserID = UserID;

                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                


                            }
                        }
                        if (db.Users.First(x=>x.UserId==UserID).RoleID==2)
                        {
                           
                            foreach (Window window in Application.Current.Windows)
                            {
                                if (window.GetType() == typeof(MainWindow))
                                {
                                    (window as MainWindow).MenuUsers.Visibility = Visibility.Hidden;


                                }
                            }
                        }


                        main.Show();
                        this.Close();
                        return;

                    }
                    

                }

            }
            //User olmasa mesaj cixartma
            else
            {
                MessageBox.Show("Belə bir istiadəçi yoxdur", "Xəta", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

        }
    }
}
