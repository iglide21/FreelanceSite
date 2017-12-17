using FreelanceSite.Infrastructure.Constants;

namespace FreelanceSite.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using static DataConstants;

    public class Project
    {
        public int Id { get; set; }

        [Required]
        [MinLength(ProjectTitleMinLength)]
        [MaxLength(ProjectTitleMaxLength)]
        public string Title { get; set; }

        [Required]
        [MinLength(ProjectDescriptionMinLength)]
        [MaxLength(ProjectDescriptionMaxLength)]
        public string Description { get; set; }

        public int BudgetId { get; set; }

        [Required]
        public string Skills { get; set; }

        public Budget Budget { get; set; }

        public List<ProjectsCategories> Categories { get; set; } = new List<ProjectsCategories>();

        public string UserId { get; set; }

        public User User { get; set; }
    }
}
