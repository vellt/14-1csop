using gyak_vizsga_asztali_kolcsonzo.Models;
using NetworkHelper;
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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string baseUrl = "http://localhost:3000";
        public MainWindow()
        {
            InitializeComponent();
            kolcsonzokCbx.ItemsSource = Backend.GET(baseUrl + "/kolcsonzok").Send().ToList<Kolcsonzo>();
            kolcsonzokCbx.SelectedIndex = 0;

            konyvCbx.ItemsSource = Backend.GET(baseUrl + "/konyvek").Send().ToList<Konyv>();
            konyvCbx.SelectedIndex = 0;

            konyvLbx.ItemsSource= Backend.GET(baseUrl + "/konyvek").Send().ToList<Konyv>();
            konyvLbx.SelectedIndex = 0;
        }

        private void listabaBtn_Click(object sender, RoutedEventArgs e)
        {
            Konyv kivalasztottKonyv = konyvCbx.SelectedItem as Konyv;
            Kolcsonzo kivalasztottKolcsonzo = kolcsonzokCbx.SelectedItem as Kolcsonzo;
            int darab = 0;
            try
            {
                darab = Convert.ToInt32(darabTbx.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Nem megfelelő bevitel");
                return;
            }
            if (darab <= 0)
            {
                MessageBox.Show("Nem megfelelő bevitel");
            }
            else
            {
                Kolcsonzes kolcsonzes = new Kolcsonzes()
                {
                    kivitel_datum = DateTime.Now,
                    kolcsonzo_id = kivalasztottKolcsonzo.kolcsonzo_id,
                    konyv_id = kivalasztottKonyv.konyv_id,
                    peldanyszam = darab,
                    display = $"{kivalasztottKolcsonzo} {kivalasztottKonyv} ({darab})db"
                };
                kolcsonzesLbx.Items.Add(kolcsonzes);
            }
            
        }

        private void adatbazisbaBtn_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in kolcsonzesLbx.Items.Cast<Kolcsonzes>().ToList())
            {
                string uzenet = Backend.POST(baseUrl + "/kolcsonzesek").Body(item).Send().Message;
                MessageBox.Show($"{uzenet} ({item})");
                if (uzenet != "hiba") kolcsonzesLbx.Items.Remove(item); 
                // ha el kell távolítani elemeket abból a listából amiket körbejárunk, hívjuk meg a foreach-ben a toListet 
            }
            // kolcsonzesLbx.Items.Clear();
        }

        private void konyvLbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Konyv kivalasztottKonyv = (sender as ListBox).SelectedItem as Konyv;
            szerzoTxb.Text = kivalasztottKonyv.szerzo;
        }
    }
}
