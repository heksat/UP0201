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
    /// Interaction logic for CollectionArendatories.xaml
    /// </summary>
    public partial class CollectionArendatories : Page
    {
        public CollectionArendatories()
        {
            InitializeComponent();
            using (var db = new DBContext())
            {
                CollectionItem.ItemsSource = db.Arendatory.ToList();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var page = new InterfaceArendatories();
            page.item = (Arendatory)CollectionItem.SelectedItem;
            NavigationService.Navigate(page);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CheckPriceArend());
        }
    }
}
