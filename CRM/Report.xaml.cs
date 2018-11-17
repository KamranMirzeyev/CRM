using CRM.Model;
using System;
using System.Linq;
using System.Windows;

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

                if (item.CreationAt.Month == curventDate.Month&& item.FinishTime==true)
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
            lblCurventCompleteTask.Content = (taskcount - compelte).ToString(); 
            lblCompetedTask.Content = compelte.ToString();



            int not = 0;
            foreach (Notification note in db.Notifications.ToList())
            {
                if (note.Create.Month==curventDate.Month)
                {
                    not++;
                }
            }

            notification.Value = not;


            int user = 0;
            foreach (User u in db.Users.ToList())
            {
                if (u.CreateAt.Month==curventDate.Month)
                {
                    user++;
                }
            }

            NewUsers.Value = user;

            int company = 0;
            foreach (Customer customer in db.Customers.ToList())
            {
                if (customer.CreateAt.Month==curventDate.Month)
                {
                    company++;
                }
            }

            NewCompany.Value = company;

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

    }
}
