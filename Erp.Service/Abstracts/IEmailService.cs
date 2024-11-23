namespace Name.Service.Abstracts
{
    public interface IEmailService
    {
        public Task<string> SendEmailAsync(string email, string Message, string? reason);

    }
}
