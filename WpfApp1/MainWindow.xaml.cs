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
using NetworkHelper;
using Tanfolyam_console.Models;

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
            // tanulók
            var tanulok= Backend.GET(baseUrl + "/tanulok").Send().ToList<Tanulo>();
            tanuloCbx.ItemsSource = tanulok;
            tanuloCbx.DisplayMemberPath = "nev";
            tanuloCbx.SelectedIndex = 0;
            // tárgyak
            targyCbx.ItemsSource = Backend.GET(baseUrl + "/tantargyak").Send().ToList<Tantargy>();
            targyCbx.DisplayMemberPath = "megnevezes";
            targyCbx.SelectedIndex = 0;
            // tab2
            naploTanuloCbx.ItemsSource = tanulok;
            naploTanuloCbx.DisplayMemberPath="nev";
            naploTanuloCbx.SelectedIndex = 0;
        }

        private void naplobaBtn_Click(object sender, RoutedEventArgs e)
        {
            Tanulo tanulo = tanuloCbx.SelectedItem as Tanulo;
            Tantargy tantargy = targyCbx.SelectedItem as Tantargy;
            if(ertekelesTxb.Text == "1" ||
                ertekelesTxb.Text == "2" ||
                ertekelesTxb.Text == "3" ||
                ertekelesTxb.Text == "4" ||
                ertekelesTxb.Text == "5")
            {
                int jegy = Convert.ToInt32(ertekelesTxb.Text);
                Ertekeles ujErtekeles = new Ertekeles()
                {
                    jegy = jegy,
                    tantargyid = tantargy.id,
                    tanuloid = tanulo.id
                };
                string uzenet = Backend.POST(baseUrl + "/ertekelesek").Body(ujErtekeles).Send().Message;
                MessageBox.Show(uzenet);
            }
            else
            {
                MessageBox.Show("Hibás beviteli adat. Jegyet [1,5]-ban lehet jegyet adni");
            }
        }

        private void naploTanuloCbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Tanulo t = naploTanuloCbx.SelectedItem as Tanulo;
            emailLb.Content = t.email;
            nevLb.Content = t.nev;
            szuletesiIdoLb.Content = t.szuletesiido.ToString("yyyy.MM.dd.");
            telefonszamLb.Content = t.telefonszam;

            var ertekelesek= Backend.GET(baseUrl + "/ertekelesek").Send().ToList<Ertekeles>();
            var tantargyak= Backend.GET(baseUrl + "/tantargyak").Send().ToList<Tantargy>();
            var lista= ertekelesek.Where(x => x.tanuloid == t.id).Select(x => new
            {
                tantargy =tantargyak.Where(y=>y.id==x.tantargyid).First().megnevezes,
                ertekeles=x.jegy
            }
            ).Select(x=>new { megjelenit= $"tantargy: {x.tantargy}: {x.ertekeles}" }).ToList();
            jegyekLbx.ItemsSource = lista;
            jegyekLbx.DisplayMemberPath = "megjelenit";
        }
    }
}
