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

namespace LogAnalysis
{
    /// <summary>
    /// Interaction logic for login.xaml
    /// </summary>
    public partial class login : Window
    {
        public login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string userName, password;
            userName = txtUsername.Text;
            password = txtPassword.Text;
            //var form2 = new CustomerInfo();

            if (userName == "admin" && password == "admin")
            {
                MessageBox.Show("Welcome " + userName);
                //ActiveForm.Hide();
                //form2.Show();
                this.Hide();
                this.Close();
                //th = new Thread(OpenNewForm);
                //th.SetApartmentState(ApartmentState.STA);
                //th.Start();
            }
            else
            {
                MessageBox.Show("Username/Password does not exist.");
            }

        }

        //private void OpenNewForm()
        //{
        //    Application.Run(new CustomerInfo());
        //    //throw new NotImplementedException();
        //}
    }
    }

