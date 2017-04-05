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
using System.DirectoryServices.ActiveDirectory;
using System.Data.SqlClient;


namespace Helpdesk
{
    /// <summary>
    /// Logika interakcji dla klasy Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
            mail email = new mail("rafal.szmajser", "PASSWORD");
            //email.SendMail("rafal.szmajser", "Arcom!@#$", "przykladowy tekst", "rafal.szmajser@arcom.net.pl");

            SqlConnection connection = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename =" + @"C:\Users\Rafal.Szmajser\Documents\Visual Studio 2017\Projects\Helpdesk\Helpdesk\helpdeskDB.mdf" + "; Integrated Security = True");
            connection.Open();

            SqlCommand cmd = new SqlCommand("INSERT INTO Users (Username) VALUES (@Username)");
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Connection = connection;
            cmd.Parameters.AddWithValue("@Username", "rafal.szmajser");
            cmd.ExecuteNonQuery();
            connection.Close();

        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = string.Empty;
            tb.GotFocus -= TextBox_GotFocus;
        }

        private void textbox_pass_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = string.Empty;
            tb.GotFocus -= textbox_pass_GotFocus;
            tb.Visibility = Visibility.Collapsed;
            textbox_pass.Visibility = Visibility.Visible;
            textbox_pass.Focus();
        }

        void EnterPressed(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                Button_Click(sender, e);
                e.Handled = true;
            }
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
                ADLogin UserVerify = new ADLogin(textbox_user.Text, textbox_pass.Password);
            if(UserVerify.UserVerification())
            {
                MainWindow window = new MainWindow(textbox_user.Text);
                window.Show();
                this.Close();
            }
            else
            {                
               MessageBox.Show("BŁĘDNY LOGIN LUB HASŁO");}
            }
    }
}
