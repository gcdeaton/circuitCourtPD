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
        }

        private void buttonSubmit_Click(object sender, RoutedEventArgs e)
        {
            sendEmail();
        }

        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {

        }

        private void sendEmail()
        {
            SmtpClient smtpClient = new SmtpClient("Host");

            smtpClient.Credentials = new System.Net.NetworkCredential("PauperProjectcs498@gmail.com", "testPassword231");
            smtpClient.UseDefaultCredentials = true;
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.EnableSsl = true;
            MailMessage mail = new MailMessage();

            mail.From = new MailAddress("PauperProjectcs498@gmail.com");
            mail.To.Add(new MailAddress("jgsayers@bsu.edu"));
            mail.Body = "This is a test message";
            mail.Subject = "testEmail";

            smtpClient.Send(mail);
        }
    }
}
