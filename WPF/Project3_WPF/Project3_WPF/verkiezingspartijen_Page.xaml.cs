using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Data;
using Project3_WPF.classes;
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

        }

        private void Verwijder_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Toevoegen_Click(object sender, RoutedEventArgs e)
        {
            DataRowView selectedRow = DbVerkiezingPartijen.SelectedItem as DataRowView;

            if (Toevoegen.Content.ToString() == "Toevoegen")
            {
                if (_DataBase.InsertVerkiezingsPartijen(cmbPartij.SelectedValue.ToString(),cmbVerkiezing.SelectedValue.ToString()))
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
                /*if ()
                {
                    FillDataTable();
                    Toevoegen.Content = "Toevoegen";
                }
                else
                {
                    MessageBox.Show("Aanmaken mislukt");
                }*/
            }
        }

        private void FillComboBoxen()
        {
            DataTable Partij = _DataBase.SelectedPartij();
            cmbPartij.ItemsSource = Partij.DefaultView;

        }
    }
}
