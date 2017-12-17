using FreelanceSite.Infrastructure.Constants;

namespace FreelanceSite.Services.CommonViewModels
{
    using FreelanceSite.Entities;
    using FreelanceSite.Infrastructure.Mapping;
    using FreelanceSite.Services.CommonViewModels.Contracts;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using static DataConstants;

    public class CreateProjectViewModel : IEditCreateViewModeI, IMapFrom<Project>
    {
        [Required]
        [MinLength(ProjectTitleMinLength, ErrorMessage = "Title must be atleast {1} symbols")]
        [MaxLength(ProjectTitleMaxLength, ErrorMessage = "Title can be maximum {1} symbols")]
        public string Title { get; set; }

        [Required]
        [MinLength(ProjectDescriptionMinLength,ErrorMessage = "Description must be atleast {1} symbols")]
        [MaxLength(ProjectDescriptionMaxLength, ErrorMessage = "Description can be maximum {1} symbols")]
        public string Description { get; set; }

        [Required]
        public string Skills { get; set; }

        public List<int> Categories { get; set; }

        public BudgetViewModel Budget { get; set; }
    }
}
