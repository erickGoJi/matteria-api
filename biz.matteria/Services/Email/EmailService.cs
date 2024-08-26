using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using biz.matteria.Models;

namespace biz.matteria.Services.Email
{
    public class EmailService: IEmailService
    {
        public void SendEmailPassword(string htmlMailing, biz.matteria.Models.Email email, string nombre, string passwordTemporal)
        {

            try
            {
                System.Text.Encoding utf_8 = System.Text.Encoding.UTF8;
                var encoding = new System.Text.UTF8Encoding();
                var html = System.IO.File.ReadAllText(htmlMailing, encoding);

                html = html.Replace("@nombre", nombre);

                html = html.Replace("@passwtemporal", passwordTemporal);


                new SmtpClient
                {
                    Host = "Smtp.Gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    Timeout = 10000,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = true,
                    Credentials = new NetworkCredential("rodrigo.stps@gmail.com", "$dvs1188")

                }.Send(new MailMessage
                {



                    //From = new MailAddress("no-reply@premier.com", "Premier"),
                    From = new MailAddress("no-reply@techo.org", "Matteria"),
                    To = { email.To },
                    Subject = email.Subject,
                    IsBodyHtml = email.IsBodyHtml,
                    Body = html //email.Body
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public void SendEmailMailingnewOpening(string htmlMailing, biz.matteria.Models.Email email,biz.matteria.Models.Mailings.emailNewOpening parameters)
        {

            try
            {
                System.Text.Encoding utf_8 = System.Text.Encoding.UTF8;
                var encoding = new System.Text.UTF8Encoding();
                var html = System.IO.File.ReadAllText(htmlMailing, encoding);

                html = html.Replace("@nombre", parameters.nombre);

                html = html.Replace("@vacante", parameters.vacante);

                html = html.Replace("@fechaactual", parameters.fechaactual);

                html = html.Replace("@vencimiento", parameters.vencimiento);

                html = html.Replace("@empresa", parameters.vencimiento);


                new SmtpClient
                {
                    Host = "Smtp.Gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    Timeout = 10000,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = true,
                    Credentials = new NetworkCredential("rodrigo.stps@gmail.com", "$dvs1188")

                }.Send(new MailMessage
                {



                    //From = new MailAddress("no-reply@premier.com", "Premier"),
                    From = new MailAddress("no-reply@techo.org", "Matteria"),
                    To = { email.To },
                    Subject = email.Subject,
                    IsBodyHtml = email.IsBodyHtml,
                    Body = html //email.Body
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void SendEmailMailing(string htmlMailing, biz.matteria.Models.Email email,string nombre,string link)
        {

            try
            {
                System.Text.Encoding utf_8 = System.Text.Encoding.UTF8;
                var encoding = new System.Text.UTF8Encoding();
                var html = System.IO.File.ReadAllText(htmlMailing, encoding);

                html = html.Replace("@nombre", nombre);

                html = html.Replace("@linkperfil", link);


                new SmtpClient
                {
                    Host = "Smtp.Gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    Timeout = 10000,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = true,
                    Credentials = new NetworkCredential("rodrigo.stps@gmail.com", "$dvs1188")

                }.Send(new MailMessage
                {



                    //From = new MailAddress("no-reply@premier.com", "Premier"),
                    From = new MailAddress("no-reply@techo.org", "Matteria"),
                    To = { email.To },
                    Subject = email.Subject,
                    IsBodyHtml = email.IsBodyHtml,
                    Body = html //email.Body
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public void SendEmail(biz.matteria.Models.Email email)
        {
            try
            {
                new SmtpClient
                {
                    Host = "Smtp.Gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    Timeout = 10000,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = true,
                    Credentials = new NetworkCredential("rodrigo.stps@gmail.com", "$dvs1188")

                }.Send(new MailMessage
                {
                    //From = new MailAddress("no-reply@premier.com", "Premier"),
                    From = new MailAddress("no-reply@techo.org", "Matteria"),
                    To = { email.To },
                    Subject = email.Subject,
                    IsBodyHtml = email.IsBodyHtml,
                    Body = email.Body
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void SendEmailMailingPDF(biz.matteria.Models.Email email, string file)
        {

            try
            {

                
                Attachment data = new Attachment(file, MediaTypeNames.Application.Pdf);
                
                //ContentDisposition disposition = data.ContentDisposition;
                //disposition.CreationDate = System.IO.File.GetCreationTime(file);
                //disposition.ModificationDate = System.IO.File.GetLastWriteTime(file);
                //disposition.ReadDate = System.IO.File.GetLastAccessTime(file);

                
                System.Text.Encoding utf_8 = System.Text.Encoding.UTF8;
                var encoding = new System.Text.UTF8Encoding();
                //var html = System.IO.File.ReadAllText(htmlMailing, encoding);



                SmtpClient smptclient = new SmtpClient();
                smptclient.Host = "Smtp.Gmail.com";
                smptclient.Port = 587;
                smptclient.EnableSsl = true;
                smptclient.Timeout = 10000;
                smptclient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smptclient.UseDefaultCredentials = true;
                smptclient.Credentials = new NetworkCredential("rodrigo.stps@gmail.com", "$dvs1188");

                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress("no-reply@techo.org", "Matteria");
                mailMessage.To.Add(email.To);
                mailMessage.Subject = email.Subject;
                mailMessage.IsBodyHtml = email.IsBodyHtml;
                mailMessage.Body = email.Body;
                mailMessage.Attachments.Add(data);

                smptclient.Send(mailMessage);
                  

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
