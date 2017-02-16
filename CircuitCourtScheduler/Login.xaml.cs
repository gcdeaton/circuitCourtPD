using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CircuitCourtScheduler
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        protected bool existUser()
        {
            SqlConnection conn = new SqlConnection("Data Source=(localdb)\\ProjectsV12;Initial Catalog=circuitCourtPD;Integrated Security=True;Pooling=False;Connect Timeout=30");
            conn.Open();
            string checkUser = "select * from LoginTable where Email =@email";
            SqlCommand comd = new SqlCommand(checkUser, conn);
            comd.Parameters.AddWithValue("@email",textBoxEmail.Text);
            SqlDataReader dr = comd.ExecuteReader();
            dr.Read();
            
                if (dr["Password"].ToString() == encryptString(textBoxPassword.Text))
                {
                    dr.Close();
                    conn.Close();
                    return true;
                }
            
            dr.Close();
            conn.Close();
            return false;

        }

 
        public string encryptString(string input)
        {

            MD5 md5 = new MD5CryptoServiceProvider();

            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(input));

            byte[] result = md5.Hash;

            StringBuilder strBuilder = new StringBuilder();

            for (int i = 0; i < result.Length; i++)
            {

                strBuilder.Append(result[i].ToString("x2"));

            }



            return strBuilder.ToString();

        }

        private void ButtonLogin_Click(object sender, RoutedEventArgs e)
        {
            if (this.existUser())
            {
                Application.Current.Resources["user"] = textBoxEmail.Text;
                MainWindow wind = new MainWindow();
                wind.Show();
                this.Close();
            }
            else
            {
                LabelMessage.IsEnabled = true;
                LabelMessage.Visibility = Visibility.Hidden;
                LabelMessage.Content = "Your Login Info is Incorrect";
            }
        }
    }
}
