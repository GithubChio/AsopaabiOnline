using AsopaabiOnline.Modelo;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsopaabiOnline.UI.Services
{//clase IEmailsender para configurar el envio de correo electronico 
    public class EmailSender: IEmailSender
    {

        public EmailSender(IOptions<AuthMessageSenderOptions> optionsAccessor)
        {
            Options = optionsAccessor.Value;
        }

        public AuthMessageSenderOptions Options { get; } //set only via Secret Manager

        public Task SendEmailAsync(string email, string subject, string message)
        {
            return Execute(Options.SendGridKey, subject, message, email);
        }

        public Task Execute(string apiKey, string subject, string message, string email)
        {
            var elCliente = new SendGridClient(apiKey);
            var elMensaje = new SendGridMessage()
            {
                From = new EmailAddress("asopaabi@outlook.es", "AsopaabiOnline"),
                Subject = subject,
                 
                PlainTextContent = message,
                HtmlContent = message
            };
            elMensaje.AddCc(new EmailAddress("asopaabi@outlook.es"));
            elMensaje.AddTo(new EmailAddress(email));

            // Disable click tracking.
            // See https://sendgrid.com/docs/User_Guide/Settings/tracking.html
            elMensaje.SetClickTracking(false, false);

            return elCliente.SendEmailAsync(elMensaje);
        }
      
    }

}
