
using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;
using PortfolioSiteApi.Models;

public class EmailService
{
    private readonly IConfiguration _configuration;

    public EmailService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task SendEmailAsync(User destinationUser, string subject, string message)
    {
        MimeMessage email = new MimeMessage();

        email.From.Add(new MailboxAddress(_configuration["SmtpSettings:SenderName"],
        _configuration["SmtpSettings:SenderEmail"]));

        email.To.Add(new MailboxAddress(destinationUser.Name,destinationUser.Email));

        email.Subject = subject;

        email.Body = new TextPart("html")
        {
            Text = message
        };

        using (SmtpClient client = new SmtpClient())
        {
            await client.ConnectAsync(_configuration["SmtpSettings:Server"], int.Parse(_configuration["SmtpSettings:Port"]), false);

            await client.AuthenticateAsync(_configuration["SmtpSettings:Username"], _configuration["SmtpSettings:Password"]);

            await client.SendAsync(email);

            await client.DisconnectAsync(true);
        }
        
    }
}