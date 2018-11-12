using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CRM.Model;
namespace CRM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CRMEntities db = new CRMEntities();
        public int currentUserID;
        public MainWindow()
        {
            InitializeComponent();
          
        }

        private void FillDasboard()
        {
            dgDashboard.Items.Clear();
            string Username = db.Users.FirstOrDefault(x => x.UserId == currentUserID).UserName;
            foreach (Model.Task task in db.Tasks.ToList())
            {
                VwTask vw = new VwTask
                {
                    Description = task.Description,
                    DeadLine = task.DeadlineTime,
                    Id = task.TaskId,
                    CreateAt = task.CreationAt,
                    Company = task.Customer.CustomerName,
                    FullName = Username
                };
                dgDashboard.Items.Add(vw);

            }
        }
        

        private void CompanyAdd_OnClick(object sender, RoutedEventArgs e)
        {
          CustomerWPF custom = new CustomerWPF();
            custom.Show();
        }

        private void TaskAdd_OnClick(object sender, RoutedEventArgs e)
        {
          Task task = new Task();
            task.Show();
            task.UserID = currentUserID;
        }

        private void MenuDashboard_OnClick(object sender, RoutedEventArgs e)
        {
            
            FillDasboard();
        }

        private void UserAdd_OnClick(object sender, RoutedEventArgs e)
        {
            Istifadəçi i = new Istifadəçi();
            i.Show();
        }
    }
}
