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
    /// Interaction logic for EditDefender.xaml
    /// </summary>
    public partial class EditDefender : Window
    {
        private string firstName;
        private string lastName;
        private string lawOffice;
        private string phoneNumber;

        public EditDefender(string firstName, string lastName, string lawOffice, string phoneNumber)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.lawOffice = lawOffice;
            this.phoneNumber = phoneNumber;
            InitializeComponent();

        }


        private void buttonSubmit_Click(object sender, RoutedEventArgs e)
        {








            this.Close();
        }

        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
