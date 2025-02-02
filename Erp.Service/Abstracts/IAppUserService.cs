using Erp.Data.Entities.MainModule;

namespace Name.Service.Abstracts
{
  public interface IUserBaseService
    {
        public Task<string> AddUserAsync(UserBase UserBase, string password);

        public Task<string> ChangePasswordAsync(string Email, string password);

    }
}
