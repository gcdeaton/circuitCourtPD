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

            Queries query = new Queries(new System.Data.SqlClient.SqlConnection("Data Source=GABE-PC\\SQLEXPRESS;Initial Catalog=PublicDefenders;Integrated Security=True"));
            query.SetSqlCommand("SELECT * FROM SelectAllStaff");
            query.Connect();
            staffDataGrid.ItemsSource = query.RunSelectQuery().AsDataView();
            query.Disconnect();  
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
    }
}
