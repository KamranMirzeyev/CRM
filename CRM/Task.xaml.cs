using CRM.Model;
using System;
using System.Data.Entity;
using System.Linq;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;

namespace CRM
{
    /// <summary>
    /// Interaction logic for Task.xaml
    /// </summary>
    public partial class Task : Window
    {
        CRMEntities db = new CRMEntities();
        public Model.Task TaskModel;
       
        public MainWindow MainWindow;
        public int UserID;


       
        public Task()
        {
            InitializeComponent();
            FillCmbCustomer();

            //richtextbox icindeki yazinin silinmesi
            TextRange txt = new TextRange(rtbDescript.Document.ContentStart, rtbDescript.Document.ContentEnd);
            txt.Text = "";
        }

        //combobox customerin doldurulmasi
        private void FillCmbCustomer()
        {
           
            foreach (Customer cusmoter in db.Customers.ToList())
            {
                cmbCustomer.Items.Add(cusmoter);
            }
        }

        public void AddTaskButton()
        {
            btnTaskUpdate.Visibility = Visibility.Hidden;
            chbFinish.Visibility = Visibility.Hidden;
        }

        public void UpdateTaskButton()
        {
            btnTaskAdd.Visibility = Visibility.Hidden;
            chbFinish.Visibility = Visibility.Visible;
        }


        //Yeni task yaradilmasi

        private void BtnTaskAdd_OnClick(object sender, RoutedEventArgs e)
        {
            TextRange textRange = new TextRange(rtbDescript.Document.ContentStart, rtbDescript.Document.ContentEnd);
            //Validationlar yazildi
            if (cmbCustomer.SelectedIndex==-1)
            {
                MessageBox.Show("Müştəri seçin", "Xəbərdarlıq", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }


            if (textRange.Text.Length == 0)
            {
                MessageBox.Show("Qisa izah daxil edin", "Xəbərdarlıq", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            if (string.IsNullOrEmpty(dtpDeadline.Text))
            {
                MessageBox.Show("Bitiş tarixini qeyd edin", "Xəbərdarlıq", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            //yeni task elave edilmesi
            Customer c = cmbCustomer.SelectedItem as Customer;

            Model.Task task = new Model.Task();

            task.CustomerID = c.CustomerId;
            task.CreationAt=DateTime.Now;
            task.DeadlineTime = dtpDeadline.SelectedDate.Value;
            task.Description = textRange.Text;
            task.FinishTime = false;
            task.UserID = UserID;
            db.Tasks.Add(task);
            db.SaveChanges();
            MessageBox.Show("Task əlavə edildi","Bildiriş",MessageBoxButton.OK,MessageBoxImage.Information);
            this.Close();
        }

        //Textrich max uzunlugun oxlanmasi
        int say = 200;
        private void rtbDescript_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            TextRange textRange = new TextRange(rtbDescript.Document.ContentStart, rtbDescript.Document.ContentEnd);
            //richtextbox 200 simoldan artiq yazmama xeberdarligi
            if (e.Key == Key.Back || e.Key == Key.Delete)
            {
                if (say==200)
                {
                    return;
                }
                say++;
                lbl200.Content = say.ToString();
                return;
            }

            if (textRange.Text.Length == 200)
            {
                e.Handled = true;
                MessageBox.Show("Artıq simvol yaza bilməzsiz");
                return;
            }
            say--;
            lbl200.Content = say.ToString();

        }


        //Task yenilemesi ucun doldurulma metodu
        public void FillAllTask()
        {
            if (cmbCustomer.SelectedValue!=null)
            {
                cmbCustomer.SelectedValue = TaskModel.CustomerID.ToString();
                rtbDescript.AppendText(TaskModel.Description);
                dtpDeadline.Text = TaskModel.DeadlineTime.ToString();
            }
           
        }
        private void Window_ContentRendered(object sender, EventArgs e)
        {
            FillAllTask();
        }


        //Update olunmasi
        private void btnTaskUpdate_Click(object sender, RoutedEventArgs e)
        {
            TextRange textRange = new TextRange(rtbDescript.Document.ContentStart, rtbDescript.Document.ContentEnd);
            //Validationlar yazildi
            if (cmbCustomer.SelectedIndex == -1)
            {
                MessageBox.Show("Müştəri seçin", "Xəbərdarlıq", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }


            if (textRange.Text.Length == 0)
            {
                MessageBox.Show("Qisa izah daxil edin", "Xəbərdarlıq", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            if (string.IsNullOrEmpty(dtpDeadline.Text))
            {
                MessageBox.Show("Bitiş tarixini qeyd edin", "Xəbərdarlıq", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            Model.Task upTask = db.Tasks.Find(TaskModel.TaskId);
            if (chbFinish.IsChecked.Value)
            {
                upTask.FinishTime = true;
            }

            upTask.CustomerID = Convert.ToInt32(cmbCustomer.SelectedValue);
            upTask.DeadlineTime = dtpDeadline.SelectedDate.Value;
            upTask.Description = textRange.Text;
            upTask.UserID = UserID;
            upTask.CreationAt = TaskModel.CreationAt;
            db.SaveChanges();
            MessageBox.Show("Task yeniləndi", "Bildiriş", MessageBoxButton.OK, MessageBoxImage.Information);
            this.Close();

        }




    }
}
