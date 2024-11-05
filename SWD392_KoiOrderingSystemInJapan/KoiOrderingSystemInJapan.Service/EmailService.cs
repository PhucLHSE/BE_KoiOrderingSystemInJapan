using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

public interface IEmailService
{
    Task SendEmailAsync(string toEmail, string subject, string message);
}

public class EmailService : IEmailService
{
    private readonly IConfiguration _configuration;

    public EmailService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task SendEmailAsync(string toEmail, string subject, string message)
    {
        // Retrieve email settings from configuration
        var emailSettings = _configuration.GetSection("EmailSettings");
        var smtpServer = emailSettings["SmtpServer"];
        var port = int.Parse(emailSettings["Port"]);
        var senderEmail = emailSettings["SenderEmail"];
        var senderName = emailSettings["SenderName"];
        var username = emailSettings["Username"];
        var password = emailSettings["Password"];

        var mailMessage = new MailMessage
        {
            From = new MailAddress(senderEmail, senderName),
            Subject = subject,
            Body = message,
            IsBodyHtml = true
        };
        mailMessage.To.Add(new MailAddress(toEmail));

        using (var client = new SmtpClient(smtpServer, port))
        {
            // Set client credentials and enable SSL
            client.Credentials = new NetworkCredential(username, password);
            client.EnableSsl = true;

            // Send the email asynchronously
            await client.SendMailAsync(mailMessage);
        }
    }
}
