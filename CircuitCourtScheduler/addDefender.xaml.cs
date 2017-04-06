using DatabaseQueries;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for addDefender.xaml
    /// </summary>
    public partial class addDefender : Window
    {
        public addDefender()
        {
            InitializeComponent();

            Queries query = new Queries(new System.Data.SqlClient.SqlConnection("Data Source=GABE-PC\\SQLEXPRESS;Initial Catalog=PublicDefenders;Integrated Security=True"));
            query.SetSqlCommand("SELECT NAME FROM LawOfficeTable");
            query.Connect();
            DataTable dt = query.RunSelectQuery();
            query.Disconnect();

            foreach (DataRow row in dt.Rows)
            {
                ComboBoxItem cbi = new ComboBoxItem();
                cbi.Content = row["NAME"];
                comboBoxLawOffices.Items.Add(cbi);
            }
        }

        private void buttonAddDefender_Click(object sender, RoutedEventArgs e)
        {
            Queries query = new Queries(new System.Data.SqlClient.SqlConnection("Data Source=GABE-PC\\SQLEXPRESS;Initial Catalog=PublicDefenders;Integrated Security=True"));
            query.SetSqlCommand("INSERT INTO DefendersTable(FIRSTNAME,LASTNAME,LAWOFFICE,EMAIL,CONTACT,ACTIVATED) VALUES(@FirstName,@LastName, @LawOffice, @Email, @Contact, @Activated)");
            query.AddQueryParameters("@FirstName", textBoxFirstName.Text);
            query.AddQueryParameters("@LastName", textBoxLastName.Text);
            query.AddQueryParameters("@LawOffice", comboBoxLawOffices.SelectedItem.ToString());
            query.AddQueryParameters("@Email", textBoxEmail.Text);
            query.AddQueryParameters("@Contact", textBoxPhoneNumber.Text);
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
    }
}
