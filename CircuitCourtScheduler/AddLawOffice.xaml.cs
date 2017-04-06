using DatabaseQueries;
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

namespace CircuitCourtScheduler
{
    /// <summary>
    /// Interaction logic for AddLawOffice.xaml
    /// </summary>
    public partial class AddLawOffice : Window
    {
        public AddLawOffice()
        {
            InitializeComponent();
        }

        private void buttonSubmit_Click(object sender, RoutedEventArgs e)
        {
            Queries query = new Queries(new System.Data.SqlClient.SqlConnection("Data Source=GABE-PC\\SQLEXPRESS;Initial Catalog=PublicDefenders;Integrated Security=True"));
            query.SetSqlCommand("INSERT INTO LawOfficeTable(NAME,ADDRESS,EMAIL,PHONENUMBER) VALUES(@Name,@Address, @Email, @PhoneNumber)");
            query.AddQueryParameters("@Name", textBoxName.Text);
            query.AddQueryParameters("@Address", textBoxAddress.Text);
            query.AddQueryParameters("@Email", textBoxEmail.Text);
            query.AddQueryParameters("@PhoneNumber", textBoxPhoneNumber.Text);
            query.Connect();
            query.ExecuteNonQuery();
            query.Disconnect();
        }

        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
