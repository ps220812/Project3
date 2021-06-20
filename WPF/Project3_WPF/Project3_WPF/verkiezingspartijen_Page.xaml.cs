using Project3_WPF.classes;
using System.Data;
using System.Windows;
using System.Windows.Controls;
namespace Project3_WPF
{
    /// <summary>
    /// Interaction logic for verkiezingspartijen.xaml
    /// </summary>
    public partial class verkiezingspartijen : Page
    {
        Project3DB _DataBase = new Project3DB();

        public verkiezingspartijen()
        {
            InitializeComponent();
            FillDataTable();
            FillComboBoxen();
        }

        private void FillDataTable()
        {
            DataTable verkiezingsPartijen = _DataBase.SelectedVerkiezingsPartijen();
            if (verkiezingsPartijen != null)
            {
                DbVerkiezingPartijen.ItemsSource = verkiezingsPartijen.DefaultView;
            }
        }

        private void Wijzig_Click(object sender, RoutedEventArgs e)
        {
            DataRowView selectedRow = DbVerkiezingPartijen.SelectedItem as DataRowView;
            Toevoegen.Content = "Weizigen";
            cmbPartij.SelectedValue = selectedRow["PartijId"];
            cmbVerkiezing.SelectedValue = selectedRow["VerkiezingId"];
        }

        private void Verwijder_Click(object sender, RoutedEventArgs e)
        {
            DataRowView selectedRow = DbVerkiezingPartijen.SelectedItem as DataRowView;
            if (_DataBase.DeleteVerkiezingsPartijen(selectedRow["Id"].ToString()))
            {
                MessageBox.Show("Verwijderd");
                FillDataTable();
                InitializeSetting();
            }
            else
            {
                MessageBox.Show("Mislukt");
            }
        }

        private void Toevoegen_Click(object sender, RoutedEventArgs e)
        {
            DataRowView selectedRow = DbVerkiezingPartijen.SelectedItem as DataRowView;

            if (Toevoegen.Content.ToString() == "Toevoegen")
            {
                if (_DataBase.InsertVerkiezingsPartijen(cmbPartij.SelectedValue.ToString(), cmbVerkiezing.SelectedValue.ToString()))
                {
                    FillDataTable();
                    InitializeSetting();
                }
                else
                {
                    MessageBox.Show("Aanmaken mislukt");
                }
            }
            else if (Toevoegen.Content.ToString() == "Weizigen")
            {
                if (_DataBase.UpdateVerkiezinsPartijen(selectedRow["Id"].ToString(), cmbPartij.SelectedValue.ToString(), cmbVerkiezing.SelectedValue.ToString()))
                {
                    FillDataTable();
                    InitializeSetting();
                }
                else
                {
                    MessageBox.Show("Aanmaken mislukt");
                }
            }
        }

        private void FillComboBoxen()
        {
            DataTable Partij = _DataBase.SelectedPartij();
            DataTable Verkiezing = _DataBase.SelectedVerkiezing();
            cmbPartij.ItemsSource = Partij.DefaultView;
            cmbVerkiezing.ItemsSource = Verkiezing.DefaultView;
        }

        private void InitializeSetting()
        {
            cmbVerkiezing.SelectedIndex = -1;
            cmbPartij.SelectedIndex = -1;
            Toevoegen.Content = "Toevoegen";
        }
    }
}
