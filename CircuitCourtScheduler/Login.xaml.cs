using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Windows;


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
            SqlConnection conn = new SqlConnection("Data Source=GABE-PC\\SQLEXPRESS;Initial Catalog=PublicDefenders;Integrated Security=True");
            conn.Open();
            string checkUser = "SELECT FIRSTNAME,LASTNAME,EMAIL,PASSWORD FROM StaffTable WHERE Email =@email";
            SqlCommand comd = new SqlCommand(checkUser, conn);
            comd.Parameters.AddWithValue("@email",textBoxEmail.Text);
            SqlDataReader dr = comd.ExecuteReader();
            dr.Read();

            if(dr.HasRows) {

                if (dr["PASSWORD"].ToString().Equals(encryptString(textBoxPassword.Password)))
                {
                    dr.Close();
                    conn.Close();
                    return true;
                }
            }

            dr.Close();
            conn.Close();
            return false;

        }

 
        public string encryptString(string input)
        {

            SHA256CryptoServiceProvider SHA256 = new SHA256CryptoServiceProvider();
            SHA256.ComputeHash(ASCIIEncoding.ASCII.GetBytes(input));
            byte[] result = SHA256.Hash;
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
                LoginClass.email = textBoxEmail.Text;
                MainWindow wind = new MainWindow();
                wind.Show();
                this.Close();
            }
            else
            {
                labelMessage.IsEnabled = true;
                labelMessage.Content = "Your Login Info is Incorrect";
            }
        }
    }
}
