using QRBankPayAPI.Data;
using QRBankPayAPI.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace QRBankPayAPI.Services
{
    public class UserService : IUserService
    {
        private readonly QRBankPayDbContext _context;

        public UserService(QRBankPayDbContext context)
        {
            _context = context;
        }

        public async Task<User>? GetUserAsync(string username, string password)
        {
            if (_context.Users == null)
            {
                return null;
            }
            var user = await _context.Users.FirstOrDefaultAsync(user => user.UserName == username && user.Password == password);

            return user;
        }
    }
}
