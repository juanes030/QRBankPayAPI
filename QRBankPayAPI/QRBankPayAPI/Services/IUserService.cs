using QRBankPayAPI.Data.Models;

namespace QRBankPayAPI.Services
{
    public interface IUserService
    {
        Task<User>? GetUserAsync(string username, string password);
    }
}
