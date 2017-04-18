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
    /// Interaction logic for SearchCase.xaml
    /// </summary>
    public partial class SearchCase : Window
    {
        private DataTable dtCase;
        private DataView dv;
        public SearchCase()
        {
            InitializeComponent();
            populateCaseData();
        }


        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void buttonConfirm_Click(object sender, RoutedEventArgs e)
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

            EditCase editWindow = new EditCase(caseNumber, litigant, caseType, dateOf, defender);
            editWindow.Show();
            this.Close();
        }

        private void populateCaseData()
        {
            Queries query = new Queries(new System.Data.SqlClient.SqlConnection("Data Source=GABE-PC\\SQLEXPRESS;Initial Catalog=PublicDefenders;Integrated Security=True"));
            query.SetSqlCommand("SELECT * FROM SelectAllCases");
            query.Connect();
            dtCase = query.RunSelectQuery();
            query.Disconnect();

            dv = dtCase.AsDataView();
            caseDataGrid.ItemsSource = dv;
            

            foreach (DataColumn col in dtCase.Columns)
            {
                ComboBoxItem cbi = new ComboBoxItem();
                cbi.Content = col.ColumnName;
                comboBoxCasefields.Items.Add(cbi);
            }
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            

        }

        private void textBoxCaseSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchField = comboBoxCasefields.Text;
            DataTable temp = dtCase.Clone();
            if (textBoxCaseSearch.Text != "" && comboBoxCasefields.SelectedIndex > -1)
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
    }
}
