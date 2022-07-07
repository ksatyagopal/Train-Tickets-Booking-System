using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Threading.Tasks;
using BCrypt.Net;

namespace BookMyTrainAPI.Codes
{
    public class Codes
    {
        public static void SendEmail(string subjectline, string mailbody, string toMail)
        {
            string fromMail = "bookmytraincompany@gmail.com";
            MailMessage mailMessage = new MailMessage(fromMail, toMail);
            mailMessage.Subject = subjectline;
            mailMessage.Body = mailbody;
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new System.Net.NetworkCredential(fromMail, "kxyjswdksikfmwdc");
            smtpClient.EnableSsl = true;
            smtpClient.Send(mailMessage);
        }

        public string Hash(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public bool Verify(string actualPassword, string givenPassword)
        {
            var isTrue = BCrypt.Net.BCrypt.Verify(givenPassword, actualPassword);
            return isTrue;
        }


    }
}
