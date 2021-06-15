using System.Windows;
using System.Windows.Controls;
using Project3_WPF.classes;
using System.Data;

namespace Project3_WPF
{
    /// <summary>
    /// Interaction logic for standputten_Page.xaml
    /// </summary>
    public partial class standputten_Page : Page
    {
        Project3DB _DataBase = new Project3DB();
        public standputten_Page()
        {
            InitializeComponent();
            ShowThemas();
        }

        private void Toevoegen_Click(object sender, RoutedEventArgs e)
        {
            MainWindow win = new MainWindow();
            MessageBoxResult result = MessageBox.Show("Wilt u in partijen bekijken", "Message", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                win.HideWindow();
                win.mainFrame.Content = new Partijen_Page();
            }
            else
            {

            }


        }

        private void ShowThemas()
        {
            DataTable Themas = _DataBase.SelectedThemas();

            cmbThema.ItemsSource = Themas.DefaultView;

        }
    }
}
