using Project3_WPF.classes;
using System.Data;
using System.Windows;
using System.Windows.Controls;


namespace Project3_WPF
{
    /// <summary>
    /// Interaction logic for Partijen_Page.xaml
    /// </summary>
    public partial class Partijen_Page : Page
    {
        Project3DB _Database = new Project3DB();

        public Partijen_Page()
        {
            InitializeComponent();
            FillDataTable();
        }

        public void FillDataTable()
        {
            DataTable Partijen = _Database.SelectedPartij();
            if (Partijen != null)
            {
                dbTabelPartij.ItemsSource = Partijen.DefaultView;
            }
        }

        private void Btn_ToevoegenPartij_Click(object sender, RoutedEventArgs e)
        {
            Project3DB partij = new Project3DB();
            DataRowView partijView = dbTabelPartij.SelectedItem as DataRowView;

            if (Btn_ToevoegenPartij.Content.ToString() == "Toevoegen")
            {
                if (partij.InsertPartij(naam.Text.ToString(), adress.Text.ToString(), postcode.Text.ToString(), gemeente.Text.ToString(), email.Text.ToString(), telefoonnummer.Text.ToString()))
                {
                    FillDataTable();
                }
                else
                {
                    MessageBox.Show("Aanmaken mislukt");
                }
                ClearTextBox();
            }
            if (Btn_ToevoegenPartij.Content.ToString() == "Weizig")
            {
                if (partij.UpdatePartij(partijView["PartijId"].ToString(), naam.Text.ToString(), adress.Text.ToString(), postcode.Text.ToString(), gemeente.Text.ToString(), email.Text.ToString(), telefoonnummer.Text.ToString()))
                {
                    FillDataTable();
                }
                else
                {
                    MessageBox.Show("Aanmaken mislukt");
                }
                Btn_ToevoegenPartij.Content = "Toevoegen";
                ClearTextBox();
            }


        }

        private void Wijzig_Click(object sender, RoutedEventArgs e)
        {
            DataRowView partijView = dbTabelPartij.SelectedItem as DataRowView;
            naam.Text = partijView["PartijName"].ToString();
            adress.Text = partijView["Adres"].ToString();
            postcode.Text = partijView["Postcode"].ToString();
            gemeente.Text = partijView["Gemeente"].ToString();
            email.Text = partijView["EmailAdres"].ToString();
            telefoonnummer.Text = partijView["Telefoonnummer"].ToString();

            Btn_ToevoegenPartij.Content = "Weizig";
        }

        private void ClearTextBox()
        {
            naam.Text = "";
            adress.Text = "";
            postcode.Text = "";
            gemeente.Text = "";
            email.Text = "";
            telefoonnummer.Text = "";
        }

        private void Verwijder_Click(object sender, RoutedEventArgs e)
        {
            DataRowView selectedPartij = dbTabelPartij.SelectedItem as DataRowView;
            if (_Database.deletePartij(selectedPartij["PartijId"].ToString()))
            {
                MessageBox.Show($"Partij {selectedPartij["PartijName"]} verwijderd");
                FillDataTable();
            }
            else
            {
                MessageBox.Show($"Partij {selectedPartij["PartijName"]} verwijderd mislukt");
            }
        }
    }
}
