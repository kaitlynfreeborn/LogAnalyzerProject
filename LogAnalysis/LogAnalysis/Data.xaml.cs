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
using System.Windows.Shapes;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Threading;
using Microsoft.Win32;
using System.Collections;
using System.Data.OleDb;
using System.Data;

namespace LogAnalysis
{
    /// <summary>
    /// Interaction logic for Data.xaml
    /// </summary>
    public partial class Data : Window
    {
        public Data()
        {
            // COMMENTED OUT SO THAT CODE WILL COMPILE, WORKING ON THIS SECTION


            //InitializeComponent();
            //string filePath = string.Empty;
            //string fileExt = string.Empty;
            //OpenFileDialog file = new OpenFileDialog(); //open dialog to choose file 
            //if (file.ShowDialog() = System.Windows.Forms.DialogResult.OK) //if there is a file choosen by the user  
            //{
            //    filePath = file.FileName; //get the path of the file  
            //    fileExt = System.IO.Path.GetExtension(filePath); //get the file extension  
            //    if (fileExt.CompareTo(".xls") == 0 || fileExt.CompareTo(".xlsx") == 0)
            //    {
            //        try
            //        {
            //            DataTable dtExcel = new DataTable();
            //            dtExcel = ReadExcel(filePath, fileExt); //read excel file  
            //            dataGridView1.Visible = true;
            //            dataGridView1.DataSource = dtExcel;
            //        }
            //        catch (Exception ex)
            //        {
            //            MessageBox.Show(ex.Message.ToString());
            //        }
            //    }
            //    else
            //    {
            //        MessageBox.Show("Please choose .xls or .xlsx file only.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error); //custom messageBox to show error  
            //    }

            }
        }

        //public DataTable ReadExcel(string fileName, string fileExt)
        //{
        //    string conn = string.Empty;
            
        //    DataTable dtexcel = new DataTable();
        //    if (fileExt.CompareTo(".xls") == 0)
        //        conn = @"provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fileName + ";Extended Properties='Excel 8.0;HRD=Yes;IMEX=1';"; //for below excel 2007  
        //    else
        //        conn = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fileName + ";Extended Properties='Excel 12.0;HDR=NO';"; //for above excel 2007  
        //    using (OleDbConnection con = new OleDbConnection(conn))
        //    {
        //        try
        //        {
        //            OleDbDataAdapter oleAdpt = new OleDbDataAdapter("select * from [sheet1$]", con); //here we read data from sheet1  
        //            oleAdpt.Fill(dtexcel); //fill excel data into dataTable  
        //        }
        //        catch { }
        //    }
        //    return dtexcel;
        //}
    }
//}

