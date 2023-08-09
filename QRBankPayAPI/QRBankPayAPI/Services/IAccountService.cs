using QRBankPayAPI.Data.Models;

namespace QRBankPayAPI.Services
{
    public interface IAccountService
    {
        string GenerateJwtToken(User user);
    }
}
