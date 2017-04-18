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
    /// Interaction logic for EditStaff.xaml
    /// </summary>
    public partial class EditStaff : Window
    {
        private string firstName;
        private string lastName;
        private string email;
        private DateTime dateAdded;



        public EditStaff(string firstName,string lastName,string email, DateTime dateAdded)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
            this.dateAdded = dateAdded;

            InitializeComponent();



        }

        private void buttonAddStaff_Click(object sender, RoutedEventArgs e)
        {

        }

        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
