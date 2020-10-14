using System;
using System.Collections.Generic;
using System.Data.OleDb;
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
            this.Loaded += new RoutedEventHandler(login_Load);
        }
        private void login_Load(object sender, EventArgs e)
        {   
            login newWindow = new login();
            newWindow.Show();
        }
        private void btnSelect_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            var fileName = dlg.ShowDialog();

            txtFile.Text = dlg.FileName;
        }
        private void btnAnalyze_Click(object sender, RoutedEventArgs e)
        {
            Data newWindow = new Data();
            newWindow.Show();

            string con = $@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={txtFile.Text};" + @"Extended Properties='Excel 8.0;HDR=Yes;'";
            using (OleDbConnection connection = new OleDbConnection(con))
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand("select * from [test$] ", connection);
                using (OleDbDataReader dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        var row1Col0 = dr[0];
                        Console.WriteLine(row1Col0);
                    }
                }
            }
        }

        private void cmb1_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}

