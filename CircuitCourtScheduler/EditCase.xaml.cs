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
    /// Interaction logic for EditCase.xaml
    /// </summary>
    public partial class EditCase : Window
    {
        private string caseNumber;
        private string litigant;
        private string caseType;
        private DateTime dateOf;
        private string defender;


        public EditCase(string caseNumber, string litigant, string caseType, DateTime dateOf, string defender)
        {
            InitializeComponent();
            this.caseNumber = caseNumber;
            this.litigant = litigant;
            this.caseType = caseType;
            this.dateOf = dateOf;
            this.defender = defender;

            textBoxCaseNumber.Text = caseNumber;
            textBoxLitigant.Text = litigant;
            
        }

        private void buttonSubmit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
