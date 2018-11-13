using CRM.Model;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;



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
           

            //admindirse hamsi gelecek
            if (db.Users.FirstOrDefault(x => x.UserId == currentUserID).RoleID == 1)
            {
                

                foreach (Model.Task task in db.Tasks.ToList())
                {
                    string ok = task.FinishTime == false ? "Bitmeyib" : "Bitib";
                    VwTask vw = new VwTask
                    {
                        
                        Description = task.Description,
                        DeadLine = task.DeadlineTime.ToString("dd/MM/yyyy"),
                        Id = task.TaskId,
                        CreateAt = task.CreationAt,
                        Company = task.Customer.CustomerName,
                        FullName = task.User.Surname +" "+task.User.Name,
                        Finished = ok
                        

                    };
                    dgDashboard.Items.Add(vw);

                }
            }

            //moderatordusa ancaq oz yazdigi
            if (db.Users.FirstOrDefault(x => x.UserId == currentUserID).RoleID == 2)
            {
                List<Model.Task> ta = db.Tasks.Where(x => x.UserID == currentUserID).ToList();

                foreach (Model.Task task in ta)
                {
                    string ok = task.FinishTime == false ? "Bitmeyib" : "Bitib";
                    VwTask vw = new VwTask
                    {
                        Description = task.Description,
                        DeadLine = task.DeadlineTime.ToString("dd/MM/yyyy"),
                        Id = task.TaskId,
                        CreateAt = task.CreationAt,
                        Company = task.Customer.CustomerName,
                        FullName = task.User.Surname + " " + task.User.Name,
                        Finished = ok
                    };
                    dgDashboard.Items.Add(vw);

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
           
            
                VwTask vwTask = dgDashboard.SelectedItem as VwTask;
                Task task = new Task();
                task.Title = "Yenilə";
                task.UserID = currentUserID;
                task.MainWindow = this;
                task.UpdateTaskButton();
                task.TaskModel = db.Tasks.Find(vwTask.Id);
                task.ShowDialog();
            
            

        }

        //butun tasklarin cagirilmasi
        private void AllTask_OnClick(object sender, RoutedEventArgs e)
        {
            FillDasboard();
        }

        

        private void BtnLogout_OnClick(object sender, RoutedEventArgs e)
        {
           MessageBoxResult mbr=  MessageBox.Show("Çıxmaq istədiyinizdən əminsiz?", "Çıxış", MessageBoxButton.YesNo,MessageBoxImage.Question);
            if (mbr == MessageBoxResult.Yes)
            {
               
                this.Close();
            }
           
        }

        //Sirket adina ve isciye gore axtarisin olunmasi
        private void BtnTaskAxtar_OnClick(object sender, RoutedEventArgs e)
        {
            dgDashboard.Items.Clear();
            //textbox bos buraxilmamasi
            if (string.IsNullOrEmpty(txtTaskAxtar.Text))
            {
                MessageBox.Show("Nə axtarmaq istədiyinizi yazın", "Bildiriş", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }



            List<Model.Task> tasks = db.Tasks.Where(t => (t.Customer.CustomerName.Contains(txtTaskAxtar.Text) || t.User.UserName.Contains(txtTaskAxtar.Text))).ToList();


            //admindirse hamsi gelecek
            if (db.Users.FirstOrDefault(x => x.UserId == currentUserID).RoleID == 1)
            {
                foreach (Model.Task task in tasks)
                {
                    VwTask vw = new VwTask
                    {
                        Description = task.Description,
                        DeadLine = task.DeadlineTime.ToString("dd/MM/yyyy"),
                        Id = task.TaskId,
                        CreateAt = task.CreationAt,
                        Company = task.Customer.CustomerName,
                        FullName = task.User.Surname + " " + task.User.Name,
                        Finished = task.FinishTime==false ? "Bitməyib":"Bitib"
                    };
                    dgDashboard.Items.Add(vw);

                  
                }
            }


            List<Model.Task> tas = db.Tasks.Where(t => (t.Customer.CustomerName.Contains(txtTaskAxtar.Text) || t.User.UserName.Contains(txtTaskAxtar.Text)) && t.UserID == currentUserID).ToList();
            //moderatordusa ancaq oz yazdigi
            if (db.Users.FirstOrDefault(x => x.UserId == currentUserID).RoleID == 2)
            {

                foreach (Model.Task task in tas)
                {
                    string ok = task.FinishTime == false ? "Bitmeyib" : "Bitib";
                    VwTask vw = new VwTask
                    {
                        Description = task.Description,
                        DeadLine = task.DeadlineTime.ToString("dd/MM/yyyy"),
                        Id = task.TaskId,
                        CreateAt = task.CreationAt,
                        Company = task.Customer.CustomerName,
                        FullName = task.User.Surname + " " + task.User.Name,
                        Finished = ok
                };
                    dgDashboard.Items.Add(vw);

                }
            }
        }
    }
}
