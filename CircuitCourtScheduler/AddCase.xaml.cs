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
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace CircuitCourtScheduler
{
    /// <summary>
    /// Interaction logic for Add_Case.xaml
    /// </summary>
    public partial class Add_Case : Window
    {
        public Add_Case()
        {
            InitializeComponent();
        }

        private void buttonAddCase_Click(object sender, RoutedEventArgs e)
        {
            try {
                SqlConnection thisConnection = new SqlConnection(@"Server=(local);Database=circuitCourtPD;Trusted_Connection=Yes;");
                thisConnection.Open();
                string qry = "INSERT into StaffTable [FIRSTNAME,LASTNAME,EMAIL,DATEADDED] values [Johnny,Cash,Jcash@Jmoney.com,@s]";
                SqlCommand cmd = new SqlCommand(qry);
                cmd.Parameters.AddWithValue("@s",DateTime.Today);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                thisConnection.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            


            
        }
    }
}
