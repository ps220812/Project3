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
    /// Interaction logic for Themas.xaml
    /// </summary>
    public partial class Themas_Page : Page
    {
        Project3DB _DataBase = new Project3DB();
        public Themas_Page()
        {
            InitializeComponent();
            FillDataTable();
        }
        public void FillDataTable()
        {
            DataTable themas = _DataBase.SelectedThemas();
            if (themas != null)
            {
                dgThemas.ItemsSource = themas.DefaultView;
            }
        }
        private void Toevoegen_Click(object sender, RoutedEventArgs e)
        {
            Project3DB thema = new Project3DB();
            DataRowView selectedRow = dgThemas.SelectedItem as DataRowView;
            if (Toevoegen.Content.ToString() == "Toevoegen")
            {
                if (thema.insertThema(tbThema.Text.ToString()))
                {
                    FillDataTable();
                }
                else
                {
                    MessageBox.Show("Aanmaken mislukt");
                }
            }
            else if(Toevoegen.Content.ToString() == "Wijzigen")
            {
                if (thema.updateThema(tbThema.Text.ToString(), selectedRow["ThemaId"].ToString()))
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
            DataRowView selectedRow = dgThemas.SelectedItem as DataRowView;

            if (_DataBase.deleteThema(selectedRow["ThemaId"].ToString()))
            {
                MessageBox.Show($"Thema {selectedRow["ThemaId"]} verwijderd");
            }
            else
            {
                MessageBox.Show($"Verwijderen van {selectedRow["Themaid"]} mislukt");
            }

            FillDataTable();
        }

        private void Wijzig_Click(object sender, RoutedEventArgs e)
        {
            Toevoegen.Content = "Wijzigen";
        }

        private void tbThema_GotFocus(object sender, RoutedEventArgs e)
        {
            tbThema.Text = "";
        }
    }
}
