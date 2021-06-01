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
    /// Логика взаимодействия для CollectionTC.xaml
    /// </summary>
    public partial class CollectionTC : Page
    {
        public static string globalTC;
        public CollectionTC()
        {
            InitializeComponent();
            using (DBContext db = new DBContext())
            {
                COLLECTTC.ItemsSource = db.TC.Where(X=>X.Status!="Удален" && X.Status!="Строительство").OrderBy(x=>x.Name).ThenBy(y=>y.Status).ToList();
                
            }
        }

        private void Poisk_Click(object sender, RoutedEventArgs e)
        {
            string chek1 = CITI.Text;
            string chek2 = STATUSCOMBO.Text;
            using (DBContext db = new DBContext())
            {
                var olo = db.TC.Where(x => (x.Status == chek2 || x.Status==null || x.Status == "") && (x.City.Contains(chek1) || x.City == null) && x.Status!="Удален").ToList();
                COLLECTTC.ItemsSource = olo;
            }
        }

        private void Obnov_Click(object sender, RoutedEventArgs e)
        {
            using (DBContext db = new DBContext())
            {
                COLLECTTC.ItemsSource = db.TC.ToList();
            }
        }
        private void Come_Click(object sender, RoutedEventArgs e)
        {
            string pid = ((TC)COLLECTTC.SelectedItem).Name;
            using (DBContext db = new DBContext())
            {
                globalTC = pid;
                NavigationService.Navigate(new InterfaceTC());
            }
        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            string pid = ((TC)COLLECTTC.SelectedItem).Name;
            using (DBContext db = new DBContext())
            {
                var removeitem = db.TC.Where(x => x.Name == pid).Select(y => y).FirstOrDefault();
                db.TC.Remove(removeitem);
                db.SaveChanges();
                COLLECTTC.ItemsSource = db.TC.ToList();
            }
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            string globalTC = null;
            NavigationService.Navigate(new InterfaceTC());
        }
    }
}
