using System;
using System.Collections.Generic;
using System.IO;
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
using System.Xml;

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
            datePickerHearing.SelectedDate = dateOf;
            XmlDocument doc = new XmlDocument();
            XmlNodeList nodeList;
            FileStream fs = new FileStream("C:\\Users\\Gabe\\Source\\Repos\\circuitCourtPD\\CircuitCourtScheduler\\CaseTypes.xml", FileMode.Open, FileAccess.Read);
            doc.Load(fs);
            fs.Close();
            nodeList = doc.GetElementsByTagName("Case");
           

            foreach(XmlNode caseTypes in doc.ChildNodes)
            {
                foreach(XmlNode cases in caseTypes)
                {
                    ComboBoxItem cbi = new ComboBoxItem();
                    cbi.Content = cases.InnerText;
                    
                    comboBoxCaseTypes.Items.Add(cbi);
                    if(cbi.Content.Equals(caseType))
                    {
                        comboBoxCaseTypes.SelectedIndex = comboBoxCaseTypes.Items.IndexOf(cbi);
                    }
                    
                }
            }
            



            //for(int i =0; i <= nodeList.Count - 1; i++)
            //{
            //    ComboBoxItem cbi = new ComboBoxItem();
            //    cbi.Content = nodeList[i].ChildNodes.Item(i).InnerText;
            //    comboBoxCaseTypes.Items.Add(cbi);

            //}

            
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
