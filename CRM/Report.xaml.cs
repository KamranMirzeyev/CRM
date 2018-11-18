using CRM.Model;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using MessageBox = System.Windows.MessageBox;

namespace CRM
{
    /// <summary>
    /// Interaction logic for Report.xaml
    /// </summary>
    ///

    public partial class Report : Window
    {
        CRMEntities db = new CRMEntities();
        public Report()
        {
            InitializeComponent();
            FillChart();
        }
        //cartin doldurulmasi
        private void FillChart()
        {

            DateTime curventDate = DateTime.Now;
            //Tasklarin hesabati
            int taskcount=0;
            int compelte = 0;
            int incomplete = 0;
            foreach (Model.Task item in db.Tasks.ToList())
            {
                if (item.CreationAt.Month==curventDate.Month)
                {
                    taskcount++;
                }

                if (item.CreationAt.Month == curventDate.Month&& item.FinishTime==false)
                {
                    compelte++;
                }

                if (item.CreationAt.Month == curventDate.Month && curventDate.Month == item.DeadlineTime.Month &&
                    curventDate.Day - item.DeadlineTime.Day > 0 && item.FinishTime == false)
                {
                    incomplete++;
                }
            }

            curventAllTask.Value = taskcount;
            curventCompleteTask.Value = compelte;
            IncompleteTask.Value = incomplete;
            lblAllTask.Content = taskcount.ToString();
            lblCurventCompleteTask.Content = compelte.ToString();
            lblCompetedTask.Content = (taskcount - compelte).ToString();


            //xatirlama hesabati
            int not = 0;
            foreach (Notification note in db.Notifications.ToList())
            {
                if (note.Create.Month==curventDate.Month)
                {
                    not++;
                }
            }

            notification.Value = not;

            //yaradilan userlerin hesabati
            int user = 0;
            foreach (User u in db.Users.ToList())
            {
                if (u.CreateAt.Month==curventDate.Month)
                {
                    user++;
                }
            }

            NewUsers.Value = user;

            //yeni sirketlerin hesabati
            int company = 0;
            foreach (Customer customer in db.Customers.ToList())
            {
                if (customer.CreateAt.Month==curventDate.Month)
                {
                    company++;
                }
            }

            NewCompany.Value = company;

            // butun commentleri hesabati
            int rey = 0;
            foreach (Comment comment in db.Comments.ToList())
            {
                if (comment.CreateAt.Month==curventDate.Month)
                {
                    rey++;
                }
            }

            AllComment.Value = rey;
        }


        //axtarilan tarixe gore hesabatin cixardilmasi
        private void button_Click(object sender, RoutedEventArgs e)
        {
            //tasklarin hesabati
            int taskAll = 0;
            int comlpeted = 0;
            int incomplete = 0;
            foreach (Model.Task t in db.Tasks.ToList())
            {
                //butun tasklar
                if (t.CreationAt >= dtpStart.SelectedDate && t.CreationAt <= dtpEnd.SelectedDate)
                {
                    taskAll++;
                }
                //bitmemis tasklar
                if (t.CreationAt >= dtpStart.SelectedDate && t.CreationAt <= dtpEnd.SelectedDate && t.FinishTime == false)
                {
                    comlpeted++;
                }

                //yerine yetirilmemis tasklar
                if (t.CreationAt >= dtpStart.SelectedDate && t.CreationAt <= dtpEnd.SelectedDate && t.FinishTime == false && dtpEnd.SelectedDate.Value.Day - t.DeadlineTime.Day < 0)
                {
                    incomplete++;
                }
               // MessageBox.Show((dtpEnd.SelectedDate.Value.Day - t.DeadlineTime.Day < 0).ToString());
            }

            curventAllTask.Value = taskAll;
            curventCompleteTask.Value = comlpeted;
            IncompleteTask.Value = incomplete;
            lblAllTask.Content = taskAll.ToString();
            lblCurventCompleteTask.Content = comlpeted.ToString();
            lblCompetedTask.Content = (taskAll - comlpeted).ToString();


            //Xatirlamalar
            int not = 0;
            foreach (Notification note in db.Notifications.ToList())
            {
                if (note.Create >= dtpStart.SelectedDate && note.Create <= dtpEnd.SelectedDate)
                {
                    not++;
                }
            }

            notification.Value = not;

            //yaradilan yeni userler
            int user = 0;
            foreach (User u in db.Users.ToList())
            {
                if (u.CreateAt >= dtpStart.SelectedDate && u.CreateAt <= dtpEnd.SelectedDate)
                {
                    user++;
                }
            }

            NewUsers.Value = user;

            //yaradilan yeni sirketler
            int company = 0;
            foreach (Customer customer in db.Customers.ToList())
            {
                if (customer.CreateAt >= dtpStart.SelectedDate && customer.CreateAt <= dtpEnd.SelectedDate)
                {
                    company++;
                }
            }

            NewCompany.Value = company;

            //butun commetler
            int rey = 0;
            foreach (Comment comment in db.Comments.ToList())
            {
                if (comment.CreateAt >= dtpStart.SelectedDate && comment.CreateAt <= dtpEnd.SelectedDate)
                {
                    rey++;
                }
            }

            AllComment.Value = rey;


        }
    }
}
