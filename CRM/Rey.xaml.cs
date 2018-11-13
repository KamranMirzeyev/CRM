using CRM.Model;
using System.Linq;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;

namespace CRM
{
    /// <summary>
    /// Interaction logic for Rey.xaml
    /// </summary>
    public partial class Rey : Window
    {
        CRMEntities db = new CRMEntities();
        public int userid;
        public Rey()
        {
            InitializeComponent();
            FillReyCmb();
            TextRange txt = new TextRange(rtbRey.Document.ContentStart, rtbRey.Document.ContentEnd);
            txt.Text = "";
        }

        //combobox doldurulmasi
        private void FillReyCmb()
        {
            foreach (Customer cus in db.Customers.ToList())
            {
                cmbReyCompany.Items.Add(cus);
            }
        }


        //rey elave edilme
        private void btnReyAdd_Click(object sender, RoutedEventArgs e)
        {
            TextRange textRange = new TextRange(rtbRey.Document.ContentStart, rtbRey.Document.ContentEnd);
            //Validationlar bos buraxilmamasi
            if (cmbReyCompany.SelectedIndex == -1)
            {
                MessageBox.Show("Müştəri seçin", "Xəbərdarlıq", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }


            if (textRange.Text.Length == 0)
            {
                MessageBox.Show("Qisa izah daxil edin", "Xəbərdarlıq", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
           // yeni rey elave edilmesi

            Customer c= cmbReyCompany.SelectedItem as Customer;
          

            Comment com = new Comment();
            com.UserID = userid;
            com.CustomerID = c.CustomerId;
            com.CommentText = textRange.Text;

            db.Comments.Add(com);
            db.SaveChanges();
            MessageBox.Show("Rəy əlavə edildi","Bildiriş",MessageBoxButton.OK,MessageBoxImage.Information);
            this.Close();

        }




        //richtextboxun 500 de artiq simvolun kecmemesi validationi
        private int say = 500;
        private void rtbRey_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            TextRange textRange = new TextRange(rtbRey.Document.ContentStart, rtbRey.Document.ContentEnd);
            //richtextbox 500 simoldan artiq yazmama xeberdarligi
            if (e.Key == Key.Back || e.Key == Key.Delete)
            {
                if (say == 500)
                {
                    return;
                }
                say++;
                lbl500.Content = say.ToString();
                return;
            }

            if (textRange.Text.Length == 500)
            {
                e.Handled = true;
                MessageBox.Show("Artıq simvol yaza bilməzsiz");
                return;
            }
            say--;
            lbl500.Content = say.ToString();
        }
    }
}
