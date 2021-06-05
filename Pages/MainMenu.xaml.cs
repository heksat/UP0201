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
    /// Логика взаимодействия для Menu.xaml
    /// </summary>
    public partial class MainMenu : Page
    {
        public int lvllock { get; set; } 
        public MainMenu()
        {
            InitializeComponent();
            switch (lvllock)
            {
                case 2: 
                    {
                        Userbut.IsEnabled = true;
                        TCbut.IsEnabled = true;
                        Pavilbut.IsEnabled = true;
                        Arenbut.IsEnabled = true;
                        Userbut.IsEnabled = true;
                    } break;
                case 1 :
                    {
                        Pavilbut.IsEnabled = true;
                        TCbut.IsEnabled = true;
                    }
                    break;
                case 3:
                    {
                        TCbut.IsEnabled = true;
                        Pavilbut.IsEnabled = true;
                        Arenbut.IsEnabled = true;
                    }
                    break;
            }
        }

        private void SpisTC_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CollectionTC());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CollectionPavils());//
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AdminPage());
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CollectionArendatories());
        }
    }
}
