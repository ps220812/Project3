﻿using System;
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
using System.Data;
using Project3_WPF.classes;


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
                dgStudents.ItemsSource = Partijen.DefaultView;
            }
        }

        private void Btn_ToevoegenPartij_Click(object sender, RoutedEventArgs e)
        {
            Project3DB partij = new Project3DB();
            if (partij.InsertPartij(naam.Text.ToString(),adress.Text.ToString(), postcode.Text.ToString(), gemeente.Text.ToString(), email.Text.ToString(), telefoonnummer.Text.ToString()))
            {
                FillDataTable();
            }
            else
            {
                MessageBox.Show("Aanmaken mislukt");
            }
        }
    }
}
