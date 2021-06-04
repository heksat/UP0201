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
    /// Interaction logic for ProcViewTC.xaml
    /// </summary>
    public partial class ProcViewTC : Page
    {
        public ProcViewTC()
        {
            InitializeComponent();
            using (var db = new DBContext()) {
                TCCollect.ItemsSource = db.TC.Select(x=>x.Name).ToList();
            }
        }

        private void ChangeName(object sender, SelectionChangedEventArgs e)
        {
            using (var db = new DBContext())
            {
                CollectionItems.ItemsSource = db.ViewTC(TCCollect.SelectedItem.ToString()).ToList();
            }
        }
    }
}
