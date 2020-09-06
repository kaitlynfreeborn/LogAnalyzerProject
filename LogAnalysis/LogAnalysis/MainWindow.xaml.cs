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

namespace LogAnalysis
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(MainWindow_Load);

        }
        private void MainWindow_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Welcome user!");

        }
        private void MainWindow_Load (object sender, EventArgs e)
        { 
            smb_select.Items.Add("hey");
        }
      
        private void Button_Click(object sender, RoutedEventArgs e)
        {
           login newWindow = new login();
           newWindow.Show();
        }

        private void ComboBoxItem_Selected(object sender, RoutedEventArgs e)
        {

        }
    }
}
