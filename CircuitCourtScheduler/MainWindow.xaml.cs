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
        private DataView dv;
        private DataTable dtCase;
        private DataTable dtStaff;
        private DataTable dtDefender;
        private DataTable dtEdit;
        private DataTable dtLawOffice;
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
            dtEdit = query.RunSelectQuery();
            editsDataGrid.ItemsSource = dtEdit.AsDataView();
            query.Disconnect();

            foreach (DataColumn col in dtEdit.Columns)
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
            dtLawOffice = query.RunSelectQuery();
            lawOfficeDataGrid.ItemsSource = dtLawOffice.AsDataView();
            query.Disconnect();

            foreach (DataColumn col in dtLawOffice.Columns)
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
            dtDefender = query.RunSelectQuery();
            defenderDataGrid.ItemsSource = dtDefender.AsDataView();
            query.Disconnect();

            foreach (DataColumn col in dtDefender.Columns)
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
            dtCase = query.RunSelectQuery();
            dv = dtCase.AsDataView();
            caseDataGrid.ItemsSource = dv;
            query.Disconnect();

            foreach (DataColumn col in dtCase.Columns)
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
            string searchField = comboBoxCaseFields.Text;
            DataTable temp = dtCase.Clone();
            if(textBoxCaseSearch.Text != "" && comboBoxCaseFields.SelectedIndex > -1)
            {
                foreach (DataRow row in dtCase.Rows)
                {
                    if (row[searchField].ToString().ToUpper().Contains(textBoxCaseSearch.Text.ToUpper()))
                    {
                        temp.ImportRow(row);
                    }
                }
                caseDataGrid.ItemsSource = temp.AsDataView();
            }
            else
            {
                caseDataGrid.ItemsSource = dtCase.AsDataView();
            }
            

        }

        private void populateStaffData()
        {
            Queries query = new Queries(new System.Data.SqlClient.SqlConnection("Data Source=GABE-PC\\SQLEXPRESS;Initial Catalog=PublicDefenders;Integrated Security=True"));
            query.SetSqlCommand("SELECT * FROM SelectAllStaff");
            query.Connect();
            dtStaff = query.RunSelectQuery();
            staffDataGrid.ItemsSource = dtStaff.AsDataView();
            query.Disconnect();

            foreach (DataColumn col in dtStaff.Columns)
            {
                ComboBoxItem cbi = new ComboBoxItem();
                cbi.Content = col.ColumnName;
                comboBoxStaffFields.Items.Add(cbi);
            }
        }

        private void textBoxStaffSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchField = comboBoxStaffFields.Text;
            DataTable temp = dtStaff.Clone();
            if (textBoxStaffSearch.Text != "" && comboBoxStaffFields.SelectedIndex > -1)
            {
                foreach (DataRow row in dtStaff.Rows)
                {
                    if (row[searchField].ToString().ToUpper().Contains(textBoxStaffSearch.Text.ToUpper()))
                    {
                        temp.ImportRow(row);
                    }
                }
                staffDataGrid.ItemsSource = temp.AsDataView();
            }
            else
            {
                staffDataGrid.ItemsSource = dtStaff.AsDataView();
            }
        }

        private void textBoxDefenderSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchField = comboBoxDefenderFields.Text;
            DataTable temp = dtDefender.Clone();
            if (textBoxDefenderSearch.Text != "" && comboBoxDefenderFields.SelectedIndex > -1)
            {
                foreach (DataRow row in dtDefender.Rows)
                {
                    if (row[searchField].ToString().ToUpper().Contains(textBoxDefenderSearch.Text.ToUpper()))
                    {
                        temp.ImportRow(row);
                    }
                }
                defenderDataGrid.ItemsSource = temp.AsDataView();
            }
            else
            {
                defenderDataGrid.ItemsSource = dtDefender.AsDataView();
            }
        }

        private void textBoxLawOfficeSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchField = comboBoxLawOfficeFields.Text;
            DataTable temp = dtLawOffice.Clone();
            if (textBoxLawOfficeSearch.Text != "" && comboBoxLawOfficeFields.SelectedIndex > -1)
            {
                foreach (DataRow row in dtLawOffice.Rows)
                {
                    if (row[searchField].ToString().ToUpper().Contains(textBoxLawOfficeSearch.Text.ToUpper()))
                    {
                        temp.ImportRow(row);
                    }
                }
                lawOfficeDataGrid.ItemsSource = temp.AsDataView();
            }
            else
            {
                lawOfficeDataGrid.ItemsSource = dtLawOffice.AsDataView();
            }
        }

        private void textBoxEditSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchField = comboBoxEditsFields.Text;
            DataTable temp = dtEdit.Clone();
            if (textBoxEditSearch.Text != "" && comboBoxEditsFields.SelectedIndex > -1)
            {
                foreach (DataRow row in dtEdit.Rows)
                {
                    if (row[searchField].ToString().ToUpper().Contains(textBoxEditSearch.Text.ToUpper()))
                    {
                        temp.ImportRow(row);
                    }
                }
                editsDataGrid.ItemsSource = temp.AsDataView();
            }
            else
            {
                editsDataGrid.ItemsSource = dtEdit.AsDataView();
            }
        }
    }
}
