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
using System.Windows.Navigation;
using System.Windows.Shapes;
using DatabaseQueries;
using System.Data;

namespace CircuitCourtScheduler
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            populateStaffData();
            populateCaseData();
            populateDefenderData();
            populateLawOffice();
            populateEditsData();
        }

        private void populateEditsData()
        {
            Queries query = new Queries(new System.Data.SqlClient.SqlConnection("Data Source=GABE-PC\\SQLEXPRESS;Initial Catalog=PublicDefenders;Integrated Security=True"));
            query.SetSqlCommand("SELECT * FROM SelectAllEdits");
            query.Connect();
            DataTable dt = query.RunSelectQuery();
            editsDataGrid.ItemsSource = dt.AsDataView();
            query.Disconnect();

            foreach (DataColumn col in dt.Columns)
            {
                ComboBoxItem cbi = new ComboBoxItem();
                cbi.Content = col.ColumnName;
                comboBoxEditsFields.Items.Add(cbi);
            }
        }

        private void populateLawOffice()
        {

            Queries query = new Queries(new System.Data.SqlClient.SqlConnection("Data Source=GABE-PC\\SQLEXPRESS;Initial Catalog=PublicDefenders;Integrated Security=True"));
            query.SetSqlCommand("SELECT * FROM SelectAllLawOffice");
            query.Connect();
            DataTable dt = query.RunSelectQuery();
            lawOfficeDataGrid.ItemsSource = dt.AsDataView();
            query.Disconnect();

            foreach (DataColumn col in dt.Columns)
            {
                ComboBoxItem cbi = new ComboBoxItem();
                cbi.Content = col.ColumnName;
                comboBoxLawOfficeFields.Items.Add(cbi);
            }
        }

        private void populateDefenderData()
        {

            Queries query = new Queries(new System.Data.SqlClient.SqlConnection("Data Source=GABE-PC\\SQLEXPRESS;Initial Catalog=PublicDefenders;Integrated Security=True"));
            query.SetSqlCommand("SELECT * FROM SelectAllDefenders");
            query.Connect();
            DataTable dt = query.RunSelectQuery();
            defenderDataGrid.ItemsSource = dt.AsDataView();
            query.Disconnect();

            foreach (DataColumn col in dt.Columns)
            {
                ComboBoxItem cbi = new ComboBoxItem();
                cbi.Content = col.ColumnName;
                comboBoxDefenderFields.Items.Add(cbi);
            }
        }

        private void populateCaseData()
        {
            Queries query = new Queries(new System.Data.SqlClient.SqlConnection("Data Source=GABE-PC\\SQLEXPRESS;Initial Catalog=PublicDefenders;Integrated Security=True"));
            query.SetSqlCommand("SELECT * FROM SelectAllCases");
            query.Connect();
            DataTable dt = query.RunSelectQuery();
            caseDataGrid.ItemsSource = dt.AsDataView();
            query.Disconnect();

            foreach (DataColumn col in dt.Columns)
            {
                ComboBoxItem cbi = new ComboBoxItem();
                cbi.Content = col.ColumnName;
                comboBoxCaseFields.Items.Add(cbi);
            }
        }

        private void logOutItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void reportItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void editCase_Click(object sender, RoutedEventArgs e)
        {

        }

        private void editStaff_Click(object sender, RoutedEventArgs e)
        {

        }

        private void editDefender_Click(object sender, RoutedEventArgs e)
        {

        }

        private void editLawOffice_Click(object sender, RoutedEventArgs e)
        {

        }

        private void addCase_Click(object sender, RoutedEventArgs e)
        {
            Add_Case addCaseWindow = new Add_Case();
            addCaseWindow.ShowDialog();
        }

        private void addStaff_Click(object sender, RoutedEventArgs e)
        {
            addStaff addStaffWindow = new addStaff();
            addStaffWindow.ShowDialog();
        }

        private void addDefender_Click(object sender, RoutedEventArgs e)
        {
            addDefender addDefenderWindow = new addDefender();
            addDefenderWindow.ShowDialog();
        }

        private void addLawOffice_Click(object sender, RoutedEventArgs e)
        {

        }

        private void textBoxCaseSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void populateStaffData()
        {
            Queries query = new Queries(new System.Data.SqlClient.SqlConnection("Data Source=GABE-PC\\SQLEXPRESS;Initial Catalog=PublicDefenders;Integrated Security=True"));
            query.SetSqlCommand("SELECT * FROM SelectAllStaff");
            query.Connect();
            DataTable dt = query.RunSelectQuery();
            staffDataGrid.ItemsSource = dt.AsDataView();
            query.Disconnect();

            foreach (DataColumn col in dt.Columns)
            {
                ComboBoxItem cbi = new ComboBoxItem();
                cbi.Content = col.ColumnName;
                comboBoxStaffFields.Items.Add(cbi);
            }
        }
    }
}
