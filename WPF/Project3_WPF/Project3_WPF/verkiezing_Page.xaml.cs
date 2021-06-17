using Project3_WPF.classes;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace Project3_WPF
{
    /// <summary>
    /// Interaction logic for verkiezing_Page.xaml
    /// </summary>
    public partial class verkiezing_Page : Page
    {
        Project3DB _DataBase = new Project3DB();
        public verkiezing_Page()
        {
            InitializeComponent();
            FillDataTable();
            ShowVerkiezing();
        }
        public void FillDataTable()
        {
            DataTable verkiezing = _DataBase.SelectedVerkiezing();
            if (verkiezing != null)
            {
                dgVerkiezing.ItemsSource = verkiezing.DefaultView;
            }
        }
        private void Toevoegen_Click(object sender, RoutedEventArgs e)
        {
            DataRowView selectedRow = dgVerkiezing.SelectedItem as DataRowView;

            if (Toevoegen.Content.ToString() == "Toevoegen")
            {
                if (_DataBase.InsertVerkiezing(cbVerkiezing.SelectedValue.ToString(), cbVerkiezing.Text.ToString(), tbDatum.Text.ToString()))
                {
                    FillDataTable();
                    tbDatum.Text = "";
                    cbVerkiezing.SelectedIndex = -1;
                }
                else
                {
                    MessageBox.Show("Aanmaken mislukt");
                }
            }
            else if (Toevoegen.Content.ToString() == "Wijzigen")
            {
                if (_DataBase.updateVerkiezing(selectedRow["VerkiezingId"].ToString(), selectedRow["SoortId"].ToString(), cbVerkiezing.SelectedValue.ToString(),tbDatum.Text.ToString()))
                {
                    FillDataTable();
                    tbDatum.Text = "";
                    cbVerkiezing.SelectedIndex = -1;
                    Toevoegen.Content = "Toevoegen";
                }
                else
                {
                    MessageBox.Show("Wijzigen mislukt");
                }
            }
        }
        private void Verwijder_Click(object sender, RoutedEventArgs e)
        {
            DataRowView selectedRow = dgVerkiezing.SelectedItem as DataRowView;

            if (_DataBase.deleteVerkiezing(selectedRow["VerkiezingId"].ToString()))
            {
                MessageBox.Show($"Verkiezing {selectedRow["VerkiezingId"]} verwijderd");
            }
            else
            {
                MessageBox.Show($"Verwijderen van {selectedRow["VerkiezingId"]} mislukt");
            }

            FillDataTable();
        }

        private void Wijzig_Click(object sender, RoutedEventArgs e)
        {
            DataRowView verkiezingView = dgVerkiezing.SelectedItem as DataRowView;
            cbVerkiezing.Text = verkiezingView["Verkiezingsoort"].ToString();
            tbDatum.Text = verkiezingView["Datum"].ToString();
            Toevoegen.Content = "Wijzigen";
        }
        private void ShowVerkiezing()
        {
            DataTable verkiezing = _DataBase.SelectedVerkiezingSoort();
            cbVerkiezing.ItemsSource = verkiezing.DefaultView;
        }
        private void tbDatum_GotFocus(object sender, RoutedEventArgs e)
        {
            tbDatum.Text = "";
        }
    }
}
