using System;
using CRM.Model;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interop;
using System.Windows.Documents;

namespace CRM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CRMEntities db = new CRMEntities();
        public int currentUserID;
       
        //userin kim oldugu tapilmasi
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string name = db.Users.FirstOrDefault(x => x.UserId == currentUserID).Name;
            string surname = db.Users.FirstOrDefault(x => x.UserId == currentUserID).Surname;

            lblCurventUser.Content = name + " " + surname;


            //Notification ekrana cixardilmasi
            Notification();



        }


        public MainWindow()
        {
            InitializeComponent();
          
        }


        //Notification ekrana cixardilmasi metodu
        public void Notification()
        {
            CRMEntities dbs = new CRMEntities();

            foreach (Notification nt in dbs.Notifications.ToList())
            {
                if (nt.Task.User.UserId == currentUserID && nt.IsActive == false)
                {
                    switch (nt.NotificationType)
                    {
                        case 1:

                            if (nt.Task.DeadlineTime.Subtract(DateTime.Now).TotalHours <= 24)
                            {
                                lblnotification.Content +=
                                    nt.Task.Customer.CustomerName + " : " + nt.Task.Description + " *** ";
                            }

                            break;
                        case 2:

                            if (nt.Task.DeadlineTime.Subtract(DateTime.Now).TotalHours > 24 &&
                                nt.Task.DeadlineTime.Subtract(DateTime.Now).TotalHours < 72)
                            {
                                lblnotification.Content +=
                                    nt.Task.Customer.CustomerName + " : " + nt.Task.Description + " *** ";
                            }

                            break;

                        case 3:
                            lblnotification.Content += nt.Task.Customer.CustomerName + " : " + nt.Task.Description + "  ***  ";


                            break;

                    }
                }

            }
        }


        //datagrid doldurulmasi
        private void FillDasboard()
        {
            CRMEntities db = new CRMEntities();
            dgDashboard.Items.Clear();
           

            //admindirse hamsi gelecek
            if (db.Users.FirstOrDefault(x => x.UserId == currentUserID).RoleID == 1)
            {
                

                foreach (Model.Task task in db.Tasks.ToList())
                {
                    string ok = task.FinishTime == false ? "Bitməyib" : "Bitib";
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
                    string ok = task.FinishTime == false ? "Bitməyib" : "Bitib";
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
        
        //company add olunma
        private void CompanyAdd_OnClick(object sender, RoutedEventArgs e)
        {
          CustomerWPF custom = new CustomerWPF();
            custom.Show();
        }
        //task add olunma
        private void TaskAdd_OnClick(object sender, RoutedEventArgs e)
        {
            Task task = new Task();
            //WindowInteropHelper help= new WindowInteropHelper(task);
            //IntPtr hm = help.Handle;
            task.AddTaskButton();
            task.UserID = currentUserID;
            task.ShowDialog();
        }
       
       
        //user add
        private void UserAdd_OnClick(object sender, RoutedEventArgs e)
        {
            Istifadəçi i = new Istifadəçi();
            WindowInteropHelper help = new WindowInteropHelper(i);
            IntPtr hm = help.Handle;
            i.AddButton();
            i.Show();
        }

        //rey elave olunma
        private void ReyAdd_OnClick(object sender, RoutedEventArgs e)
        {
            Rey rey = new Rey();
            rey.userid = currentUserID;
            rey.Show();
        }

       
        //butun tasklarin cagirilmasi
        private void AllTask_OnClick(object sender, RoutedEventArgs e)
        {
            FillDasboard();
        }

        
        //logout buton
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



            List<Model.Task> tasks = db.Tasks.Where(t =>
                (t.Customer.CustomerName.Contains(txtTaskAxtar.Text) ||
                 ((t.User.Name + " " + t.User.Surname).Contains(txtTaskAxtar.Text)))).ToList();


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

        //butun userlerie baxis update ve delete
        private void AllUser_OnClick(object sender, RoutedEventArgs e)
        {
          AllUsers au = new AllUsers();
            au.ShowDialog();
        }

        //datagrid takslarin update olunmasi
        private void dgDashboard_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {

            if (dgDashboard.SelectedItem != null) 
            
            {
                VwTask vwTask = dgDashboard.SelectedItem as VwTask;

                Task task = new Task();
                TextRange textRange = new TextRange(task.rtbDescript.Document.ContentStart, task.rtbDescript.Document.ContentEnd);
                task.Title = "Yenilə";
                task.UserID = currentUserID;
                task.MainWindow = this;
                textRange.Text = vwTask.Description;
               
                task.UpdateTaskButton();
                task.TaskModel = db.Tasks.Find(vwTask.Id);
                task.ShowDialog();
            }

            
        }

        //butun commentlere baxis
        private void AllComment_OnClick(object sender, RoutedEventArgs e)
        {
            AllComments ac = new AllComments();
            ac.ShowDialog();
        }

        //butun sirketlere baxis
        private void AllCompany_OnClick(object sender, RoutedEventArgs e)

        { 
            AllCompanies company = new AllCompanies();
            company.ShowDialog();
        }


        //Tasklarin cagirilmasi
        private void DashTask_OnClick(object sender, RoutedEventArgs e)
        {
            FillDasboard();
        }

        private void Report_OnClick(object sender, RoutedEventArgs e)
        {
           Report r = new Report();
            r.ShowDialog();
        }
    }
}
