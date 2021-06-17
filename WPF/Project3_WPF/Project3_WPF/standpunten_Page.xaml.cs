using Project3_WPF.classes;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace Project3_WPF
{
    /// <summary>
    /// Interaction logic for standputten_Page.xaml
    /// </summary>
    public partial class standpunten_Page : Page
    {
        Project3DB _DataBase = new Project3DB();
        public standpunten_Page()
        {
            InitializeComponent();
            ShowStandpunten();
            FillDataTable();
        }

        public void FillDataTable()
        {
            DataTable standPunten = _DataBase.SelectedStandpunten();
            if (standPunten != null)
            {
                dgStandpunten.ItemsSource = standPunten.DefaultView;
            }
        }

        private void Toevoegen_Click(object sender, RoutedEventArgs e)
        {
            DataRowView standpuntView = dgStandpunten.SelectedItem as DataRowView;

            if (Toevoegen.Content.ToString() == "Toevoegen")
            {
                if (_DataBase.InsertStandpunt(cmbPartij.SelectedValue.ToString(), cmbPartij.Text.ToString(), cmbThema.SelectedValue.ToString(), cmbThema.Text.ToString(), tbStandpunt.Text.ToString()))
                {
                    MessageBox.Show("gelukt");
                    FillDataTable();
                    tbStandpunt.Text = "";
                }
                else
                {
                    MessageBox.Show("Mislukt");
                    FillDataTable();
                }

            }
            else if (Toevoegen.Content.ToString() == "Weizig")
            {
                if (_DataBase.UpdateStandpunt(standpuntView["StandpuntId"].ToString(),cmbPartij.SelectedValue.ToString(),cmbPartij.Text,cmbThema.SelectedValue.ToString(),cmbThema.Text,tbStandpunt.Text))
                {
                    MessageBox.Show("gelukt");
                    FillDataTable();
                    tbStandpunt.Text = "";
                    cmbPartij.SelectedIndex = -1;
                    cmbThema.SelectedIndex = -1;
                }
                else
                {
                    MessageBox.Show("Mislukt");
                }
            }


        }

        private void ShowStandpunten()
        {
            DataTable Themas = _DataBase.SelectedThemas();
            DataTable Partij = _DataBase.SelectedPartij();

            cmbThema.ItemsSource = Themas.DefaultView;
            cmbPartij.ItemsSource = Partij.DefaultView;
        }

        private void Wijzig_Click(object sender, RoutedEventArgs e)
        {
            DataRowView standpuntView = dgStandpunten.SelectedItem as DataRowView;
            cmbPartij.Text = standpuntView["PartijName"].ToString();
            cmbThema.Text = standpuntView["Thema"].ToString();
            tbStandpunt.Text = standpuntView["Standpunt"].ToString();
            Toevoegen.Content = "Weizig";
        }

        private void Verwijder_Click(object sender, RoutedEventArgs e)
        {
            DataRowView standpuntView = dgStandpunten.SelectedItem as DataRowView;
            if (_DataBase.DeleteStandpunt(standpuntView["StandpuntId"].ToString()))
            {
                MessageBox.Show("Gelukt");
                FillDataTable();
            }
            else
            {
                MessageBox.Show("Mislukt");
            }
        }
    }
}
