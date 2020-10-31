using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using CurrencyEmailService.Model;
using CurrencyEmailService.Service.Contract;

namespace CurrencyEmailService.Service.Concrete
{
    public class EmailService : IEmailService
    {
         public bool SendReport(Task<CurrencyModel.Root> currencyList)
         {
            try
            {
                //NOT : E-mail göndermek için "Daha az güvenli uygulamalara izin ver: AÇIK" şeklinde ayarlamalı. URL :  https://www.google.com/settings/u/1/security/lesssecureapps 
                var fromAddress = new MailAddress("***", "Reporter"); //ilgili mail adresi girilmeli
                var toAddress = new MailAddress("***", "Reciever"); //ilgili mail adresi girilmeli
                
                string fromPassword = "***";  //gönderici mail parolası girilmeli
                string subject = "Currency Report, Date :" + DateTime.Now; 
                
                string body = HtmlBodyCreator.CreateEmailBody(currencyList.Result.result);

                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                };
                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true
                })
                {
                    smtp.Send(message);
                }

                return true;
            }
            catch (Exception e)
            { 
                throw new Exception(e.Message);
            } 
        }
    }
}