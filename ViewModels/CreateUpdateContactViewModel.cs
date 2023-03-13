using System.ComponentModel;

namespace Contact_Management_Web_App.ViewModels
{
    [Index(nameof(Email), IsUnique = true)]
    [Index(nameof(ContactNumber), IsUnique = true)]
    public class CreateUpdateContactViewModel
    {
        [Key]
        public int Id { get; set; }
        [Required (ErrorMessage="The {0} is required")]
        [StringLength(int.MaxValue, MinimumLength = 5, ErrorMessage = "The {0} cannot be less then 5 charecters")]
        public string Name { get; set; }
        [DisplayName("Contact")]
        [Range(9,9)]
        public int ContactNumber { get; set; }
        [DisplayName("Email Address")]
        [EmailAddress]
        public string Email { get; set; }
    }
}
