using orderBookingApi.DB.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace orderBookingApi.Services
{
    public class DataService
    {
        private DBEntitiesModel DB;
        public DataService() {
            DB = new DBEntitiesModel();
        }

        public bool SaveOrder(Order order)
        {
            DB.Orders.Add(order);
            DB.SaveChanges();
            return true;
        }
        public bool SendEmail(string ToMail)
        {
            if (ToMail == null || ToMail.Equals(""))
                return false;
            try
            {
                using (MailMessage mm = new MailMessage(ConfigurationManager.AppSettings["SMTPuser"], ToMail))
                {
                    mm.Subject = "Information Detail";
                    mm.Body = CreateBody();
                    mm.IsBodyHtml = true;
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = ConfigurationManager.AppSettings["Host"];
                    smtp.EnableSsl = true;

                    NetworkCredential NetworkCred = new NetworkCredential(ConfigurationManager.AppSettings["SMTPuser"], ConfigurationManager.AppSettings["SMTPpassword"]);
                    smtp.UseDefaultCredentials = Convert.ToBoolean(ConfigurationManager.AppSettings["EnableSSL"]);
                    smtp.Credentials = NetworkCred;
                    smtp.Port = int.Parse(ConfigurationManager.AppSettings["Port"]);
                    smtp.Send(mm);
                    return true;
                }
            }catch(Exception exp)
            {
                return false;
            }
        }

        private string CreateBody()
        {
            string body = string.Empty;
            using (StreamReader reader = new StreamReader(System.Web.Hosting.HostingEnvironment.MapPath("~/Content/Templates/EmailTemplate.html")))
            {

                body = reader.ReadToEnd();

            }

            //body = body.Replace("{fname}", txtfname.Text); //replacing Parameters

            //body = body.Replace("{lname}", txtlname.Text);

            //body = body.Replace("{dob}", txtdob.Text);
            //body = body.Replace("{post}", txtpost.Text);
            //body = body.Replace("{designation}", txtdesignation.Text);

            return body;

        }
    }
}