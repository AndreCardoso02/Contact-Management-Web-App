namespace Contact_Management_Web_App.Seeds
{
    public class DataSeeder
    {
        private readonly ApplicationDbContext _context;

        public DataSeeder(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            // To make sure if database is created
            _context.Database.EnsureCreated();

            // Insert user default
            if (!_context.Users.Any())
            {
                _context.Users.Add(new User()
                {
                    UserName = "Andre",
                    Email = "andremirandacardoso02@gmail.com",
                    Password = "12345"
                });
                _context.SaveChanges();
            }
        }
    }
}
