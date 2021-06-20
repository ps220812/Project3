using Project3_WPF.classes;
using System.Data;
using System.Globalization;
using System.Threading;
using System.Windows;
using System.Windows.Controls;

namespace Project3_WPF
{
    /// <summary>
    /// Interaction logic for verkiezing_Page.xaml
    /// </summary>
    public partial class verkiezing_Page : Page
    {
        Project3DB _dataBase = new Project3DB();

        public verkiezing_Page()
        {
            InitializeComponent();
            FillDataTable();
            FillComboBoxVerkiezing();

            CultureInfo ci = CultureInfo.CreateSpecificCulture(CultureInfo.CurrentCulture.Name);
            ci.DateTimeFormat.ShortDatePattern = "yyyy-MM-dd";
            Thread.CurrentThread.CurrentCulture = ci;
        }

        public void FillDataTable()
        {
            DataTable verkiezing = _dataBase.SelectedVerkiezing();
            if (verkiezing != null)
            {
                dbVerkiezing.ItemsSource = verkiezing.DefaultView;
            }
        }

        public void FillComboBoxVerkiezing()
        {
            DataTable _cmbVerkiezing = _dataBase.SelectedVerkiezingSoort();
            cmbVerkiezing.ItemsSource = _cmbVerkiezing.DefaultView;
        }

        private void Verwijder_Click(object sender, RoutedEventArgs e)
        {
            DataRowView selectedRow = dbVerkiezing.SelectedItem as DataRowView;
            if (_dataBase.deleteVerkiezing(selectedRow["VerkiezingId"].ToString()))
            {
                MessageBox.Show(selectedRow["VerkiezingId"].ToString() + " Verwijderd");
                FillDataTable();
            }
            else
            {
                MessageBox.Show("Mislukt om te verwijderen");
            }
        }

        private void Wijzig_Click(object sender, RoutedEventArgs e)
        {
            Toevoegen.Content = "Weizig";
            DataRowView selectedRow = dbVerkiezing.SelectedItem as DataRowView;
            cmbVerkiezing.Text = selectedRow["Verkiezingsoort"].ToString();
            tbdate.Text = selectedRow["Datum"].ToString();
        }

        private void Toevoegen_Click(object sender, RoutedEventArgs e)
        {
            DataRowView selectedRow = dbVerkiezing.SelectedItem as DataRowView;

            if (Toevoegen.Content.ToString() == "Toevoegen")
            {
                if (_dataBase.InsertVerkiezing(cmbVerkiezing.SelectedValue.ToString(), cmbVerkiezing.Text, tbdate.Text))
                {
                    FillDataTable();
                    InitializeSetting();
                }
                else
                {
                    MessageBox.Show("Aanmaken mislukt");
                }
            }
            else if (Toevoegen.Content.ToString() == "Weizig")
            {
                if (_dataBase.updateVerkiezing(selectedRow["VerkiezingId"].ToString(), cmbVerkiezing.SelectedValue.ToString(), cmbVerkiezing.Text, tbdate.Text))
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


        private void InitializeSetting()
        {
            cmbVerkiezing.SelectedIndex = -1;
            tbdate.Text = "";
            Toevoegen.Content = "Toevoegen";
        }
    }
}
