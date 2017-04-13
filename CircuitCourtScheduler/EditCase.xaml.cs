using System;
using System.Collections.Generic;
using System.Data;
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


            DatabaseQueries.Queries defenderQuery = new DatabaseQueries.Queries(new System.Data.SqlClient.SqlConnection("Data Source=GABE-PC\\SQLEXPRESS;Initial Catalog=PublicDefenders;Integrated Security=True"));
            defenderQuery.SetSqlCommand("SELECT FIRSTNAME,LASTNAME,EMAIL FROM DefendersTable");
            defenderQuery.Connect();
            DataTable dt = defenderQuery.RunSelectQuery();
            defenderQuery.Disconnect();

            foreach (DataRow row in dt.Rows)
            {
                ComboBoxItem cbi = new ComboBoxItem();
                cbi.Content = row["FIRSTNAME"].ToString() + " " + row["LASTNAME"].ToString();
                comboBoxDefenders.Items.Add(cbi);
            }


        }

        private void buttonSubmit_Click(object sender, RoutedEventArgs e)
        {
            DatabaseQueries.Queries updateQuery = new DatabaseQueries.Queries(new System.Data.SqlClient.SqlConnection("Data Source=GABE-PC\\SQLEXPRESS;Initial Catalog=PublicDefenders;Integrated Security=True"));
            updateQuery.SetSqlCommand("UPDATE CaseTable SET DATEOF = @Date, DEFENDER = @Defender WHERE CASENUMBER = @Casenumber");
            updateQuery.AddQueryParameters("@Date",datePickerHearing.SelectedDate);
            updateQuery.AddQueryParameters("@Defender",comboBoxDefenders.Text);
            updateQuery.AddQueryParameters("@Casenumber",caseNumber);
            updateQuery.Connect();
            updateQuery.ExecuteNonQuery();
            updateQuery.Disconnect();
            
            //DatabaseQueries.Queries insertQuery = new DatabaseQueries.Queries(new System.Data.SqlClient.SqlConnection("Data Source=GABE-PC\\SQLEXPRESS;Initial Catalog=PublicDefenders;Integrated Security=True"));
            //insertQuery.SetSqlCommand("INSERT INTO EditedTable(CASENUMBER,USERNAME,REASON,DATEOFCHANGE,IDENTIFIER) VALUES(@CaseNumber,@UserName, @Reason, @DateOfChange, @Identifier)");
            //insertQuery.AddQueryParameters("@CaseNumber",);
            //insertQuery.AddQueryParameters("@UserName",);
            //insertQuery.AddQueryParameters("@Reason",);
            //insertQuery.AddQueryParameters("@DateOfChange", DateTime.Today);
            //insertQuery.AddQueryParameters("@Identifier",);
            
        }

        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
