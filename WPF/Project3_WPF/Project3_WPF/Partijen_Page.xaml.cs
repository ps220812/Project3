using System;
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
        Project3DB Pj_DB = new Project3DB();

        public Partijen_Page()
        {
            InitializeComponent();
            FillDataTable();
        }

        public void FillDataTable()
        {
            DataTable students = Pj_DB.SelectedPartij();
            if (students != null)
            {
                dgStudents.ItemsSource = students.DefaultView;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            standputten_Page p = new standputten_Page();
        }
    }
}
