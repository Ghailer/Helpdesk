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
using System.Data.SqlClient;
using System.Threading;
using System.Net.Sockets;

namespace Helpdesk
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string username;
        public MainWindow(string user)
        {
            InitializeComponent();
            this.username = user;

            /*
            SqlConnection connection = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename =" + @"C:\Users\Rafal.Szmajser\Documents\Visual Studio 2017\Projects\Helpdesk\Helpdesk\helpdeskDB.mdf" + "; Integrated Security = True");
            connection.Open();

            SqlCommand cmd = new SqlCommand("INSERT INTO Users (Username) VALUES (@Username)");
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Connection = connection;
            cmd.Parameters.AddWithValue("@Username", "rafal.szmajser");
            connection.Open();
            cmd.ExecuteNonQuery();*/
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            /*
            e.Cancel = true;
            this.Hide() 
            */
        }
    }
}
