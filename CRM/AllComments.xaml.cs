using CRM.Model;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace CRM
{
    /// <summary>
    /// Interaction logic for AllComments.xaml
    /// </summary>
    public partial class AllComments : Window
    {
        public AllComments()
        {
            InitializeComponent();
            FillReyDataGrid();
        }
        CRMEntities db = new CRMEntities();
        private void FillReyDataGrid()
        {
            dgRey.Items.Clear();

            foreach (Comment comment in db.Comments.ToList())
            {
                vwComment vw = new vwComment()
                {
                    Id = comment.CommentId,
                    FullName = comment.User.Name + " "+comment.User.Surname,
                    Company = comment.Customer.CustomerName,
                    Comment = comment.CommentText
                };
                dgRey.Items.Add(vw);
            }
        }

        private void btnReyAxtar_Click(object sender, RoutedEventArgs e)
        {
            dgRey.Items.Clear();
            if (string.IsNullOrEmpty(txtReyAxtar.Text))
            {
                MessageBox.Show("Nə axtarmaq istədiyinizi yaxın", "Bildiriş", MessageBoxButton.OK, MessageBoxImage.Stop);
                return;
            }

            List<Comment> com = db.Comments.Where(x =>
                (x.Customer.CustomerName.Contains(txtReyAxtar.Text)) ||
                ((x.User.Name + " " + x.User.Surname).Contains(txtReyAxtar.Text))).ToList();

            foreach (Comment comment in com)
            {
                vwComment vw = new vwComment()
                {
                    Id = comment.CommentId,
                    FullName = comment.User.Name + " " + comment.User.Surname,
                    Company = comment.Customer.CustomerName,
                    Comment = comment.CommentText
                };
                dgRey.Items.Add(vw);
            }
        }
    }
}
