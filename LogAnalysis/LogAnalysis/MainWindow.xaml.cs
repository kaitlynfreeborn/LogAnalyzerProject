using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
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
using Excel = Microsoft.Office.Interop.Excel;
using Window = System.Windows.Window;


namespace LogAnalysis
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    static class MyVariables
    {
        public static string filePath;
    }

    public partial class MainWindow : Window
    {
       
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(login_Load);
        }

        //Opens login window upon start of program
        private void login_Load(object sender, EventArgs e)
        {
            login newWindow = new login();
            newWindow.Show();
        }

        //Select button: opens file explorer for user. Allows them to choose and then displays file name in text box. 
        private void btnSelect_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            var fileName = dlg.ShowDialog();

            txtFile.Text = dlg.FileName;

            MyVariables.filePath = txtFile.Text;
         }

        //Working on this part, supposed to connect to database
        private void btnAnalyze_Click(object sender, RoutedEventArgs e)
        {
            Data newWindow = new Data();
            newWindow.Show();



            //Excel.Application xlApp;
            //Excel.Workbook xlWorkBook;
            //Excel.Worksheet xlWorkSheet;
            //Excel.Range range;

            //string str;
            //int rCnt;
            //int cCnt;
            //int rw = 0;
            //int cl = 0;

            //xlApp = new Excel.Application();
            //xlWorkBook = xlApp.Workbooks.Open($@"{txtFile.Text}", 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            //xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            //range = xlWorkSheet.UsedRange;
            //rw = range.Rows.Count;
            //cl = range.Columns.Count;


            //for (rCnt = 1; rCnt <= rw; rCnt++)
            //{
            //    for (cCnt = 1; cCnt <= cl; cCnt++)
            //    {
            //        str =range.Cells.ToString();
                    
            //        //str = (string)(range.Cells[rCnt, cCnt] as Excel.Range).Value2;
            //        MessageBox.Show(str);
            //    }
            //}

            //xlWorkBook.Close(true, null, null);
            //xlApp.Quit();

            //Marshal.ReleaseComObject(xlWorkSheet);
            //Marshal.ReleaseComObject(xlWorkBook);
            //Marshal.ReleaseComObject(xlApp);



            //string con = $@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={txtFile.Text};" + @"Extended Properties=\'Excel 8.0;HDR=Yes;\'";
            //using (OleDbConnection connection = new OleDbConnection(con))
            //{
            //    connection.Open();
            //    OleDbCommand command = new OleDbCommand("select * from [test$] ", connection);
            //    using (OleDbDataReader dr = command.ExecuteReader())
            //    {
            //        while (dr.Read())
            //        {
            //            var row1Col0 = dr[0];
            //            Console.WriteLine(row1Col0);
            //        }
            //    }
            //}

        }
            private void cmb1_Checked(object sender, RoutedEventArgs e)
        {

        }


        private void btn_quick_Click(object sender, RoutedEventArgs e)
        {
            // Iterate through the current set of event log files,
            // displaying the property settings for each file.

            EventLog[] eventLogs = EventLog.GetEventLogs();
            for (int i = 0; i < eventLogs.Length; i++)
            {
                Int64 sizeKB = 0;

                Console.WriteLine();
                Console.WriteLine("{0}:", eventLogs[i].LogDisplayName);
                Console.WriteLine("  Log name = \t\t {0}", eventLogs[i].Log);

                Console.WriteLine("  Number of event log entries = {0}", eventLogs[i].Entries.Count.ToString());

                // Determine if there is an event log file for this event log.
                RegistryKey regEventLog = Registry.LocalMachine.OpenSubKey("System\\CurrentControlSet\\Services\\EventLog\\" + eventLogs[i].Log);
                if (regEventLog != null)
                {
                    Object temp = regEventLog.GetValue("File");
                    if (temp != null)
                    {
                        Console.WriteLine("  Log file path = \t {0}", temp.ToString());
                        FileInfo file = new FileInfo(temp.ToString());

                        // Get the current size of the event log file.
                        if (file.Exists)
                        {
                            sizeKB = file.Length / 1024;
                            if ((file.Length % 1024) != 0)
                            {
                                sizeKB++;
                            }
                            Console.WriteLine("  Current size = \t {0} kilobytes", sizeKB.ToString());
                        }
                    }
                    else
                    {
                        Console.WriteLine("  Log file path = \t <not set>");
                    }
                }

                // Display the maximum size and overflow settings.

                sizeKB = eventLogs[i].MaximumKilobytes;
                Console.WriteLine("  Maximum size = \t {0} kilobytes", sizeKB.ToString());
                Console.WriteLine("  Overflow setting = \t {0}", eventLogs[i].OverflowAction.ToString());

                switch (eventLogs[i].OverflowAction)
                {
                    case OverflowAction.OverwriteOlder:
                        Console.WriteLine("\t Entries are retained a minimum of {0} days.",
                            eventLogs[i].MinimumRetentionDays);
                        break;
                    case OverflowAction.DoNotOverwrite:
                        Console.WriteLine("\t Older entries are not overwritten.");
                        break;
                    case OverflowAction.OverwriteAsNeeded:
                        Console.WriteLine("\t If number of entries equals max size limit, a new event log entry overwrites the oldest entry.");
                        break;
                    default:
                        break;
                }
            }
        }
    }
}

