﻿using System;
using System.Windows;
using System.Windows.Controls;
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
            
            Login loginWindow = new Login();
            loginWindow.Show();
            LoginClass.email = "";
            this.Close();

        }

        private void reportItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void editCase_Click(object sender, RoutedEventArgs e)
        {
            SearchCase searchCaseWindow = new SearchCase();
            searchCaseWindow.ShowDialog();
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

        private void caseRow_DoubleClick(object sender, EventArgs e)
        {
            int rowIndex = caseDataGrid.SelectedIndex;

            var row = (DataGridRow)caseDataGrid.ItemContainerGenerator.ContainerFromItem(caseDataGrid.SelectedItem);
            DataRowView drv = (DataRowView)row.Item;
            DataRow dr = (DataRow)drv.Row;
            string caseNumber = dr.ItemArray[0].ToString();
            string litigant = dr.ItemArray[1].ToString();
            string caseType = dr.ItemArray[2].ToString();
            DateTime dateOf = (DateTime)dr.ItemArray[3];
            string defender = dr.ItemArray[4].ToString();

            EditCase editWindow = new EditCase(caseNumber,litigant,caseType,dateOf,defender);
            editWindow.ShowDialog();


        }
        
        private void Window_Activated(object sender, EventArgs e)
        {
            
            populateCaseData();
            populateDefenderData();
            populateEditsData();
            populateLawOffice();
            populateStaffData();
         
        }


        private void defenderRow_DoubleClick(object sender, EventArgs e)
        {
            int rowIndex = defenderDataGrid.SelectedIndex;
            var row = (DataGridRow)defenderDataGrid.ItemContainerGenerator.ContainerFromItem(defenderDataGrid.SelectedItem);
            DataRowView drv = (DataRowView)row.Item;
            DataRow dr = (DataRow)drv.Row;
            string firstName = dr.ItemArray[0].ToString();
            string lastName = dr.ItemArray[1].ToString();
            string lawOffice = dr.ItemArray[2].ToString();
            string phoneNumber = dr.ItemArray[3].ToString();

            EditDefender defenderWindow = new EditDefender(firstName, lastName, lawOffice, phoneNumber);
            defenderWindow.ShowDialog();
        }


        private void staffRow_DoubleClick(object sender, EventArgs e)
        {
            int rowIndex = staffDataGrid.SelectedIndex;
            var row = (DataGridRow)staffDataGrid.ItemContainerGenerator.ContainerFromItem(staffDataGrid.SelectedItem);
            DataRowView drv = (DataRowView)row.Item;
            DataRow dr = (DataRow)drv.Row;
            string firstName = dr.ItemArray[0].ToString();
            string lastName = dr.ItemArray[1].ToString();
            string lawOffice = dr.ItemArray[2].ToString();
            string phoneNumber = dr.ItemArray[3].ToString();

            //EditStaff staffWindow = new EditStaff(firstName, lastName, email, dateAdded);
            //staffWindow.ShowDialog();
        }

        private void lawOfficeRow_DoubleClick(object sender, EventArgs e)
        {

        }
    }
}
