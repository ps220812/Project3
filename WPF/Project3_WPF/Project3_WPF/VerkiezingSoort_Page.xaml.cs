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
    /// Interaction logic for VerkiezingsSoort_Page.xaml
    /// </summary>
    public partial class VerkiezingSoort_Page : Page
    {
        Project3DB _DataBase = new Project3DB();
        public VerkiezingSoort_Page()
        {
            InitializeComponent();
            FillDataTable();
        }
        public void FillDataTable()
        {
            DataTable verkiezingsoort = _DataBase.SelectedVerkiezingSoort();
            if (verkiezingsoort != null)
            {
                dgVerkiezingSoort.ItemsSource = verkiezingsoort.DefaultView;
            }
        }
        private void Toevoegen_Click(object sender, RoutedEventArgs e)
        {
            Project3DB verkiezingsoort = new Project3DB();
            DataRowView selectedRow = dgVerkiezingSoort.SelectedItem as DataRowView;

            if (Toevoegen.Content.ToString() == "Toevoegen")
            {
                if (verkiezingsoort.insertVerkiezingsoort(tbVerkiezingSoort.Text.ToString()))
                {
                    FillDataTable();
                }
                else
                {
                    MessageBox.Show("Aanmaken mislukt");
                }
            }
            else if (Toevoegen.Content.ToString() == "Wijzigen")
            {
                if (verkiezingsoort.updateVerkiezingsoort(tbVerkiezingSoort.Text.ToString(), selectedRow["SoortId"].ToString()))
                {
                    FillDataTable();
                    Toevoegen.Content = "Toevoegen";
                }
                else
                {
                    MessageBox.Show("Aanmaken mislukt");
                }
            }
        }
        private void Verwijder_Click(object sender, RoutedEventArgs e)
        {
            DataRowView selectedRow = dgVerkiezingSoort.SelectedItem as DataRowView;

            if (_DataBase.deleteVerkiezingsoort(selectedRow["SoortId"].ToString()))
            {
                MessageBox.Show($"Verkiezingsoort {selectedRow["SoortId"]} verwijderd");
            }
            else
            {
                MessageBox.Show($"Verwijderen van {selectedRow["SoortId"]} mislukt");
            }

            FillDataTable();
        }

        private void Wijzig_Click(object sender, RoutedEventArgs e)
        {
            Toevoegen.Content = "Wijzigen";
        }
        private void tbVerkiezingSoort_GotFocus(object sender, RoutedEventArgs e)
        {
            tbVerkiezingSoort.Text = "";
        }
    }
}
