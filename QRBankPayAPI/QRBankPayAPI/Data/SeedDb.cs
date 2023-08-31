using QRBankPayAPI.Enumerations;

namespace QRBankPayAPI.Data
{
    public class SeedDb
    {
        private readonly QRBankPayDbContext context;
        private readonly Random random;

        public SeedDb(QRBankPayDbContext context)
        {
            this.context = context;
            this.random = new Random();
        }

        public async Task SeedAsync()
        {
            await this.context.Database.EnsureCreatedAsync();

            if (!this.context.Clients.Any())
            {
                this.AddClient("First Client");
                this.AddClient("Second Client");
                this.AddClient("Third Client");
                await this.context.SaveChangesAsync();
            }

            if (!this.context.UserRoles.Any())
            {
                this.AddUserRole("Administrator", RoleType.SuperAdmin);
                this.AddUserRole("Staff", RoleType.Staff);
                this.AddUserRole("Guest", RoleType.Guest);
                await this.context.SaveChangesAsync();
            }

            if (!this.context.Users.Any())
            {
                this.AddUser("AdminUser", "123", 1);
                this.AddUser("StaffUser", "123", 2);
                this.AddUser("GuestUser", "123", 3);
                await this.context.SaveChangesAsync();
            }

            if (!this.context.Transactions.Any())
            {
                this.AddTransaction("PAGO TARJETA CREDITO","21/01/2023","$ 80.563.00","1152191599");
                this.AddTransaction("EXITO", "01/05/2023", "$ 120.563.00", "1152191599");
                this.AddTransaction("PAGO NOMINA", "15/02/2023", "$ 5.000.000.00", "1152191599");
                this.AddTransaction("CREPES Y WAFFLES", "24/12/2023", "$ 90.000.00", "1152191599");
                this.AddTransaction("LOS MOLINOS", "08/08/2023", "$ 400.000.00", "1152191599");
                this.AddTransaction("TEATRO CINECOLOMBIA", "10/11/2023", "$ 45.500.00", "1152191599");
                this.AddTransaction("PAGO NOMINA", "30/04/2023", "$ 6.000.000.00", "1152191599");
                await this.context.SaveChangesAsync();
            }

            if (!this.context.SourceBankAccount.Any())
            {
                this.AddSourceBankAccount("1152191599", "01254874525");
                await this.context.SaveChangesAsync();
            }
        }

        private void AddTransaction(string description, string date, string value, string cuentaOrigen)
        {
            this.context.Transactions.Add(new Models.Transaction
            {
                Description = description,
                Date = date,
                Value = value
            });
        }

        private void AddSourceBankAccount(string dna, string sourceAccount)
        {
            this.context.SourceBankAccount.Add(new Models.SourceBankAccount
            {
                Dna = dna,
                SourceAccount = sourceAccount
            });
        }

        private void AddClient(string name)
        {
            this.context.Clients.Add(new Models.Client
            {
                Name = name,
                Dna = this.random.Next(1000000, 1999999).ToString()
            });
        }

        private void AddUserRole(string roleName, RoleType roleType)
        {
            this.context.UserRoles.Add(new Models.UserRole
            {
                Name = roleName,
                Type = roleType
            });
        }

        private void AddUser(string userId, string password, long userRoleId)
        {
            this.context.Users.Add(new Models.User
            {
                UserName = userId,
                Password = password,
                RoleId = userRoleId
            });
        }
    }
}
