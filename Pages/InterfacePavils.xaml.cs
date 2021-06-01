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
using System.Data.Entity;


namespace UP0201.Pages
{
    /// <summary>
    /// Interaction logic for InterfacePavils.xaml
    /// </summary>
    public partial class InterfacePavils : Page
    {
        public Pavils Changedpavil { get; set; }
        public Pavils NewPavil;
        DBContext db = new DBContext();
        public InterfacePavils()
        {
            InitializeComponent();

        }
        public InterfacePavils(Pavils currentpavil) : this()
        {

            NewPavil = db.Pavils.Where(x=> x.Name==currentpavil.Name && x.NumberOfPavil==currentpavil.NumberOfPavil && x.Stage==currentpavil.Stage).AsQueryable().FirstOrDefault();
            db.Pavils.Remove(NewPavil);
            Changedpavil = currentpavil;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            db.Pavils.Add(Changedpavil);
            db.SaveChanges();
            NavigationService.GoBack();
        }
    }
}
