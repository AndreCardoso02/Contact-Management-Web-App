using Contact_Management_Web_App.IServices;

namespace Contact_Management_Web_App.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Login(string Email, string Password)
        {
            return await _context.Users
                            .Where(us => us.Email.Equals(Email) 
                                && us.Password.Equals(Password))
                            .AnyAsync();
        }
    }
}
