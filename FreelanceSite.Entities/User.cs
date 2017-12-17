using FreelanceSite.Infrastructure.Constants;

namespace FreelanceSite.Entities
{
    using Microsoft.AspNetCore.Identity;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static DataConstants;

    public class User : IdentityUser
    {
        [Required]
        [MinLength(UserFirstNameMinLength)]
        [MaxLength(UserFirstNameMaxLength)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(UserLastNameMinLength)]
        [MaxLength(UserLastNameMaxLength)]
        public string LastName { get; set; }

        public List<Project> Projects { get; set; }

        public string Role { get; set; }
    }
}
