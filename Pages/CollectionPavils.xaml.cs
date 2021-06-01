using System;
using System.Collections.Generic;
using System.Data.Entity;
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
    /// Interaction logic for CollectionPavils.xaml
    /// </summary>
    public partial class CollectionPavils : Page
    {
        public CollectionPavils()
        {
            InitializeComponent();
            using (var db = new DBContext())
            {
                CollectionItem.ItemsSource = db.Pavils.ToList();
                var templist = db.Pavils.Select(x => x.Status).Distinct().ToList();
                templist.Add("Нет");
                Status.ItemsSource = templist;
                Status.SelectedIndex = templist.Count() - 1;
            }
        }


        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !(Char.IsDigit(e.Text, 0));
        }

        private void FindItems(object sender, RoutedEventArgs e)
        {
            int ot = -1;
            int _do = -1;
            int stg = -1;
            int.TryParse(Areafrom.Text,out ot);
            int.TryParse(Areaafter.Text,out _do);
            int.TryParse(Stage.Text, out stg);
            using (var db = new DBContext())
            {
                CollectionItem.ItemsSource = db.Pavils.Where(x => x.Status == ((Status.SelectedItem.ToString() == "Нет") ? x.Status : Status.SelectedItem.ToString()) && ((x.Area >= ot || ot == 0) && (x.Area <= _do || _do==0)) && (x.Stage == stg || stg==0)).ToList();
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new DBContext())
            {
                db.Entry((Pavils)CollectionItem.SelectedItem).State = EntityState.Deleted;
                db.SaveChanges();
                CollectionItem.ItemsSource = db.Pavils.ToList();
            }
        }

        private void Changed_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new InterfacePavils((Pavils)CollectionItem.SelectedItem));
        }
    }
}
