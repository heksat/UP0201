using Microsoft.Win32;
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
using System.IO;

namespace UP0201.Pages
{
    /// <summary>
    /// Логика взаимодействия для InterfaceTC.xaml
    /// </summary>
    public partial class InterfaceTC : Page
    {
        public static byte[] ImagetoByte;
        public InterfaceTC()
        {
            InitializeComponent();
            if (CollectionTC.globalTC != null)
            {
                addc.Visibility = Visibility.Hidden;
                using (DBContext db = new DBContext())
                {
                    NameofTC.Text = CollectionTC.globalTC;
                    City.Text = db.TC.Where(x => x.Name == CollectionTC.globalTC).Select(y => y.City).FirstOrDefault();
                    Pricetc.Text = db.TC.Where(x => x.Name == CollectionTC.globalTC).Select(y => y.Price).FirstOrDefault().ToString();
                    CountPavil.Text = db.TC.Where(x => x.Name == CollectionTC.globalTC).Select(y => y.CountPavil).FirstOrDefault().ToString();
                    koefofTC.Text = db.TC.Where(x => x.Name == CollectionTC.globalTC).Select(y => y.Koef).FirstOrDefault().ToString();
                    STATUSCOMBO.Text = db.TC.Where(x => x.Name == CollectionTC.globalTC).Select(y => y.Status).FirstOrDefault();
                    Stages.Text = db.TC.Where(x => x.Name == CollectionTC.globalTC).Select(y => y.Stages).FirstOrDefault().ToString();
                }
            }
            else
            {
                Savec.Visibility = Visibility.Hidden;
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            bool q = true;
            using (DBContext db = new DBContext())
            {
                try
                {
                    TC PRIVET = db.TC.Where(x => x.Name == CollectionTC.globalTC).Select(y => y).FirstOrDefault();
                    if (NameofTC.Text != "")
                    {
                        PRIVET.Name = NameofTC.Text.Trim();
                        if (STATUSCOMBO.Text != "")
                        {
                            if (STATUSCOMBO.Text == "План")
                            {
                                var qwerty = db.Pavils.Where(x => x.Name == CollectionTC.globalTC);

                                foreach (var sen in qwerty)
                                {
                                    if (sen.Status == "Забронировано")
                                    {
                                        q = false;
                                    }
                                }
                            }
                            if (q)
                            {
                                PRIVET.Status = STATUSCOMBO.Text;
                                if (Convert.ToDouble(koefofTC.Text) > 0.1)
                                {
                                    PRIVET.Koef = Convert.ToDouble(koefofTC.Text);
                                }
                                else { PRIVET.Koef = 0.2; koefofTC.Text = "0.2"; }
                                if (Convert.ToInt32(Pricetc.Text) > 0)
                                {
                                    PRIVET.Price = Convert.ToInt32(Pricetc.Text);
                                }
                                else { PRIVET.Price = 0; Pricetc.Text = "0"; }
                                if (Convert.ToInt32(CountPavil.Text) >= 0)
                                {
                                    PRIVET.CountPavil = Convert.ToInt32(CountPavil.Text);
                                }
                                else { PRIVET.CountPavil = 0; CountPavil.Text = "0"; }
                                if (Convert.ToInt32(Stages.Text) >= 0)
                                {
                                    PRIVET.Stages = Convert.ToInt32(Stages.Text);
                                }
                                else { PRIVET.Stages = 0; Stages.Text = "0"; }
                                if (City.Text != "")
                                {
                                    PRIVET.City = City.Text;
                                    PRIVET.Image = ImagetoByte;
                                    try
                                    {
                                        Stream streamobg = new MemoryStream(PRIVET.Image);
                                        BitmapImage BitObj = new BitmapImage();
                                        BitObj.BeginInit();
                                        BitObj.StreamSource = streamobg;
                                        BitObj.EndInit();
                                        this.tcimg.Source = BitObj;
                                    }
                                    catch { MessageBox.Show("Вы не добавили картинку для фильма."); }
                                    db.SaveChanges();
                                    MessageBox.Show("Успешно добавлено");
                                }
                                else { MessageBox.Show("Вы не ввели город"); }
                            }
                            else { MessageBox.Show("Выберите другой статуст так как в этом ТЦ есть забронированные павильоны"); }
                        }
                        else { MessageBox.Show("Вы не выбрали статус"); }
                    }
                    else { MessageBox.Show("Вы не выбрали имя для города"); }
                }
                catch { MessageBox.Show("Вы ввели некорректные данные"); }
            }
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
            }
            catch
            {
                MessageBox.Show("Вы не выбрали фотографию");
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainMenu());
            CollectionTC.globalTC = null;
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TC tc = new TC();
                if (NameofTC.Text != "")
                {
                    tc.Name = NameofTC.Text.Trim();
                    if (STATUSCOMBO.Text != "")
                    {
                        tc.Status = STATUSCOMBO.Text;
                        if (Convert.ToDouble(koefofTC.Text) > 0.1)
                        {
                            tc.Koef = Convert.ToDouble(koefofTC.Text);
                        }
                        else { tc.Koef = 0.2; koefofTC.Text = "0.2"; }
                        if (Convert.ToInt32(Pricetc.Text) > 0)
                        {
                            tc.Price = Convert.ToInt32(Pricetc.Text);
                        }
                        else { tc.Price = 0; Pricetc.Text = "0"; }
                        if (Convert.ToInt32(CountPavil.Text) >= 0)
                        {
                            tc.CountPavil = Convert.ToInt32(CountPavil.Text);
                        }
                        else { tc.CountPavil = 0; CountPavil.Text = "0"; }
                        if (Convert.ToInt32(Stages.Text) >= 0)
                        {
                            tc.Stages = Convert.ToInt32(Stages.Text);
                        }
                        else { tc.Stages = 0; Stages.Text = "0"; }
                        if (City.Text != "")
                        {
                            tc.City = City.Text;
                            tc.Image = ImagetoByte;
                            using (DBContext db = new DBContext())
                            {
                                try
                                {
                                    Stream streamobg = new MemoryStream(tc.Image);
                                    BitmapImage BitObj = new BitmapImage();
                                    BitObj.BeginInit();
                                    BitObj.StreamSource = streamobg;
                                    BitObj.EndInit();
                                    this.tcimg.Source = BitObj;
                                }
                                catch { MessageBox.Show("Вы не добавили картинку для фильма."); }
                                db.TC.Add(tc);
                                db.SaveChanges();
                                MessageBox.Show("Успешно добавлено");
                            }
                        }
                        else { MessageBox.Show("Вы не ввели город"); }
                    }
                    else { MessageBox.Show("Вы не выбрали статус"); }
                }
                else { MessageBox.Show("Вы не выбрали имя для города"); }
            } catch { MessageBox.Show("Вы ввели некорректные данные"); }
        }
    }
}
