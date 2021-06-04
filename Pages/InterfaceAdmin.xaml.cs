using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для InterfaceAdmin.xaml
    /// </summary>
    public partial class InterfaceAdmin : Page
    {
        public byte[] ImagetoByte;
        public Employers bindtoGrid { get; set; }
        public InterfaceAdmin()
        {
            InitializeComponent();
            bindtoGrid = new Employers();
            Savec.Visibility = Visibility.Hidden;
        }
        public InterfaceAdmin(Employers pid)
        {
            InitializeComponent();
            bindtoGrid = pid;
            try
            {
                Stream streamobg = new MemoryStream(bindtoGrid.Photo);
                BitmapImage BitObj = new BitmapImage();
                BitObj.BeginInit();
                BitObj.StreamSource = streamobg;
                BitObj.EndInit();
                this.img.Source = BitObj;
            }
            catch { MessageBox.Show("Вы не добавили картинку для пользователя."); }
            if (pid == null)
            {
                Savec.Visibility = Visibility.Hidden;
            }
            else { 
                addc.Visibility = Visibility.Hidden;
                switch (bindtoGrid.Role)
                {
                    case "Менеджер С": { CMB.SelectedIndex = 2; break; }
                    case "Менеджер А": { CMB.SelectedIndex = 1; break; }
                    case "Администратор": { CMB.SelectedIndex = 0; break; }
                }
                switch (bindtoGrid.Gender)
                {
                    case "М": { GenM.IsChecked = true; break; }
                    case "Ж": { GenWM.IsChecked = true; break; }
                }
            }
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            using (DBContext db = new DBContext()) 
            {
                int cheklastid = db.Employers.Max(y=>y.ID) + 1;
                bindtoGrid.ID = cheklastid;
                if (GenM.IsChecked == true)
                {
                    bindtoGrid.Gender = "М";
                }
                else { if (GenWM.IsChecked == true) { bindtoGrid.Gender = "Ж"; } }
                bindtoGrid.Role = CMB.Text;
                bindtoGrid.Photo = ImagetoByte;
                db.Employers.Add(bindtoGrid);
                db.SaveChanges();
                NavigationService.GoBack();
            }

        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            using (DBContext db = new DBContext())
            {
                if (GenM.IsChecked == true)
                {
                    bindtoGrid.Gender = "М";
                }
                else { if (GenWM.IsChecked == true) { bindtoGrid.Gender = "Ж"; } }
                bindtoGrid.Role = CMB.Text;
                bindtoGrid.Photo = ImagetoByte;
                db.Entry(bindtoGrid).State = EntityState.Modified;
                db.SaveChanges();
                NavigationService.GoBack();
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainMenu());
        }

        private void LoadIMG_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Please select a photo";
            ofd.Filter = "Image Files | *.BMP; *.JPG; *.PNG";
            ofd.Multiselect = false;
            if (ofd.ShowDialog() == true)
            {
                MessageBox.Show("Выбран файл " + ofd.FileName);
            }
            try
            {
                ImageSource III1 = new BitmapImage(new Uri(ofd.FileName));
                ImagetoByte = File.ReadAllBytes(ofd.FileName);
                try
                {
                    Stream streamobg = new MemoryStream(ImagetoByte);
                    BitmapImage BitObj = new BitmapImage();
                    BitObj.BeginInit();
                    BitObj.StreamSource = streamobg;
                    BitObj.EndInit();
                    this.img.Source = BitObj;
                }
                catch { MessageBox.Show("Вы не добавили картинку для пользователя."); }
            }
            catch
            {
                MessageBox.Show("Вы не выбрали фотографию");
            }
        }
    }
}
