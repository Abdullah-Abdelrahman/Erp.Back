using Name.Data.Entities;

namespace Name.Service.Abstracts
{
    public interface IAuthenticationService
    {

        public Task<string> GetJWTtoken(UserBase user);

        public Task<string> ConfirmEmail(string userId, string code);

        public Task<string> SendResetPassword(string Email);

        public Task<string> ResetPassword(string Email, string code);


    }
}
