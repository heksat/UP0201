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
    /// Логика взаимодействия для TCfunction.xaml
    /// </summary>
    public partial class TCfunction : Page
    {
        public TCfunction()
        {
            InitializeComponent();
            using (DBContext db = new DBContext())
            {
                CMD.ItemsSource = db.TC.Select(x => x.Name).ToList();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (DBContext db = new DBContext())
            {
                
                System.Data.SqlClient.SqlParameter param = new System.Data.SqlClient.SqlParameter("@priceTC",db.TC.Where(x=>x.Name == CMD.Text).Select(y=>y.Price).FirstOrDefault());
                System.Data.SqlClient.SqlParameter param1 = new System.Data.SqlClient.SqlParameter("@nameoftc", db.TC.Where(x => x.Name == CMD.Text).Select(y => y.Name).FirstOrDefault());
                double? query = db.Database.SqlQuery<double?>("SELECT dbo.funcofposchet (@priceTC,@nameoftc)", param, param1).FirstOrDefault();
                var er = db.spisfunc((float?)query,db.TC.Where(x=>x.Name==CMD.Text).Select(y=>y.Name).FirstOrDefault());
                gr.ItemsSource = er;


            }
        }
    }
}
