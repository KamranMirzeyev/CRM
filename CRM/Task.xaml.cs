using CRM.Model;
using System;
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

            if (rtbDescript.Selection.Text.Length == say)
            {
                e.Handled = true;
                MessageBox.Show("Artıq simvol yaza bilməzsiz");
                return;
            }
            say--;
            lbl200.Content = say.ToString();

        }
    }
}
