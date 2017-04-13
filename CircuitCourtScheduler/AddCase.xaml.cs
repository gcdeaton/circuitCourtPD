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
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Net.Mail;
using DatabaseQueries;
using System.Net;
using System.Xml;
using System.IO;

namespace CircuitCourtScheduler
{
    /// <summary>
    /// Interaction logic for Add_Case.xaml
    /// </summary>
    public partial class Add_Case : Window
    {
        public Add_Case()
        {
            InitializeComponent();
            Queries defenderQuery = new Queries(new System.Data.SqlClient.SqlConnection("Data Source=GABE-PC\\SQLEXPRESS;Initial Catalog=PublicDefenders;Integrated Security=True"));
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

            XmlDocument doc = new XmlDocument();
            XmlNodeList nodeList;
            FileStream fs = new FileStream("C:\\Users\\Gabe\\Source\\Repos\\circuitCourtPD\\CircuitCourtScheduler\\CaseTypes.xml", FileMode.Open, FileAccess.Read);
            doc.Load(fs);
            fs.Close();
            nodeList = doc.GetElementsByTagName("Case");


            foreach (XmlNode caseTypes in doc.ChildNodes)
            {
                foreach (XmlNode cases in caseTypes)
                {
                    ComboBoxItem cbi = new ComboBoxItem();
                    cbi.Content = cases.InnerText;

                    comboBoxCaseTypes.Items.Add(cbi);

                }
            }
        }

        private void buttonSubmit_Click(object sender, RoutedEventArgs e)
        {
            LoginClass.email = "emailHere";

            Queries query = new Queries(new System.Data.SqlClient.SqlConnection("Data Source=GABE-PC\\SQLEXPRESS;Initial Catalog=PublicDefenders;Integrated Security=True"));
            query.SetSqlCommand("INSERT INTO CaseTable(CASENUMBER,USERNAME,DATEOF,CASETYPE,LITIGANT,DEFENDER) VALUES(@CaseNumber,@UserName, @DateOf, @CaseType, @Litigant, @Defender)");
            query.AddQueryParameters("@CaseNumber", textBoxCaseNumber.Text);
            query.AddQueryParameters("@UserName", LoginClass.email);
            query.AddQueryParameters("@DateOf", datePickerHearing.SelectedDate);
            query.AddQueryParameters("@CaseType", "JD");
            query.AddQueryParameters("@Litigant", textBoxLitigant.Text);
            query.AddQueryParameters("@Defender", comboBoxDefenders.SelectedValue);
            query.Connect();
            query.ExecuteNonQuery();
            query.Disconnect();
            sendEmail();
        }

        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {

        }

        private void sendEmail()
        {
            String defenderEmail = "jgsayers@bsu.edu";
            MailMessage mail = new MailMessage();

            mail.From = new MailAddress("pauperProjectcs498@gmail.com");
            mail.To.Add(defenderEmail);
            mail.Subject = "Hello World";
            mail.Body = "Hello";

            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);

            smtp.Credentials = new NetworkCredential("pauperProjectcs498@gmail.com", "testPassword231");
            smtp.EnableSsl = true;
            smtp.Send(mail);
        }
    }
}
