using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace BookMyTrainAdminClientApp.Codes
{
    public class Codes
    {
        public void SendEmail(string subjectline, string mailbody, string toMail)
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

        public string HashPassword(string password)
        {
            // generate a 128-bit salt using a cryptographically strong random sequence of nonzero values
            byte[] salt = new byte[128 / 8];
            using (var rngCsp = new RNGCryptoServiceProvider())
            {
                rngCsp.GetNonZeroBytes(salt);
            }

            // derive a 256-bit subkey (use HMACSHA256 with 100,000 iterations)
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8));
            return hashed;
        }

    }
}
