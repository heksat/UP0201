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
    /// Interaction logic for Auth.xaml
    /// </summary>
    public partial class Auth : Page
    {
        private string capchastr = "";
        private int countlogin = 0;
        public Auth()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string roleuser;
            if (capchastr == CapchaUser.Text)
            {
                using (var db = new DBContext())
                {
                    roleuser = db.Employers.Where(x => (x.Pass == Password.Password) && (x.Login == Login.Text)).Select(x => x.Role).FirstOrDefault();
                }
                if (roleuser != null)
                {
                    MessageBox.Show("Успешный вход!");
                    NavigationService.Navigate(new MainMenu());
                }
                else
                {
                    if (countlogin != 3)
                    {
                        countlogin += 1;
                    }
                    else
                    {
                        Capcha.Visibility = Visibility.Visible;
                        CapchaUser.Visibility = Visibility.Visible;
                        CapchaGround.Visibility = Visibility.Visible;
                        GenerationCapcha();
                    }
                }
            }
            else
            {
                GenerationCapcha();
                Login.Text = String.Empty;
                Password.Password = String.Empty;
                CapchaUser.Text = String.Empty;
            }
            
        }
        private void GenerationCapcha()
        {
            Random rnd = new Random();
            capchastr = "";
            for (int i = 0; i<5;i++) {
                char newchar = (char)(rnd.Next(48, 57) + rnd.Next(8, 25) + rnd.Next(7, 25));
                capchastr += newchar;
            }
            Capcha.Text = capchastr;
        }

        private void Image_MouseUp(object sender, MouseButtonEventArgs e)
        {
            GenerationCapcha();
        }
    }
}
