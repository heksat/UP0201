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
    /// Interaction logic for InterfaceArendatories.xaml
    /// </summary>
    public partial class InterfaceArendatories : Page
    {
        public Arendatory item { get; set; }

        public InterfaceArendatories()
        {
            InitializeComponent();
        }

        private void Change_item(object sender, RoutedEventArgs e)
        {
            using (var db = new DBContext()) {
                db.Entry(item).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        private void Click_ToBack(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
