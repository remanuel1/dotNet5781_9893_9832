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
using System.Net.Mail;
using System.Net;
using BLAPI;

namespace PL
{
    /// <summary>
    /// Interaction logic for SendMail.xaml
    /// </summary>
    public partial class SendMail : Window
    {
        IBL bl;
        public SendMail()
        {
            InitializeComponent();
        }

        public SendMail(IBL _bl)
        {
            InitializeComponent();
            bl = _bl;
        }

        private bool isValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void mailAddress_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                BO.User user = new BO.User();
                if (isValidEmail(mailAddress.Text))
                {
                    try
                    {
                        user = bl.getUserByMail(mailAddress.Text);
                        MailMessage mail = new MailMessage();
                        mail.To.Add(user.mail);
                        mail.From = new MailAddress("miniproject659@gmail.com");
                        mail.Subject = "password recovery";
                        mail.Body = string.Format("your password is: " + user.password);
                        mail.IsBodyHtml = true;

                        NetworkCredential auth = new NetworkCredential("miniproject659@gmail.com", "maayan1234");

                        SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                        client.EnableSsl = true;
                        //client.UseDefaultCredentials = false;
                        client.Credentials = auth;
                        client.Send(mail);
                        MessageBox.Show("The password was sent to your email.");
                        this.Close();
                    }
                    catch
                    {
                        MessageBox.Show("ERROR, enter your mail address again..", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                    }

                }
            }
        }
    }
}
