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
       

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string name = db.Users.FirstOrDefault(x => x.UserId == currentUserID).Name;
            string surname = db.Users.FirstOrDefault(x => x.UserId == currentUserID).Surname;

            lblCurventUser.Content = name + " " + surname;
        }



        public MainWindow()
        {
            InitializeComponent();
          
        }

        private void FillDasboard()
        {
            CRMEntities db = new CRMEntities();
            dgDashboard.Items.Clear();
            string Username = db.Users.FirstOrDefault(x => x.UserId == currentUserID).UserName;

            if (db.Users.FirstOrDefault(x => x.UserId == currentUserID).RoleID == 1)
            {
                foreach (Model.Task task in db.Tasks.ToList())
                {
                    VwTask vw = new VwTask
                    {
                        Description = task.Description,
                        DeadLine = task.DeadlineTime,
                        Id = task.TaskId,
                        CreateAt = task.CreationAt,
                        Company = task.Customer.CustomerName,
                        FullName = task.User.UserName
                    };
                    dgDashboard.Items.Add(vw);
                    return;
                }
            }

            if (db.Users.FirstOrDefault(x=>x.UserId==currentUserID).RoleID==2)
            {
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
                    return;
                }
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
            task.AddTaskButton();
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


        private void ReyAdd_OnClick(object sender, RoutedEventArgs e)
        {
            Rey rey = new Rey();
            rey.userid = currentUserID;
            rey.Show();
        }

        private void dgDashboard_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgDashboard.SelectedItem !=null)
            {
                VwTask vwTask = dgDashboard.SelectedItem as VwTask;
                Task task = new Task();
                task.Title = "Yenilə";
                task.UserID = currentUserID;
                task.MainWindow = this;
                task.UpdateTaskButton();
                task.TaskModel = db.Tasks.Find(vwTask.Id);
                task.ShowDialog();
            }
            

        }

        //butun tasklarin cagirilmasi
        private void AllTask_OnClick(object sender, RoutedEventArgs e)
        {
            FillDasboard();
        }

        //axtarisin olunmasi
        private void btnTaskAxtar_Click(object sender, RoutedEventArgs e)
        {
            dgDashboard.Items.Clear();
            //textbox bos buraxilmamasi
            if (string.IsNullOrEmpty(txtTaskAxtar.Text))
            {
                MessageBox.Show("Nə axtarmaq istədiyinizi yazın", "Bildiriş", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            string Username = db.Users.FirstOrDefault(x => x.UserId == currentUserID).UserName;


            List<Model.Task> tasks = db.Tasks.Where(t=>(t.Customer.CustomerName.Contains(txtTaskAxtar.Text)||t.User.UserName.Contains(txtTaskAxtar.Text)||t.DeadlineTime.ToString().Contains(txtTaskAxtar.Text))).ToList();

            if (db.Users.FirstOrDefault(x => x.UserId == currentUserID).RoleID == 1)
            {
                foreach (Model.Task task in tasks)
                {
                    VwTask vw = new VwTask
                    {
                        Description = task.Description,
                        DeadLine = task.DeadlineTime,
                        Id = task.TaskId,
                        CreateAt = task.CreationAt,
                        Company = task.Customer.CustomerName,
                        FullName = task.User.UserName
                    };
                    dgDashboard.Items.Add(vw);
                    return;
                }
            }

            if (db.Users.FirstOrDefault(x => x.UserId == currentUserID).RoleID == 2)
            {
                foreach (Model.Task task in tasks)
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
                    return;
                }
            }
        }
    }
}
