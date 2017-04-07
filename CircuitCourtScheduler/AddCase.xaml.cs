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
using System.Net;

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
