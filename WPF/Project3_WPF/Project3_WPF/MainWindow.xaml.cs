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

namespace Project3_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            mainFrame.Content = new Partijen_Page();
            Title.Content = "Partijen";
        }

        private void Btn_partijen_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Content = new Partijen_Page();
            Title.Content = "Partijen";
        }

        private void Btn_standpunt_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Content = new standpunten_Page();
            Title.Content = "Standpunten";
        }

        private void Btn_themas_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Content = new Themas_Page();
            Title.Content = "thema's";
        }
        private void Btn_verkiezingsoort_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Content = new VerkiezingSoort_Page();
            Title.Content = "verkiezingsoorten";
        }
        private void Btn_verkiezing_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Content = new verkiezing_Page();
            Title.Content = "verkiezing";
        }
        public void HideWindow()
        {
            this.Close();
        }

        private void Btn_verkiezingpartijen_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Content = new verkiezingspartijen( );
        }
    } 
}
