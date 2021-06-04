using System;
using System.Collections.Generic;
using System.Linq;
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

namespace UP0201.Pages
{
    /// <summary>
    /// Логика взаимодействия для AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        public static string publicpid;
        public AdminPage()
        {
            InitializeComponent();
            using (DBContext db = new DBContext()) {
                COLLECTuser.ItemsSource = db.Employers.ToList();
            }
        }

        private void Come_Click(object sender, RoutedEventArgs e)
        {
            Employers pid = ((Employers)COLLECTuser.SelectedItem);
            MessageBox.Show(pid.ID.ToString());
            using (DBContext db = new DBContext())
            {
                NavigationService.Navigate(new InterfaceAdmin(pid));
            }
        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            int pid = ((Employers)COLLECTuser.SelectedItem).ID;
            using (DBContext db = new DBContext())
            {
                Employers record = db.Employers.Where(x => x.ID == pid).FirstOrDefault();
                db.Employers.Remove(record);
                db.SaveChanges();
                COLLECTuser.ItemsSource = db.Employers.ToList();
            }
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new InterfaceAdmin());
        }

        private void fnameM_TextChanged(object sender, TextChangedEventArgs e)
        {
            using (DBContext db = new DBContext())
            {
                var olo = db.Employers.Where(x => (x.Lname.Contains(fnameM.Text))).ToList();
                COLLECTuser.ItemsSource = olo;
            }
        }
    }
}
