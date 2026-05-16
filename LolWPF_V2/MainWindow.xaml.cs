using LolCLI_V2;
using System.IO;
using System.Reflection.Emit;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LolWPF_V2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Program.Beolvasas();
            dtgAdatok.ItemsSource = Program.hos;
        }
        private void dtgAdatok_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dtgAdatok.SelectedIndex == -1)
            {
                btnMentes.IsEnabled = false;
            }
            else
            {
                btnMentes.IsEnabled = true;
            }

        }
        private void btnMentes_Click(object sender, RoutedEventArgs e)
        {
            string keresettNev = txtKereses.Text.Trim();
            string fajlNev = string.IsNullOrWhiteSpace(keresettNev) ? "teljes.txt" : keresettNev;

            try
            {
                using StreamWriter sw = new StreamWriter(fajlNev);

                foreach (dynamic item in dtgAdatok.ItemsSource)
                {
                    int hp = item.HP();
                    sw.WriteLine($"{item.Name} ==> {(hp > 0 ? "+" : "")}{hp}");
                }

                MessageBox.Show("Sikeres mentés");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnKereses_Click(object sender, RoutedEventArgs e)
        {
            string keresettNev = txtKereses.Text.Trim();

            if (string.IsNullOrWhiteSpace(keresettNev))
            {
                dtgAdatok.ItemsSource = Program.hos;
            }
            else
            {
                dtgAdatok.ItemsSource = Program.hos
                    .Where(hos => hos.Name.Contains(keresettNev, StringComparison.CurrentCultureIgnoreCase))
                    .ToList();
            }

            txtKereses.Clear();
        }
    }
}