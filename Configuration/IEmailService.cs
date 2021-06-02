namespace desafio_gft_api.Configuration
{
    public interface IEmailService
    {
         bool SendEmail(EmailData emailData);
    }
}