using System.ComponentModel.DataAnnotations;
using FreelanceSite.Infrastructure.Constants;

namespace FreelanceSite.Web.ViewModels.ManageViewModels
{
    using static DataConstants;

    public class IndexViewModel
    {
        public string Username { get; set; }

        public bool IsEmailConfirmed { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }

        public string StatusMessage { get; set; }

        [MinLength(UserBioMinLength,ErrorMessage = "User biography must be atleast {1} symbols long.")]
        [MaxLength(UserBioMaxLength, ErrorMessage = "User biography can be maximum {1} symbols long.")]
        public string Biography { get; set; }
    }
}
