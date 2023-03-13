namespace Contact_Management_Web_App.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int ContactNumber { get; set; }
        public string Email { get; set; } = string.Empty;
    }
}
