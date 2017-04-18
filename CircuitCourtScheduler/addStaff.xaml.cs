using DatabaseQueries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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

namespace CircuitCourtScheduler
{
    /// <summary>
    /// Interaction logic for addStaff.xaml
    /// </summary>
    public partial class addStaff : Window
    {
        public addStaff()
        {
            InitializeComponent();
        }

        private void buttonSubmit_Click(object sender, RoutedEventArgs e)
        {
            Queries query = new Queries(new System.Data.SqlClient.SqlConnection("Data Source=GABE-PC\\SQLEXPRESS;Initial Catalog=PublicDefenders;Integrated Security=True"));
            query.SetSqlCommand("INSERT INTO StaffTable(FIRSTNAME,LASTNAME,EMAIL,DATEADDED,PASSWORD,ACTIVATED) VALUES(@FirstName,@LastName,@Email,@DateAdded,@Password,@Activated)");
            query.AddQueryParameters("@FirstName", textBoxFirstName.Text);
            query.AddQueryParameters("@LastName", textBoxLastName.Text);
            query.AddQueryParameters("@Email", textBoxEmail.Text);
            query.AddQueryParameters("@DateAdded", DateTime.Today);
            query.AddQueryParameters("@Password", encryptPassword(textBoxPassword.Text));
            query.AddQueryParameters("@Activated", true);
            query.Connect();
            query.ExecuteNonQuery();
            query.Disconnect();

            this.Close();
        }

        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private string encryptPassword(string input)
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
    }
}
