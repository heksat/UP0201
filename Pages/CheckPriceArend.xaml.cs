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
    /// Interaction logic for CheckPriceArend.xaml
    /// </summary>
    public partial class CheckPriceArend : Page
    {
        public CheckPriceArend()
        {
            InitializeComponent();
            using (var db = new DBContext())
            {
                cmdbox.ItemsSource = db.Arendatory.ToList();
                
            }
        }

        private void cmdbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            using (var db = new DBContext())
            {
                CollectionItems.ItemsSource = db.ViewStoimostArend((int?)cmdbox.SelectedValue).ToList();
            }
        }
    }
}
