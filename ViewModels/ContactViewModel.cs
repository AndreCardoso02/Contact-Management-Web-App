using System.ComponentModel;

namespace Contact_Management_Web_App.ViewModels
{
    [Index(nameof(Email), IsUnique = true)]
    [Index(nameof(ContactNumber), IsUnique = true)]
    public class ContactViewModel
    {
        [Key]
        public int Id { get; set; }
        [Required (ErrorMessage="The {0} is required")]
        [StringLength(int.MaxValue, MinimumLength = 5, ErrorMessage = "The {0} cannot be less then 5 charecters")]
        public string Name { get; set; } = string.Empty;
        [DisplayName("Contact")]
        [Range(99999999,1000000000)]
        public int ContactNumber { get; set; }
        [DisplayName("Email Address")]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
    }
}
