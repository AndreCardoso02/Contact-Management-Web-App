namespace Contact_Management_Web_App.IServices
{
    public interface IUserService
    {
        Task<bool> Login(string Email, string Password);
    }
}
