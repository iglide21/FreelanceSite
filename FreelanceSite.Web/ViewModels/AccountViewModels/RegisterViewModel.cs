using FreelanceSite.Infrastructure.Constants;

namespace FreelanceSite.Web.ViewModels.AccountViewModels
{
    using System.ComponentModel.DataAnnotations;

    using static DataConstants;

    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "Username")]
        [MinLength(UserUsernameMinLength,ErrorMessage = "Username minimum length is 6 symbols.")]
        [MaxLength(UserUsernameMaxLength, ErrorMessage = "Username maximum length is 25 symbols.")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "First name")]
        [MinLength(UserFirstNameMinLength, ErrorMessage = "First name minimum length is 2 symbols.")]
        [MaxLength(UserFirstNameMaxLength, ErrorMessage = "First name maximum length is 30 symbols.")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last name")]
        [MinLength(UserLastNameMinLength, ErrorMessage = "Last name minimum length is 2 symbols.")]
        [MaxLength(UserLastNameMaxLength, ErrorMessage = "Last name maximum length is 30 symbols.")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
