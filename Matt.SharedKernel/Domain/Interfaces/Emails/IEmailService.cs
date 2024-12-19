namespace Matt.SharedKernel.Domain.Interfaces.Emails;

public interface IEmailService
{
    Task Send(string email, string subject, string message);
    Task SendHtml(string email, string subject, string template);
}